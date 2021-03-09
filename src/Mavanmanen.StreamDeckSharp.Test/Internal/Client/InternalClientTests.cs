using System.Threading.Tasks;
using ApprovalTests;
using ApprovalTests.Reporters;
using Mavanmanen.StreamDeckSharp.Enum;
using Mavanmanen.StreamDeckSharp.Internal.Client;
using Mavanmanen.StreamDeckSharp.Internal.Messages;
using Moq;
using Xunit;

namespace Mavanmanen.StreamDeckSharp.Test.Internal.Client
{
    [UseReporter(typeof(DiffReporter))]
    public class InternalClientTests
    {
        private static readonly Mock<IWebSocketClient> _mockWebSocketClient = new Mock<IWebSocketClient>();
        private readonly InternalClient _sut;

        public InternalClientTests()
        {
            _sut = new InternalClient(new ClientArguments(0, "", ""), _mockWebSocketClient.Object);
        }

        private async Task<string> SendAndReceiveMessageAsync(Message message)
        {
            string sentJson = string.Empty;
            _mockWebSocketClient
                .Setup(wsc => wsc.SendAsync(It.IsAny<string>()))
                .Callback<string>(json => sentJson = json);

            await _sut.SendAsync(message);

            return sentJson;
        }
        [Fact]
        public async void SendAsync_LogMessage_SerializesMessageCorrectly()
        {
            // Arrange
            var message = new LogMessage("message");

            // Act
            string result = await SendAndReceiveMessageAsync(message);

            // Assert
            Approvals.Verify(result);
        }

        [Fact]
        public async void SendAsync_OpenUrlMessage_SerializesMessageCorrectly()
        {
            // Arrange
            var message = new OpenUrlMessage("url");

            // Act
            string result = await SendAndReceiveMessageAsync(message);

            // Assert
            Approvals.Verify(result);
        }

        [Fact]
        public async void SendAsync_RegisterEventMessage_SerializesMessageCorrectly()
        {
            // Arrange
            var message = new RegisterEventMessage("eventName", "uuid");

            // Act
            string result = await SendAndReceiveMessageAsync(message);

            // Assert
            Approvals.Verify(result);
        }

        [Fact]
        public async void SendAsync_SendToPropertyInspectorMessage_SerializesMessageCorrectly()
        {
            // Arrange
            var message = new SendToPropertyInspectorMessage("context", new {payload = "payload"});

            // Act
            string result = await SendAndReceiveMessageAsync(message);

            // Assert
            Approvals.Verify(result);
        }

        [Fact]
        public async void SendAsync_SetGlobalSettingsMessage_SerializesMessageCorrectly()
        {
            // Arrange
            var message = new SetGlobalSettingsMessage("context", new {payload = "payload"});

            // Act
            string result = await SendAndReceiveMessageAsync(message);

            // Assert
            Approvals.Verify(result);
        }

        [Fact]
        public async void SendAsync_SetImageMessage_SerializesMessageCorrectly()
        {
            // Arrange
            var message = new SetImageMessage("context", "base64Image", Target.Both, 0);

            // Act
            string result = await SendAndReceiveMessageAsync(message);

            // Assert
            Approvals.Verify(result);
        }

        [Fact]
        public async void SendAsync_SetSettingsMessage_SerializesMessageCorrectly()
        {
            // Arrange
            var message = new SetSettingsMessage("context", new {payload = "payload"});

            // Act
            string result = await SendAndReceiveMessageAsync(message);

            // Assert
            Approvals.Verify(result);
        }

        [Fact]
        public async void SendAsync_SetStateMessage_SerializesMessageCorrectly()
        {
            // Arrange
            var message = new SetStateMessage("context", 1);

            // Act
            string result = await SendAndReceiveMessageAsync(message);

            // Assert
            Approvals.Verify(result);
        }

        [Fact]
        public async void SendAsync_SetTitleMessage_SerializesMessageCorrectly()
        {
            // Arrange
            var message = new SetTitleMessage("context", "title", Target.Both, 0);

            // Act
            string result = await SendAndReceiveMessageAsync(message);

            // Assert
            Approvals.Verify(result);
        }

        [Fact]
        public async void SendAsync_ShowAlertMessage_SerializesMessageCorrectly()
        {
            // Arrange
            var message = new ShowAlertMessage("context");

            // Act
            string result = await SendAndReceiveMessageAsync(message);

            // Assert
            Approvals.Verify(result);
        }

        [Fact]
        public async void SendAsync_ShowOkMessage_SerializesMessageCorrectly()
        {
            // Arrange
            var message = new ShowOkMessage("context");

            // Act
            string result = await SendAndReceiveMessageAsync(message);

            // Assert
            Approvals.Verify(result);
        }

        [Fact]
        public async void SendAsync_SwitchToProfileMessage_SerializesMessageCorrectly()
        {
            // Arrange
            var message = new SwitchToProfileMessage("context", "device", "profileName");

            // Act
            string result = await SendAndReceiveMessageAsync(message);

            // Assert
            Approvals.Verify(result);
        }
    }
}
