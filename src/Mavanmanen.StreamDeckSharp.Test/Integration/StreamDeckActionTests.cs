using System;
using Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents;
using Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents.Payloads;
using Mavanmanen.StreamDeckSharp.Internal.Messages;
using Mavanmanen.StreamDeckSharp.Payloads;
using Xunit;

namespace Mavanmanen.StreamDeckSharp.Test.Integration
{
    [Trait("Category", "Integration")]
    [Collection("Integration")]
    public class StreamDeckActionTests : IntegrationTestBase
    {
        [Fact]
        public async void Action_OnKeyDownEvent_ReturnsShowOkMessage()
        {
            // Setup
            var uuid = Guid.NewGuid().ToString("N");
            (StreamDeckSoftwareEmulator emulator, StreamDeckClient client) = await ConnectAsync(51364, uuid);
            var streamDeckEvent = new KeyDownEvent("testAction", "context", "device", new KeyPayload(new Coordinates(0, 1), 0, 0, false));

            using (emulator)
            using (client)
            {
                // Act
                emulator.SendEvent(streamDeckEvent);
                var message = emulator.ReceiveMessage<ShowOkMessage>();

                // Assert
                Assert.Equal(MessageEventType.ShowOk, message.Event);
            }
        }

        [Fact]
        public async void Action_OnKeyUpEvent_ReturnsShowOkMessage()
        {
            // Setup
            var uuid = Guid.NewGuid().ToString("N");
            (StreamDeckSoftwareEmulator emulator, StreamDeckClient client) = await ConnectAsync(51364, uuid);
            var streamDeckEvent = new KeyUpEvent("testAction", "context", "device", new KeyPayload(new Coordinates(0, 1), 0, 0, false));

            using (emulator)
            using (client)
            {
                // Act
                emulator.SendEvent(streamDeckEvent);
                var message = emulator.ReceiveMessage<ShowOkMessage>();

                // Assert
                Assert.Equal(MessageEventType.ShowOk, message.Event);
            }
        }

        [Fact]
        public async void Action_OnWillAppearEvent_ReturnsShowOkMessage()
        {
            // Setup
            var uuid = Guid.NewGuid().ToString("N");
            (StreamDeckSoftwareEmulator emulator, StreamDeckClient client) = await ConnectAsync(51364, uuid);
            var streamDeckEvent = new WillAppearEvent("testAction", "context", "device", new AppearancePayload(new Coordinates(0, 0), 0, false));

            using (emulator)
            using (client)
            {
                // Act
                emulator.SendEvent(streamDeckEvent);
                var message = emulator.ReceiveMessage<ShowOkMessage>();

                // Assert
                Assert.Equal(MessageEventType.ShowOk, message.Event);
            }
        }

        [Fact]
        public async void Action_OnWillDisappearEvent_ReturnsShowOkMessage()
        {
            // Setup
            var uuid = Guid.NewGuid().ToString("N");
            (StreamDeckSoftwareEmulator emulator, StreamDeckClient client) = await ConnectAsync(51364, uuid);
            var streamDeckEvent = new WillDisappearEvent("testAction", "context", "device", new AppearancePayload(new Coordinates(0, 0), 0, false));

            using (emulator)
            using (client)
            {
                // Act
                emulator.SendEvent(streamDeckEvent);
                var message = emulator.ReceiveMessage<ShowOkMessage>();

                // Assert
                Assert.Equal(MessageEventType.ShowOk, message.Event);
            }
        }

        [Fact]
        public async void Action_OnTitleParametersDidChangeEvent_ReturnsShowOkMessage()
        {
            // Setup
            var uuid = Guid.NewGuid().ToString("N");
            (StreamDeckSoftwareEmulator emulator, StreamDeckClient client) = await ConnectAsync(51364, uuid);
            var streamDeckEvent = new TitleParameterDidChangeEvent("testAction", "context", "device", new TitleParametersPayload(new Coordinates(0, 0), 0, "title", new TitleParameters()));

            using (emulator)
            using (client)
            {
                // Act
                emulator.SendEvent(streamDeckEvent);
                var message = emulator.ReceiveMessage<ShowOkMessage>();

                // Assert
                Assert.Equal(MessageEventType.ShowOk, message.Event);
            }
        }

        [Fact]
        public async void Action_OnPropertyInspectorDidAppearEvent_ReturnsShowOkMessage()
        {
            // Setup
            var uuid = Guid.NewGuid().ToString("N");
            (StreamDeckSoftwareEmulator emulator, StreamDeckClient client) = await ConnectAsync(51364, uuid);
            var streamDeckEvent = new PropertyInspectorDidAppearEvent("testAction", "context", "device");

            using (emulator)
            using (client)
            {
                // Act
                emulator.SendEvent(streamDeckEvent);
                var message = emulator.ReceiveMessage<ShowOkMessage>();

                // Assert
                Assert.Equal(MessageEventType.ShowOk, message.Event);
            }
        }

        [Fact]
        public async void Action_OnPropertyInspectorDidDisappearEvent_ReturnsShowOkMessage()
        {
            // Setup
            var uuid = Guid.NewGuid().ToString("N");
            (StreamDeckSoftwareEmulator emulator, StreamDeckClient client) = await ConnectAsync(51364, uuid);
            var streamDeckEvent = new PropertyInspectorDidAppearEvent("testAction", "context", "device");

            using (emulator)
            using (client)
            {
                // Act
                emulator.SendEvent(streamDeckEvent);
                var message = emulator.ReceiveMessage<ShowOkMessage>();

                // Assert
                Assert.Equal(MessageEventType.ShowOk, message.Event);
            }
        }
    }
}