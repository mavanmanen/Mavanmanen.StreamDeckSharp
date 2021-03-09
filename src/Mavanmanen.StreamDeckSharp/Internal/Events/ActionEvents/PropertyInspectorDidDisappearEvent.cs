namespace Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents
{
    internal class PropertyInspectorDidDisappearEvent : PropertyInspectorEvent
    {
        public PropertyInspectorDidDisappearEvent(string action, string context, string device) : base(EventType.PropertyInspectorDidDisappear, action, context, device)
        {
        }
    }
}