namespace Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents
{
    internal class PropertyInspectorDidAppearEvent : PropertyInspectorEvent
    {
        public PropertyInspectorDidAppearEvent(string action, string context, string device) : base(EventType.PropertyInspectorDidAppear, action, context, device)
        {
        }
    }
}