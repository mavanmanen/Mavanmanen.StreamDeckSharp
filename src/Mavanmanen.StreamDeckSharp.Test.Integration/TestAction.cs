using System.Threading.Tasks;
using Mavanmanen.StreamDeckSharp.Attributes;

namespace Mavanmanen.StreamDeckSharp.Test.Integration
{
    [StreamDeckAction("testAction", "icon")]
    public class TestAction : StreamDeckAction
    {
        public override async Task OnKeyDownAsync()
        {
            await ShowOkAsync();
        }
    }
}