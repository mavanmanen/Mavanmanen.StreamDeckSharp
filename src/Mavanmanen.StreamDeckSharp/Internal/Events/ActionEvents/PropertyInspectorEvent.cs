namespace Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents
{
    internal abstract class PropertyInspectorEvent : StreamDeckActionEvent
    {
        protected PropertyInspectorEvent(EventType eventType, string action, string context, string device) : base(eventType, action, context, device)
        {
        }
    }
}