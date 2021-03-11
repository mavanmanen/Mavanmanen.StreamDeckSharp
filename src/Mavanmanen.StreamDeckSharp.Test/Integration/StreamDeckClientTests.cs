using System;
using Mavanmanen.StreamDeckSharp.Internal.Messages;
using Xunit;

namespace Mavanmanen.StreamDeckSharp.Test.Integration
{
    [Trait("Category", "Integration")]
    [Collection("Integration")]
    public class StreamDeckClientTests : IntegrationTestBase
    {
        [Fact]
        public async void Client_RunAsync_SendsRegisterPluginMessageWithUUID()
        {
            // Setup
            var uuid = Guid.NewGuid().ToString("N");
            (StreamDeckSoftwareEmulator emulator, StreamDeckClient client) = await ConnectAsync(51364, uuid);

            using(emulator)
            using (client)
            {
                // Act
                var message = emulator.ReceiveMessage<RegisterPluginMessage>();

                // Assert
                Assert.Equal(MessageEventType.RegisterPlugin, message.Event);
                Assert.Equal(uuid, message.UUID);
            }
        }
    }
}