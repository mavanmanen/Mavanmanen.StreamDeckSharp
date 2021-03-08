using System;
using System.Threading.Tasks;
using Mavanmanen.StreamDeckSharp;
using Mavanmanen.StreamDeckSharp.Attributes;
using Mavanmanen.StreamDeckSharp.PropertyInspector;
using RestSharp;

namespace com.mavanmanen.streamdeckrest
{
    [StreamDeckAction("Post", "Images/postActionIcon", "Perform a POST request.")]
    [StreamDeckActionState("Images/postKeyImage")]
    [StreamDeckPropertyInspector(typeof(PostActionSettings))]
    public class PostAction : StreamDeckAction
    {
        private readonly IRestClient _client;

        public PostAction(IRestClient client)
        {
            _client = client;
        }

        public override async Task OnKeyDownAsync()
        {
            var settings = GetSettings<PostActionSettings>();
            if (settings == null)
            {
                return;
            }

            if (!Uri.TryCreate(settings.URL, UriKind.Absolute, out Uri url))
            {
                return;
            }

            var request = new RestRequest(url, Method.POST);

            if (!string.IsNullOrEmpty(settings.Body))
            {
                request.AddJsonBody(settings.Body);
            }

            await _client.ExecuteAsync(request);
        }
    }
}