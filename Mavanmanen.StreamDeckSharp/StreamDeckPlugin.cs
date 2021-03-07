using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Mavanmanen.StreamDeckSharp
{
    public abstract class StreamDeckPlugin
    {
        public virtual Task DeviceDidConnectAsync() => Task.CompletedTask;

        public virtual void RegisterServices(IServiceCollection services) { }
    }
}