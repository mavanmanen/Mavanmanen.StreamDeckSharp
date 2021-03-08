namespace Mavanmanen.StreamDeckSharp.Internal.Events
{
    internal enum EventTypes
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
        PropertyInspectorDidDisappear,
        SystemDidWakeUp
    }
}