using Mavanmanen.StreamDeckSharp.Internal.Client;
using Mavanmanen.StreamDeckSharp.Internal.EventHandlers;
using Mavanmanen.StreamDeckSharp.Internal.Events;
using Mavanmanen.StreamDeckSharp.Internal.Events.PluginEvents;
using Moq;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Mavanmanen.StreamDeckSharp.Test.Internal.EventHandler
{
    public class PluginEventHandlerTests
    {
        private readonly Mock<TestPlugin> _mockPlugin = new Mock<TestPlugin>();
        private readonly PluginEventHandler _sut;

        public PluginEventHandlerTests()
        {
            _sut = new PluginEventHandler(_mockPlugin.Object, new ClientArguments(123, "", ""));
        }

        private static StreamDeckPluginEvent CreateEvent(EventType eventType, object payload = null)
        {
            var json = JObject.FromObject(new
            {
                @event = eventType.ToString("G"), 
                device = "device",
                payload
            }).ToString();

            return (StreamDeckPluginEvent) StreamDeckEvent.FromJson(json);
        }

        [Fact]
        public async void HandleEventAsync_DeviceDidConnectEvent_CallsCorrectMethod()
        {
            // Arrange
            _mockPlugin.Setup(p => p.DeviceDidConnectAsync());

            // Act
            await _sut.HandleEventAsync(CreateEvent(EventType.DeviceDidConnect));

            // Assert
            _mockPlugin.Verify(p => p.DeviceDidConnectAsync());
        }

        [Fact]
        public async void HandleEventAsync_DeviceDidDisconnectEvent_CallsCorrectMethod()
        {
            // Arrange
            _mockPlugin.Setup(p => p.DeviceDidDisconnectAsync());

            // Act
            await _sut.HandleEventAsync(CreateEvent(EventType.DeviceDidDisconnect));

            // Assert
            _mockPlugin.Verify(p => p.DeviceDidDisconnectAsync());
        }

        [Fact]
        public async void HandleEventAsync_ApplicationDidLaunchEvent_CallsCorrectMethod()
        {
            // Arrange
            _mockPlugin.Setup(p => p.ApplicationDidLaunchAsync(It.IsAny<string>()));

            // Act
            await _sut.HandleEventAsync(CreateEvent(EventType.ApplicationDidLaunch, new
            {
                application = "application"
            }));

            // Assert
            _mockPlugin.Verify(p => p.ApplicationDidLaunchAsync(It.IsAny<string>()));
        }

        [Fact]
        public async void HandleEventAsync_ApplicationDidTerminateEvent_CallsCorrectMethod()
        {
            // Arrange
            _mockPlugin.Setup(p => p.ApplicationDidTerminateAsync(It.IsAny<string>()));

            // Act
            await _sut.HandleEventAsync(CreateEvent(EventType.ApplicationDidTerminate, new
            {
                application = "application"
            }));

            // Assert
            _mockPlugin.Verify(p => p.ApplicationDidTerminateAsync(It.IsAny<string>()));
        }

        [Fact]
        public async void HandleEventAsync_DidReceiveGlobalSettingsEvent_CallsCorrectMethod()
        {
            // Arrange
            _mockPlugin.Setup(p => p.DidReceiveGlobalSettingsAsync(It.IsAny<JObject>()));

            // Act
            await _sut.HandleEventAsync(CreateEvent(EventType.DidReceiveGlobalSettings, new
            {
                settings = new JObject()
            }));

            // Assert
            _mockPlugin.Verify(p => p.DidReceiveGlobalSettingsAsync(It.IsAny<JObject>()));
        }

        [Fact]
        public async void HandleEventAsync_SystemDidWakeUpEvent_CallsCorrectMethod()
        {
            // Arrange
            _mockPlugin.Setup(p => p.SystemDidWakeUpAsync());

            // Act
            await _sut.HandleEventAsync(CreateEvent(EventType.SystemDidWakeUp));

            // Assert
            _mockPlugin.Verify(p => p.SystemDidWakeUpAsync());
        }
    }
}
