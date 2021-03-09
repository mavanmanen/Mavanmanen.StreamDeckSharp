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

        private static async Task<string> GetEmbeddedJsonAsync(EventTypes eventType)
        {
            await using Stream stream = Assembly
                .GetExecutingAssembly()
                .GetManifestResourceStream($"Mavanmanen.StreamDeckSharp.Test.Internal.Events.Input.{eventType:G}.json");

            using var streamReader = new StreamReader(stream!);
            return await streamReader.ReadToEndAsync();
        }

        [Theory]
        [InlineData(EventTypes.KeyDown)]
        [InlineData(EventTypes.KeyUp)]
        [InlineData(EventTypes.WillAppear)]
        [InlineData(EventTypes.WillDisappear)]
        [InlineData(EventTypes.TitleParametersDidChange)]
        [InlineData(EventTypes.DeviceDidConnect)]
        [InlineData(EventTypes.DeviceDidDisconnect)]
        [InlineData(EventTypes.ApplicationDidLaunch)]
        [InlineData(EventTypes.ApplicationDidTerminate)]
        [InlineData(EventTypes.SendToPlugin)]
        [InlineData(EventTypes.DidReceiveSettings)]
        [InlineData(EventTypes.DidReceiveGlobalSettings)]
        [InlineData(EventTypes.PropertyInspectorDidAppear)]
        [InlineData(EventTypes.PropertyInspectorDidDisappear)]
        [InlineData(EventTypes.SystemDidWakeUp)]
        private async void FromJson_WithInput_ParsesCorrectly(EventTypes eventType)
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
