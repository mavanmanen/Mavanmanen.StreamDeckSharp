using System.Collections.Generic;

namespace Mavanmanen.StreamDeckSharp
{
    public readonly struct StreamDeckClientArguments
    {
        public int Port { get; }
        public string UUID { get; }
        public string RegisterEvent { get; }

        private StreamDeckClientArguments(int port, string uuid, string registerEvent)
        {
            Port = port;
            UUID = uuid;
            RegisterEvent = registerEvent;
        }

        public static StreamDeckClientArguments ParseFromArgs(string[] args)
        {
            var pairs = new Dictionary<string, string>();
            for (var i = 0; i < args.Length-1; i += 2)
            {
                pairs.Add(args[i].TrimStart('-'), args[i + 1]);
            }

            int port = int.Parse(pairs["port"]);
            string uuid = pairs["pluginUUID"];
            string registerEvent = pairs["registerEvent"];

            return new StreamDeckClientArguments(port, uuid, registerEvent);
        }
    }
}