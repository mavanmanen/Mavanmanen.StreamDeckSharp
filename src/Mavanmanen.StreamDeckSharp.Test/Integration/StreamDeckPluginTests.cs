using System;
using Mavanmanen.StreamDeckSharp.Internal.Events.PluginEvents;
using Mavanmanen.StreamDeckSharp.Internal.Events.PluginEvents.Payloads;
using Mavanmanen.StreamDeckSharp.Internal.Messages;
using Xunit;

namespace Mavanmanen.StreamDeckSharp.Test.Integration
{
    [Trait("Category", "Integration")]
    [Collection("Integration")]
    public class StreamDeckPluginTests : IntegrationTestBase
    {
        [Fact]
        public async void Plugin_OnDeviceDidConnectEvent_ReturnsShowOkMessage()
        {
            // Setup
            var uuid = Guid.NewGuid().ToString("N");
            (StreamDeckSoftwareEmulator emulator, StreamDeckClient client) = await ConnectAsync(51364, uuid);
            var streamDeckEvent = new DeviceDidConnectEvent("device", new DeviceInfo(DeviceType.StreamDeck, new DeviceSize(5, 3)));

            using (emulator)
            using (client)
            {
                // Act
                emulator.SendEvent(streamDeckEvent);
                var message = emulator.ReceiveMessage<LogMessage>();

                // Assert
                Assert.Equal(MessageEventType.LogMessage, message.Event);
                Assert.Equal("ok", message.Payload.Message);
            }
        }
    }
}
