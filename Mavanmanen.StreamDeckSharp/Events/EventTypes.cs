namespace Mavanmanen.StreamDeckSharp.Events
{
    public enum EventTypes
    {
        KeyDown,
        KeyUp,
        WillAppear,
        WillDisappear,
        TitleParameterDidChange,
        DeviceDidConnect,
        DeviceDidDisconnect,
        ApplicationDidLaunch,
        ApplicationDidTerminate,
        SendToPlugin,
        DidReceiveSettings,
        DidReceiveGlobalSettings,
        PropertyInspectorDidAppear,
        PropertyInspectorDidDisappear
    }
}