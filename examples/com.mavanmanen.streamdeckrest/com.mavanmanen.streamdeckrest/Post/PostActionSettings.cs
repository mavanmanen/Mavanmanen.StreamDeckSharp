using Mavanmanen.StreamDeckSharp.PropertyInspector;

namespace com.mavanmanen.streamdeckrest
{
    public class PostActionSettings
    {
        [PropertyInspectorText(required: true)]
        public string URL { get; set; }

        [PropertyInspectorTextArea]
        public string Body { get; set; }
    }
}