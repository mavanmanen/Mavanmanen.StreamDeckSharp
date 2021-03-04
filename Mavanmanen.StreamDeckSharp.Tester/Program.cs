using System.Diagnostics;
using System.Threading.Tasks;

namespace Mavanmanen.StreamDeckSharp.Tester
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Debugger.Launch();

            var client = new StreamDeckClient(args);

            await client.RunAsync();
        }
    }
}
