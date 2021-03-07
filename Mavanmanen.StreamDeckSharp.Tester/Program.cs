using System.Diagnostics;
using System.Threading.Tasks;
using Mavanmanen.StreamDeckSharp.Attributes;

namespace Mavanmanen.StreamDeckSharp.Tester
{
    [StreamDeckPlugin("tester", "Images/pluginIcon", "mavanmanen", "tester plugin", "1.0")]
    [StreamDeckMinimumOsVersion("10", "10.11")]
    public class Program : StreamDeckPlugin
    {
        public static async Task Main(string[] args)
        {
            Debugger.Launch();

            var client = new StreamDeckClient(args);
            await client.RunAsync();
        }

        public override async Task DeviceDidConnectAsync()
        {

        }
    }

    [StreamDeckAction("streamdeckaction", "defaultImage")]
    [StreamDeckActionState("Images/defaultImage")]
    public class TestAction : StreamDeckAction
    {
        public override Task OnKeyDownAsync()
        {

        }
    }
}
