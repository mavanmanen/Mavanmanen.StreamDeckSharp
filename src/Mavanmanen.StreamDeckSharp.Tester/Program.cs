using System.Diagnostics;
using System.Threading.Tasks;
using Mavanmanen.StreamDeckSharp.Attributes;
using Mavanmanen.StreamDeckSharp.PropertyInspector;

namespace Mavanmanen.StreamDeckSharp.Tester
{
    [StreamDeckPlugin("tester", "Images/pluginIcon", "mavanmanen", "tester plugin", "1.0")]
    [StreamDeckMinimumOsVersion("10", "10.11")]
    public class Program : StreamDeckPlugin
    {
        public static async Task Main(string[] args)
        {
#if DEBUG
            Debugger.Launch();
#endif

            var client = new StreamDeckClient(args);
            await client.RunAsync();
        }

        public override async Task DeviceDidConnectAsync()
        {

        }
    }

    [StreamDeckAction("streamdeckaction", "defaultImage")]
    [StreamDeckActionState("Images/defaultImage")]
    [StreamDeckPropertyInspector(typeof(Settings))]
    public class TestAction : StreamDeckAction
    {
        public override async Task OnKeyDownAsync()
        {
            var settings = GetSettings<Settings>();
        }
    }

    public class Settings
    {
        [PropertyInspectorText]
        public string Text { get; set; }

        [PropertyInspectorTextArea]
        public string TextArea { get; set; }

        [PropertyInspectorSelect]
        [PropertyInspectorSelectOption("Option1", "1")]
        [PropertyInspectorSelectOption("Option2", "2")]
        public string Select { get; set; }
    }
}
