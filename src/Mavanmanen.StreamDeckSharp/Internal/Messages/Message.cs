using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Mavanmanen.StreamDeckSharp.Internal.Messages
{
    internal abstract class Message
    {
        [JsonProperty("event"), JsonConverter(typeof(StringEnumConverter))]
        public MessageEventType Event { get; }

        [JsonProperty("context")]
        public string? Context { get; }

        [JsonProperty("payload")]
        public object? Payload { get; protected set; }

        protected Message(MessageEventType eventType, string? context = null, object? payload = null)
        {
            Event = eventType;
            Context = context;
            Payload = payload;
        }

        public static Message? FromJson(string json)
        {
            JObject obj = JObject.Parse(json);

            if (obj.ContainsKey("event") && System.Enum.TryParse(obj["event"]?.ToString(), true, out MessageEventType eventType))
            {
                return eventType switch
                {
                    MessageEventType.SetSettings => JsonConvert.DeserializeObject<SetSettingsMessage>(json),
                    MessageEventType.SetGlobalSettings => JsonConvert.DeserializeObject<SetGlobalSettingsMessage>(json),
                    MessageEventType.OpenUrl => JsonConvert.DeserializeObject<OpenUrlMessage>(json),
                    MessageEventType.LogMessage => JsonConvert.DeserializeObject<LogMessage>(json),
                    MessageEventType.SetTitle => JsonConvert.DeserializeObject<SetTitleMessage>(json),
                    MessageEventType.SetImage => JsonConvert.DeserializeObject<SetImageMessage>(json),
                    MessageEventType.ShowAlert => JsonConvert.DeserializeObject<ShowAlertMessage>(json),
                    MessageEventType.ShowOk => JsonConvert.DeserializeObject<ShowOkMessage>(json),
                    MessageEventType.SetState => JsonConvert.DeserializeObject<SetStateMessage>(json),
                    MessageEventType.SwitchToProfile => JsonConvert.DeserializeObject<SwitchToProfileMessage>(json),
                    MessageEventType.SentToPropertyInspector => JsonConvert.DeserializeObject<SendToPropertyInspectorMessage>(json),
                    MessageEventType.RegisterPlugin => JsonConvert.DeserializeObject<RegisterPluginMessage>(json),
                    var _ => null
                };
            }

            return null;
        }
    }
}
