using Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents;
using Mavanmanen.StreamDeckSharp.Internal.Events.PluginEvents;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mavanmanen.StreamDeckSharp.Internal.Events
{
    internal abstract class StreamDeckEvent
    {
        [JsonProperty("event")]
        public EventTypes Event { get; private set; }

        internal static StreamDeckEvent? FromJson(string json)
        {
            JObject obj = JObject.Parse(json);

            if (obj.ContainsKey("event") && System.Enum.TryParse(obj["event"]?.ToString(), true, out EventTypes eventType))
            {
                return eventType switch
                {
                    EventTypes.KeyDown => JsonConvert.DeserializeObject<KeyDownEvent>(json),
                    EventTypes.KeyUp => JsonConvert.DeserializeObject<KeyUpEvent>(json),
                    EventTypes.WillAppear => JsonConvert.DeserializeObject<WillAppearEvent>(json),
                    EventTypes.WillDisappear => JsonConvert.DeserializeObject<WillDisappearEvent>(json),
                    EventTypes.TitleParameterDidChange => JsonConvert.DeserializeObject<TitleParameterDidChangeEvent>(json),
                    EventTypes.DeviceDidConnect => JsonConvert.DeserializeObject<DeviceDidConnectEvent>(json),
                    EventTypes.DeviceDidDisconnect => JsonConvert.DeserializeObject<DeviceDidDisconnectEvent>(json),
                    EventTypes.ApplicationDidLaunch => JsonConvert.DeserializeObject<ApplicationDidLaunchEvent>(json),
                    EventTypes.ApplicationDidTerminate => JsonConvert.DeserializeObject<ApplicationDidTerminateEvent>(json),
                    EventTypes.SendToPlugin => JsonConvert.DeserializeObject<SendToPluginEvent>(json),
                    EventTypes.DidReceiveSettings => JsonConvert.DeserializeObject<DidReceiveSettingsEvent>(json),
                    EventTypes.DidReceiveGlobalSettings => JsonConvert.DeserializeObject<DidReceiveGlobalSettingsEvent>(json),
                    EventTypes.PropertyInspectorDidAppear => JsonConvert.DeserializeObject<PropertyInspectorDidAppearEvent>(json),
                    EventTypes.PropertyInspectorDidDisappear => JsonConvert.DeserializeObject<PropertyInspectorDidDisappearEvent>(json),
                    var _ => null
                };
            }

            return null;
        }
    }
}
