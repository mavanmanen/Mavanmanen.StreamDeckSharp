using System.Threading.Tasks;

namespace Mavanmanen.StreamDeckSharp.Internal
{
    internal interface IPluginClient
    {
        Task OpenUrlAsync(string url);
        Task SetGlobalSettings(string context, object payload);
        Task LogMessageAsync(string message);
        Task SwitchToProfileAsync(string context, string device, string? profileName);
    }
}