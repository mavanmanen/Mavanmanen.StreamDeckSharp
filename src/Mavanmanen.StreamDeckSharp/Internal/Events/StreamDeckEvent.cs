using Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents;
using Mavanmanen.StreamDeckSharp.Internal.Events.PluginEvents;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mavanmanen.StreamDeckSharp.Internal.Events
{
    internal abstract class StreamDeckEvent
    {
        [JsonProperty("event")]
        public EventType Event { get; private set; }

        protected StreamDeckEvent()
        {

        }

        protected StreamDeckEvent(EventType eventType)
        {
            Event = eventType;
        }

        public static StreamDeckEvent? FromJson(string json)
        {
            JObject obj = JObject.Parse(json);

            if (obj.ContainsKey("event") && System.Enum.TryParse(obj["event"]?.ToString(), true, out EventType eventType))
            {
                return eventType switch
                {
                    EventType.KeyDown => JsonConvert.DeserializeObject<KeyDownEvent>(json),
                    EventType.KeyUp => JsonConvert.DeserializeObject<KeyUpEvent>(json),
                    EventType.WillAppear => JsonConvert.DeserializeObject<WillAppearEvent>(json),
                    EventType.WillDisappear => JsonConvert.DeserializeObject<WillDisappearEvent>(json),
                    EventType.TitleParametersDidChange => JsonConvert.DeserializeObject<TitleParameterDidChangeEvent>(json),
                    EventType.DeviceDidConnect => JsonConvert.DeserializeObject<DeviceDidConnectEvent>(json),
                    EventType.DeviceDidDisconnect => JsonConvert.DeserializeObject<DeviceDidDisconnectEvent>(json),
                    EventType.ApplicationDidLaunch => JsonConvert.DeserializeObject<ApplicationDidLaunchEvent>(json),
                    EventType.ApplicationDidTerminate => JsonConvert.DeserializeObject<ApplicationDidTerminateEvent>(json),
                    EventType.SendToPlugin => JsonConvert.DeserializeObject<SendToPluginEvent>(json),
                    EventType.DidReceiveSettings => JsonConvert.DeserializeObject<DidReceiveSettingsEvent>(json),
                    EventType.DidReceiveGlobalSettings => JsonConvert.DeserializeObject<DidReceiveGlobalSettingsEvent>(json),
                    EventType.PropertyInspectorDidAppear => JsonConvert.DeserializeObject<PropertyInspectorDidAppearEvent>(json),
                    EventType.PropertyInspectorDidDisappear => JsonConvert.DeserializeObject<PropertyInspectorDidDisappearEvent>(json),
                    EventType.SystemDidWakeUp => JsonConvert.DeserializeObject<SystemDidWakeUpEvent>(json),
                    var _ => null
                };
            }

            return null;
        }
    }
}
