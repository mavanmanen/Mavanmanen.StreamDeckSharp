namespace Mavanmanen.StreamDeckSharp.Internal.Messages
{
    internal enum MessageEventType
    {
        RegisterPlugin,
        SetSettings,
        GetSettings,
        SetGlobalSettings,
        GetGlobalSettings,
        OpenUrl,
        LogMessage,
        SetTitle,
        SetImage,
        ShowAlert,
        ShowOk,
        SetState,
        SwitchToProfile,
        SentToPropertyInspector
    }
}