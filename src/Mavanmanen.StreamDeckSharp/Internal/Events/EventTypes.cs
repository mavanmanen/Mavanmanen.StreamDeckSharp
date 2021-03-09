namespace Mavanmanen.StreamDeckSharp.Internal.Events
{
    internal enum EventType
    {
        KeyDown,
        KeyUp,
        WillAppear,
        WillDisappear,
        TitleParametersDidChange,
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