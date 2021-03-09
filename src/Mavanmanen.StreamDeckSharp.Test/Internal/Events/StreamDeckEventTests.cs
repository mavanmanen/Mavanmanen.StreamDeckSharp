using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using ApprovalTests.Reporters;
using Mavanmanen.StreamDeckSharp.Internal.Events;
using Mavanmanen.StreamDeckSharp.Test.TestHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Mavanmanen.StreamDeckSharp.Test.Internal.Events
{
    [UseReporter(typeof(DiffReporter))]
    public class StreamDeckEventTests : XunitApprovalBase
    {
        public StreamDeckEventTests(ITestOutputHelper output) : base(output)
        {
        }

        private static async Task<string> GetEmbeddedJsonAsync(EventType eventType)
        {
            await using Stream stream = Assembly
                .GetExecutingAssembly()
                .GetManifestResourceStream($"Mavanmanen.StreamDeckSharp.Test.Internal.Events.Input.{eventType:G}.json");

            using var streamReader = new StreamReader(stream!);
            return await streamReader.ReadToEndAsync();
        }

        [Theory]
        [InlineData(EventType.KeyDown)]
        [InlineData(EventType.KeyUp)]
        [InlineData(EventType.WillAppear)]
        [InlineData(EventType.WillDisappear)]
        [InlineData(EventType.TitleParametersDidChange)]
        [InlineData(EventType.DeviceDidConnect)]
        [InlineData(EventType.DeviceDidDisconnect)]
        [InlineData(EventType.ApplicationDidLaunch)]
        [InlineData(EventType.ApplicationDidTerminate)]
        [InlineData(EventType.SendToPlugin)]
        [InlineData(EventType.DidReceiveSettings)]
        [InlineData(EventType.DidReceiveGlobalSettings)]
        [InlineData(EventType.PropertyInspectorDidAppear)]
        [InlineData(EventType.PropertyInspectorDidDisappear)]
        [InlineData(EventType.SystemDidWakeUp)]
        private async void FromJson_WithInput_ParsesCorrectly(EventType eventType)
        {
            // Arrange
            string json = await GetEmbeddedJsonAsync(eventType);

            // Act
            StreamDeckEvent streamDeckEvent = StreamDeckEvent.FromJson(json);

            // Assert
            Assert.NotNull(streamDeckEvent);
            Assert.Equal(eventType, streamDeckEvent.Event);
            StreamDeckApprovals.VerifyObject(streamDeckEvent);
        }
    }
}
