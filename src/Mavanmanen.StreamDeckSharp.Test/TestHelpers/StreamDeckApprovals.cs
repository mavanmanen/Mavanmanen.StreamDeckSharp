using ApprovalTests;
using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Test.TestHelpers
{
    public static class StreamDeckApprovals
    {
        public static void VerifyObject(object obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            Approvals.Verify(json);
        }
    }
}
