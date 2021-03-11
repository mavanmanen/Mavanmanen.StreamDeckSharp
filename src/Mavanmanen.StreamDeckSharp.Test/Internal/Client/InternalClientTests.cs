using System.Threading.Tasks;
using ApprovalTests;
using ApprovalTests.Reporters;
using Mavanmanen.StreamDeckSharp.Enum;
using Mavanmanen.StreamDeckSharp.Internal.Client;
using Mavanmanen.StreamDeckSharp.Internal.Messages;
using Mavanmanen.StreamDeckSharp.Internal.Messages.Payloads;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace Mavanmanen.StreamDeckSharp.Test.Internal.Client
{
    [Trait("Category", "Unit Tests")]
    [UseReporter(typeof(DiffReporter))]
    public class InternalClientTests : XunitApprovalBase
    {
        private static readonly Mock<IWebSocketClient> _mockWebSocketClient = new Mock<IWebSocketClient>();
        private readonly InternalClient _sut;

        public InternalClientTests(ITestOutputHelper output) : base(output)
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
            var message = new LogMessage(new LogMessagePayload("message"));

            // Act
            string result = await SendAndReceiveMessageAsync(message);

            // Assert
            Approvals.Verify(result);
        }

        [Fact]
        public async void SendAsync_OpenUrlMessage_SerializesMessageCorrectly()
        {
            // Arrange
            var message = new OpenUrlMessage(new OpenUrlPayload("url"));

            // Act
            string result = await SendAndReceiveMessageAsync(message);

            // Assert
            Approvals.Verify(result);
        }

        [Fact]
        public async void SendAsync_RegisterEventMessage_SerializesMessageCorrectly()
        {
            // Arrange
            var message = new RegisterPluginMessage("uuid");

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
            var message = new SetImageMessage("context", new SetImagePayload("base64Image", Target.Both, 0));

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
            var message = new SetStateMessage("context", new SetStatePayload(1));

            // Act
            string result = await SendAndReceiveMessageAsync(message);

            // Assert
            Approvals.Verify(result);
        }

        [Fact]
        public async void SendAsync_SetTitleMessage_SerializesMessageCorrectly()
        {
            // Arrange
            var message = new SetTitleMessage("context", new SetTitlePayload("title", Target.Both, 0));

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
            var message = new SwitchToProfileMessage("context", "device", new SwitchToProfilePayload("profileName"));

            // Act
            string result = await SendAndReceiveMessageAsync(message);

            // Assert
            Approvals.Verify(result);
        }
    }
}
