using System;
using System.Collections.Generic;
using Mavanmanen.StreamDeckSharp.Internal.Client;
using Mavanmanen.StreamDeckSharp.Internal.Definitions;
using Mavanmanen.StreamDeckSharp.Internal.EventHandlers;
using Mavanmanen.StreamDeckSharp.Internal.Events;
using Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents;
using Mavanmanen.StreamDeckSharp.Payloads;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Mavanmanen.StreamDeckSharp.Test.Internal.EventHandler
{
    public class ActionEventHandlerTests
    {
        private static readonly Mock<TestAction> _mockAction = new Mock<TestAction>();
        private static readonly Mock<IActionClient> _mockActionClient = new Mock<IActionClient>();
        private static readonly Mock<IServiceProvider> _mockServiceProvider = new Mock<IServiceProvider>();
        private static readonly Mock<IServiceScopeFactory> _mockServiceScopeFactory = new Mock<IServiceScopeFactory>();
        private static readonly Mock<IServiceScope> _mockServiceScope = new Mock<IServiceScope>();
        private static readonly List<ActionDefinition> _actions = new List<ActionDefinition>
        {
            new ActionDefinition(typeof(TestAction))
        };
        private static readonly ClientArguments _clientArguments = new ClientArguments(0, "", "");
        
        private readonly ActionEventHandler _sut;

        public ActionEventHandlerTests()
        {
            _mockServiceProvider
                .Setup(sp => sp.GetService(typeof(TestAction)))
                .Returns(_mockAction.Object);

            _mockServiceProvider
                .Setup(sp => sp.GetService(typeof(IActionClient)))
                .Returns(_mockActionClient.Object);

            _mockServiceProvider
                .Setup(sp => sp.GetService(typeof(IServiceScopeFactory)))
                .Returns(_mockServiceScopeFactory.Object);

            _mockServiceScopeFactory
                .Setup(ssf => ssf.CreateScope())
                .Returns(_mockServiceScope.Object);

            _mockServiceScope
                .Setup(ss => ss.ServiceProvider)
                .Returns(_mockServiceProvider.Object);

            _sut = new ActionEventHandler(
                _mockServiceProvider.Object, 
                _actions, 
                _clientArguments);
        }

        private static StreamDeckActionEvent CreateEvent(EventType eventType)
        {
            var json = JObject.FromObject(new
            {
                action = "testAction",
                @event = eventType.ToString("G"),
                context = "context",
                device = "device",
                payload = new
                {
                    coordinates = new
                    {
                        column = 0,
                        row = 0
                    },
                    state = 0,
                    userDesiredState = 0,
                    isInMultiAction = false
                }
            }).ToString();

            return (StreamDeckActionEvent) StreamDeckEvent.FromJson(json);
        }

        [Fact]
        public async void HandleEventAsync_KeyDownEvent_CallsCorrectMethod()
        {
            // Arrange
            _mockAction.Setup(a => a.OnKeyDownAsync());

            // Act
            await _sut.HandleEventAsync(CreateEvent(EventType.KeyDown));

            // Assert
            _mockAction.Verify(a => a.OnKeyDownAsync());
        }

        [Fact]
        public async void HandleEventAsync_KeyUpEvent_CallsCorrectMethod()
        {
            // Arrange
            _mockAction.Setup(a => a.OnKeyUpAsync());

            // Act
            await _sut.HandleEventAsync(CreateEvent(EventType.KeyUp));

            // Assert
            _mockAction.Verify(a => a.OnKeyUpAsync());
        }

        [Fact]
        public async void HandleEventAsync_WillAppearEvent_CallsCorrectMethod()
        {
            // Arrange
            _mockAction.Setup(a => a.WillAppearAsync());

            // Act
            await _sut.HandleEventAsync(CreateEvent(EventType.WillAppear));

            // Assert
            _mockAction.Verify(a => a.WillAppearAsync());
        }

        [Fact]
        public async void HandleEventAsync_WillDisappearEvent_CallsCorrectMethod()
        {
            // Arrange
            _mockAction.Setup(a => a.WillDisappearAsync());

            // Act
            await _sut.HandleEventAsync(CreateEvent(EventType.WillDisappear));

            // Assert
            _mockAction.Verify(a => a.WillDisappearAsync());
        }

        [Fact]
        public async void HandleEventAsync_TitleParameterDidChangeEvent_CallsCorrectMethod()
        {
            // Arrange
            _mockAction.Setup(a => a.TitleParametersDidChangeAsync(It.IsAny<string>(), It.IsAny<TitleParameters>()));

            // Act
            await _sut.HandleEventAsync(CreateEvent(EventType.TitleParametersDidChange));

            // Assert
            _mockAction.Verify(a => a.TitleParametersDidChangeAsync(It.IsAny<string>(), It.IsAny<TitleParameters>()));
        }

        [Fact]
        public async void HandleEventAsync_PropertyInspectorDidAppearEvent_CallsCorrectMethod()
        {
            // Arrange
            _mockAction.Setup(a => a.PropertyInspectorDidAppearAsync());

            // Act
            await _sut.HandleEventAsync(CreateEvent(EventType.PropertyInspectorDidAppear));

            // Assert
            _mockAction.Verify(a => a.PropertyInspectorDidAppearAsync());
        }

        [Fact]
        public async void HandleEventAsync_PropertyInspectorDidDisappearEvent_CallsCorrectMethod()
        {
            // Arrange
            _mockAction.Setup(a => a.PropertyInspectorDidDisappearAsync());

            // Act
            await _sut.HandleEventAsync(CreateEvent(EventType.PropertyInspectorDidDisappear));

            // Assert
            _mockAction.Verify(a => a.PropertyInspectorDidDisappearAsync());
        }
    }
}
