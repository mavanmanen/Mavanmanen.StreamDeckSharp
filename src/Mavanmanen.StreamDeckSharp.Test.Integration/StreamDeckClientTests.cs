using System;
using System.Reflection;
using Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents;
using Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents.Payloads;
using Mavanmanen.StreamDeckSharp.Internal.Messages;
using Mavanmanen.StreamDeckSharp.Payloads;
using Xunit;

namespace Mavanmanen.StreamDeckSharp.Test.Integration
{
    public class StreamDeckClientTests
    {
        [Fact]
        public async void RunAsync_ConnectionEstablished_SendsRegisterPluginMessageWithUUID()
        {
            // Setup
            var uuid = Guid.NewGuid().ToString("N");
            var emulator = new StreamDeckSoftwareEmulator(51364, uuid);
            string[] args = emulator.Start();
            var sut = new StreamDeckClient(Assembly.GetExecutingAssembly(), args);
            sut.RunAsync();
            await emulator.AwaitConnectionAsync();

            // Act
            var message = emulator.ReceiveMessage<RegisterPluginMessage>();

            // Assert
            Assert.Equal(MessageEventType.RegisterPlugin, message.Event);
            Assert.Equal(uuid, message.UUID);
        }

        [Fact]
        public async void OnKeyDownEvent_ReturnsShowOkMessage()
        {
            // Setup
            var emulator = new StreamDeckSoftwareEmulator(51364, Guid.NewGuid().ToString("N"));
            string[] args = emulator.Start();
            var sut = new StreamDeckClient(Assembly.GetExecutingAssembly(), args);
            sut.RunAsync();
            await emulator.AwaitConnectionAsync();

            // Act
            emulator.SendEvent(new KeyDownEvent("testAction", "context", "device", new KeyPayload(new Coordinates(0, 1), 0, 0, false)));
            var message = emulator.ReceiveMessage<ShowOkMessage>();

            // Assert
            Assert.Equal(MessageEventType.ShowOk, message.Event);
        }
    }
}