namespace Mavanmanen.StreamDeckSharp.Internal.Events.PluginEvents
{
    internal class SystemDidWakeUpEvent : StreamDeckPluginEvent
    {
        public SystemDidWakeUpEvent(string device) : base(EventType.SystemDidWakeUp, device)
        {
        }
    }
}
