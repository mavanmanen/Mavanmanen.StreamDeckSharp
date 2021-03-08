using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Mavanmanen.StreamDeckSharp.Attributes;
using Mavanmanen.StreamDeckSharp.Enum;
using Mavanmanen.StreamDeckSharp.Internal;
using Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents;
using Mavanmanen.StreamDeckSharp.Internal.Events.PluginEvents;
using Mavanmanen.StreamDeckSharp.Internal.Manifest;
using Mavanmanen.StreamDeckSharp.Internal.Messages;
using Mavanmanen.StreamDeckSharp.Internal.PropertyInspector;
using Microsoft.Extensions.DependencyInjection;

namespace Mavanmanen.StreamDeckSharp
{
    public class StreamDeckClient : IPluginClient, IActionClient
    {
        private readonly InternalClient? _client;
        private readonly ServiceProvider _services;

        public StreamDeckClient(string[] args)
        {
            var services = new ServiceCollection();

            RegisterPlugin(services);
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            RegisterPluginServices(services, serviceProvider);
            RegisterActions(services);

            ClientArguments? clientArguments = ClientArguments.ParseFromArgs(args);
            services.AddSingleton(clientArguments);
            services.AddSingleton<IPluginClient>(this);
            services.AddSingleton<IActionClient>(this);
            services.AddTransient<ActionEventHandler>();
            services.AddTransient<PluginEventHandler>();


            if (!args.Any())
            {
                services.AddSingleton<ManifestGenerator>();
                services.AddSingleton<PropertyInspectorGenerator>();

                _services = services.BuildServiceProvider();

                var manifestGenerator = _services.GetRequiredService<ManifestGenerator>();
                manifestGenerator.GenerateManifest();

                var propertyInspectorGenerator = _services.GetRequiredService<PropertyInspectorGenerator>();
                propertyInspectorGenerator.GeneratePropertyInspectors();

                return;
            }

            _services = services.BuildServiceProvider();
            _client = new InternalClient(clientArguments);
            _client.ActionEventReceived += HandleActionEventAsync;
            _client.PluginEventReceived += HandlePluginEventAsync;
        }

        public async Task RunAsync()
        {
            if (_client == null)
            {
                return;
            }

            await _client.RunAsync();
        }

        private static void RegisterActions(IServiceCollection services)
        {
            List<ActionDefinition> actions = Assembly.GetEntryAssembly()!.GetTypes()
                .Where(t => t.GetCustomAttribute<StreamDeckActionAttribute>() != null)
                .Select(t => new ActionDefinition(t))
                .ToList();

            services.AddSingleton(actions);
            foreach (var action in actions)
            {
                services.AddTransient(action.Type, action.Type);
            }
        }

        private static void RegisterPlugin(IServiceCollection services)
        {
            Type? pluginType = Assembly.GetEntryAssembly()!.GetTypes().FirstOrDefault(t => t.GetCustomAttribute<StreamDeckPluginAttribute>() != null);

            if (pluginType == null)
            {
                throw new ApplicationException("Plugin not found.");
            }

            var pluginDefinition = new PluginDefinition(pluginType);
            services.AddSingleton(pluginDefinition);
            services.AddTransient(typeof(StreamDeckPlugin), pluginDefinition.Type);
        }

        private static void RegisterPluginServices(IServiceCollection services, IServiceProvider serviceProvider)
        {
            using IServiceScope scope = serviceProvider.CreateScope();
            StreamDeckPlugin plugin = scope.ServiceProvider.GetRequiredService<StreamDeckPlugin>();
            plugin.RegisterServices(services);
        }

        private async void HandleActionEventAsync(object? _, StreamDeckActionEvent e)
        {
            using IServiceScope scope = _services.CreateScope();
            using var handler = scope.ServiceProvider.GetRequiredService<ActionEventHandler>();
            await handler.HandleEventAsync(e);
        }

        private async void HandlePluginEventAsync(object? _, StreamDeckPluginEvent e)
        {
            using IServiceScope scope = _services.CreateScope();
            using var handler = _services.GetRequiredService<PluginEventHandler>();
            await handler.HandleEventAsync(e);
        }

        public async Task SetSettingsAsync(string context, object payload) => await _client!.SendAsync(new SetSettingsMessage(context, payload));
        public async Task SetTitleAsync(string context, string title, Target? target = null, int? state = null) => await _client!.SendAsync(new SetTitleMessage(context, title, target, state));
        public async Task SetImageAsync(string context, string? base64Image, Target? target = null, int? state = null) => await _client!.SendAsync(new SetImageMessage(context, base64Image, target, state));
        public async Task ShowAlertAsync(string context) => await _client!.SendAsync(new ShowAlertMessage(context));
        public async Task ShowOkAsync(string context) => await _client!.SendAsync(new ShowOkMessage(context));
        public async Task SetStateAsync(string context, int state) => await _client!.SendAsync(new SetStateMessage(context, state));
        public async Task SendToPropertyInspectorAsync(string context, object payload) => await _client!.SendAsync(new SendToPropertyInspectorMessage(context, payload));
        public async Task OpenUrlAsync(string url) => await _client!.SendAsync(new OpenUrlMessage(url));
        public async Task SetGlobalSettings(string context, object payload) => await _client!.SendAsync(new SetGlobalSettingsMessage(context, payload));
        public async Task LogMessageAsync(string message) => await _client!.SendAsync(new LogMessage(message));
        public async Task SwitchToProfileAsync(string context, string device, string? profileName) => await _client!.SendAsync(new SwitchToProfileMessage(context, device, profileName));
    }
}