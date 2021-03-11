using System.Reflection;
using System.Threading.Tasks;

namespace Mavanmanen.StreamDeckSharp.Test.Integration
{
    public abstract class IntegrationTestBase
    {
        internal static async Task<(StreamDeckSoftwareEmulator emulator, StreamDeckClient client)> ConnectAsync(int port, string pluginUUID)
        {
            var emulator = new StreamDeckSoftwareEmulator(port, pluginUUID);
            string[] args = emulator.Start();
            var sut = new StreamDeckClient(Assembly.GetExecutingAssembly(), args);
            sut.RunAsync();
            await emulator.AwaitConnectionAsync();
            return (emulator, sut);
        }
    }
}