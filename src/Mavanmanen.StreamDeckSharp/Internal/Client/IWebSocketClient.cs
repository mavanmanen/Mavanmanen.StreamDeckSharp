using System;
using System.Threading.Tasks;

namespace Mavanmanen.StreamDeckSharp.Internal.Client
{
    internal interface IWebSocketClient
    {
        event EventHandler<string> MessageReceived;
        Task<bool> ConnectAsync(int port);
        Task SendAsync(string message);
        Task ReceiveAsync();
        Task DisconnectAsync();
    }
}