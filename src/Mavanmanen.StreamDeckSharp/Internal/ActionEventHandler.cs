using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Mavanmanen.StreamDeckSharp.Internal.Events;
using Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents;
using Microsoft.Extensions.DependencyInjection;

namespace Mavanmanen.StreamDeckSharp.Internal
{
    internal class ActionEventHandler
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Dictionary<string, Type> _actionMap;

        public ActionEventHandler(IServiceProvider serviceProvider, List<ActionDefinition> actions)
        {
            _serviceProvider = serviceProvider;

            _actionMap = actions.ToDictionary(
                k => k.ActionData.Name.ToLower(),
                v => v.Type);
        }

        public async Task HandleEventAsync(StreamDeckActionEvent actionEvent)
        {
            string eventName = actionEvent.Action!.Split('.').Last().ToLower();
            if (!_actionMap.ContainsKey(eventName))
            {
                return;
            }

            using IServiceScope scope = _serviceProvider.CreateScope();

            var actionInstance = (StreamDeckAction) scope.ServiceProvider.GetRequiredService(_actionMap[eventName]);
            actionInstance.Context = actionEvent.Context;
            actionInstance.Device = actionEvent.Device;

            switch (actionEvent.Event)
            {
                case EventTypes.KeyDown:
                case EventTypes.KeyUp:
                    await HandleKeyEventAsync(actionInstance, (KeyEvent) actionEvent);
                    break;

                case EventTypes.WillAppear:
                case EventTypes.WillDisappear:
                    await HandleAppearanceEventAsync(actionInstance, (AppearanceEvent) actionEvent);
                    break;

                case EventTypes.TitleParameterDidChange:
                    await HandleTitleParametersDidChangeEventAsync(actionInstance, (TitleParameterDidChangeEvent) actionEvent);
                    break;

                //case EventTypes.DidReceiveSettings:
                //    await HandleDidReceiveSettingsEventAsync(actionInstance, (DidReceiveSettingsEvent) actionEvent);
                //    break;
            }
        }

        private static async Task HandleKeyEventAsync(StreamDeckAction actionInstance, KeyEvent keyEvent)
        {
            actionInstance.Coordinates = keyEvent.Payload.Coordinates;
            actionInstance.State = keyEvent.Payload.State;
            actionInstance.UserDesiredState = keyEvent.Payload.UserDesiredState;
            actionInstance.IsInMultiAction = keyEvent.Payload.IsInMultiAction;
            actionInstance.Settings = keyEvent.Payload.Settings;

            switch (keyEvent.Event)
            {
                case EventTypes.KeyDown:
                    await actionInstance.OnKeyDownAsync();
                    break;

                case EventTypes.KeyUp:
                    await actionInstance.OnKeyUpAsync();
                    break;
            }
        }

        private static async Task HandleAppearanceEventAsync(StreamDeckAction actionInstance, AppearanceEvent appearanceEvent)
        {
            actionInstance.Coordinates = appearanceEvent.Payload.Coordinates;
            actionInstance.State = appearanceEvent.Payload.State;
            actionInstance.IsInMultiAction = appearanceEvent.Payload.IsInMultiAction;
            actionInstance.Settings = appearanceEvent.Payload.Settings;

            switch (appearanceEvent.Event)
            {
                case EventTypes.WillAppear:
                    await actionInstance.WillAppearAsync();
                    break;

                case EventTypes.WillDisappear:
                    await actionInstance.WillDisappearAsync();
                    break;
            }
        }

        private static async Task HandleTitleParametersDidChangeEventAsync(StreamDeckAction actionInstance, TitleParameterDidChangeEvent titleParameterDidChangeEvent)
        {
            actionInstance.Coordinates = titleParameterDidChangeEvent.Payload.Coordinates;
            actionInstance.State = titleParameterDidChangeEvent.Payload.State;
            actionInstance.Settings = titleParameterDidChangeEvent.Payload.Settings;
            await actionInstance.TitleParametersDidChange(titleParameterDidChangeEvent.Payload.Title, titleParameterDidChangeEvent.Payload.TitleParameters);
        }

        private static async Task HandleDidReceiveSettingsEventAsync(StreamDeckAction actionInstance, DidReceiveSettingsEvent didReceiveSettingsEvent)
        {
            actionInstance.Coordinates = didReceiveSettingsEvent.Payload.Coordinates;
            actionInstance.IsInMultiAction = didReceiveSettingsEvent.Payload.IsInMultiAction;
            actionInstance.Settings = didReceiveSettingsEvent.Payload.Settings;
            await actionInstance.DidReceiveSettingsAsync();
        }
    }
}
