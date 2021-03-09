namespace Mavanmanen.StreamDeckSharp.Internal.Events.PluginEvents
{
    internal class SendToPluginEvent : StreamDeckPluginEvent
    {
        public SendToPluginEvent(string device) : base(EventType.SendToPlugin, device)
        {
        }
    }
}