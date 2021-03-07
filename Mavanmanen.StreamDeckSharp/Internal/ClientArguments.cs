using System.Collections.Generic;

namespace Mavanmanen.StreamDeckSharp.Internal
{
    internal class ClientArguments
    {
        public int Port { get; }
        public string UUID { get; }
        public string RegisterEvent { get; }

        public ClientArguments(int port, string uuid, string registerEvent)
        {
            Port = port;
            UUID = uuid;
            RegisterEvent = registerEvent;
        }

        public static ClientArguments ParseFromArgs(string[] args)
        {
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