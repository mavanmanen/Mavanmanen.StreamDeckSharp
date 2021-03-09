using System.Collections.Generic;
using ApprovalTests;
using ApprovalTests.Reporters;
using Mavanmanen.StreamDeckSharp.Attributes;
using Mavanmanen.StreamDeckSharp.Enum;
using Mavanmanen.StreamDeckSharp.Internal.Definitions;
using Mavanmanen.StreamDeckSharp.Internal.Manifest;
using Xunit;

namespace Mavanmanen.StreamDeckSharp.Test.Manifest
{
    [UseReporter(typeof(DiffReporter))]
    public class ManifestGeneratorTests
    {
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

    [StreamDeckPlugin("pluginName", "icon", "author", "description", "version", "url", "category", "categoryIcon", defaultWindowSize: "560,120")]
    [StreamDeckMinimumOsVersion("windowsMinimumVersion", "macMinimumVersion")]
    [StreamDeckApplicationsToMonitor(new []{ "notepad.exe" }, new []{ "notepad" })]
    [StreamDeckProfile("profile", DeviceType.StreamDeck, true, true)]
    public class Plugin : StreamDeckPlugin
    {

    }

    [StreamDeckAction("name", "icon", "tooltip", supportedInMultiActions: true, visibleInActionsList: true)]
    [StreamDeckActionState("image", "state1", "multiActionImage", "state1", false, "titleColor", TitleAlignment.Middle, FontFamily.Arial, FontStyle.Bold, "12", false)]
    [StreamDeckActionState("image", "state2", "multiActionImage", "state2", false, "titleColor", TitleAlignment.Middle, FontFamily.Arial, FontStyle.Bold, "12", false)]
    public class Action : StreamDeckAction
    {

    }
}
