using System.Threading.Tasks;
using Mavanmanen.StreamDeckSharp.Attributes;
using Newtonsoft.Json.Linq;

namespace Mavanmanen.StreamDeckSharp.Test.Integration
{
    [StreamDeckPlugin("name", "icon", "author", "description", "1.0")]
    public class TestPlugin : StreamDeckPlugin
    {
        public override Task DeviceDidConnectAsync() => LogMessageAsync("ok");
        public override Task DeviceDidDisconnectAsync() => LogMessageAsync("ok");
        public override Task ApplicationDidLaunchAsync(string application) => LogMessageAsync("ok");
        public override Task ApplicationDidTerminateAsync(string application) => LogMessageAsync("ok");
        public override Task SystemDidWakeUpAsync() => LogMessageAsync("ok");
        public override Task DidReceiveGlobalSettingsAsync(JObject settings) => LogMessageAsync("ok");
    }
}