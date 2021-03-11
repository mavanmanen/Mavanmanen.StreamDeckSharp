using System.Collections.Generic;
using ApprovalTests;
using ApprovalTests.Reporters;
using Mavanmanen.StreamDeckSharp.Attributes;
using Mavanmanen.StreamDeckSharp.Enum;
using Mavanmanen.StreamDeckSharp.Internal.Definitions;
using Mavanmanen.StreamDeckSharp.Internal.Manifest;
using Xunit;
using Xunit.Abstractions;

namespace Mavanmanen.StreamDeckSharp.Test.Internal.Manifest
{
    [Trait("Category", "Unit Tests")]
    [UseReporter(typeof(DiffReporter))]
    public class ManifestGeneratorTests : XunitApprovalBase
    {
        public ManifestGeneratorTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void GenerateManifest_GeneratesCorrectManifest()
        {
            // Arrange
            var plugin = new PluginDefinition(typeof(Plugin));
            var actions = new List<ActionDefinition>
            {
                new ActionDefinition(typeof(Action))
            };
            var sut = new ManifestGenerator(plugin, actions);

            // Act
            string manifestJson = sut.GenerateManifest();

            // Assert
            Approvals.Verify(manifestJson);
        }
    }

    [StreamDeckPlugin("pluginName", "icon", "author", "description", "1.0", "url", "category", "categoryIcon", defaultWindowSize: "560,120")]
    [StreamDeckMinimumOsVersion("windowsMinimumVersion", "macMinimumVersion")]
    [StreamDeckApplicationsToMonitor(new []{ "notepad.exe" }, new []{ "notepad" })]
    [StreamDeckProfile("profile", DeviceType.StreamDeck, true, true)]
    public class Plugin : StreamDeckPlugin
    {

    }

    [StreamDeckAction("name", "icon", "tooltip", supportedInMultiActions: true, visibleInActionsList: true)]
    [StreamDeckActionState("image", "state1", "multiActionImage", "state1", false, "#000000", TitleAlignment.Middle, FontFamily.Arial, FontStyle.Bold, "12", false)]
    [StreamDeckActionState("image", "state2", "multiActionImage", "state2", false, "#000000", TitleAlignment.Middle, FontFamily.Arial, FontStyle.Bold, "12", false)]
    public class Action : StreamDeckAction
    {

    }
}
