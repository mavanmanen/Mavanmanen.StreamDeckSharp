namespace Mavanmanen.StreamDeckSharp.Internal.Messages
{
    internal class ShowAlertMessage : Message
    {
        public ShowAlertMessage(string context) : base("showAlert", context)
        {
        }
    }
}
