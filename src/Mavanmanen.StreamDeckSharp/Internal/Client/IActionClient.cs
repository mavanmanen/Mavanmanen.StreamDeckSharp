using System.Threading.Tasks;
using Mavanmanen.StreamDeckSharp.Enum;

namespace Mavanmanen.StreamDeckSharp.Internal.Client
{
    internal interface IActionClient : IPluginClient
    {
        Task SetSettingsAsync(string context, object payload);
        Task SetTitleAsync(string context, string title, Target? target = null, int? state = null);
        Task SetImageAsync(string context, string? base64Image, Target? target = null, int? state = null);
        Task ShowAlertAsync(string context);
        Task ShowOkAsync(string context);
        Task SetStateAsync(string context, int state);
        Task SendToPropertyInspectorAsync(string context, object payload);
    }
}
