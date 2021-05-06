using System.Collections.Generic;
using System.Linq;

namespace Mavanmanen.StreamDeckSharp.Internal.Client
{
    internal class ClientArguments
    {
        public int Port { get; }
        public string UUID { get; }
        public string RegisterEvent { get; }
        
        private ClientArguments()
        {
            
        }

        public ClientArguments(int port, string uuid, string registerEvent)
        {
            Port = port;
            UUID = uuid;
            RegisterEvent = registerEvent;
        }

        public static ClientArguments ParseFromArgs(string[] args)
        {
            if (!args.Any())
            {
                return new ClientArguments();
            }
            
            var pairs = new Dictionary<string, string>();
            for (var i = 0; i < args.Length-1; i += 2)
            {
                pairs.Add(args[i].TrimStart('-'), args[i + 1]);
            }

            int port = int.Parse(pairs["port"]);
            string uuid = pairs["pluginUUID"];
            string registerEvent = pairs["registerEvent"];

            return new ClientArguments(port, uuid, registerEvent);
        }
    }
}