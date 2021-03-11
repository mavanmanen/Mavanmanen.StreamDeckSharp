using System.Threading.Tasks;
using Mavanmanen.StreamDeckSharp.Attributes;
using Mavanmanen.StreamDeckSharp.Payloads;

namespace Mavanmanen.StreamDeckSharp.Test.Integration
{
    [StreamDeckAction("testAction", "icon")]
    public class TestAction : StreamDeckAction
    {
        public override Task OnKeyDownAsync() => ShowOkAsync();
        public override Task OnKeyUpAsync() => ShowOkAsync();
        public override Task WillAppearAsync() => ShowOkAsync();
        public override Task WillDisappearAsync() => ShowOkAsync();
        public override Task TitleParametersDidChangeAsync(string title, TitleParameters parameters) => ShowOkAsync();
        public override Task PropertyInspectorDidAppearAsync() => ShowOkAsync();
        public override Task PropertyInspectorDidDisappearAsync() => ShowOkAsync();
    }
}