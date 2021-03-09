namespace Mavanmanen.StreamDeckSharp.Internal.Events.PluginEvents
{
    internal class DeviceDidDisconnectEvent : StreamDeckPluginEvent
    {
        public DeviceDidDisconnectEvent(string device) : base(EventType.DeviceDidDisconnect, device)
        {
        }
    }
}