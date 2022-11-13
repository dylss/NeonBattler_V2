using System;

namespace Networking
{
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using UnityEngine;
    using UnityEngine.Networking;

    public static class HttpClient
    {
        public enum RequestType
        {
            GET = 0,
            POST = 1,
            PUT = 2,
            PATCH = 3,
            DELETE = 4
        }

        public static async Task<T> Get<T>(string endpoint)
        {
            var getRequest = CreateRequest(endpoint);
            getRequest.SendWebRequest();
            
            while (!getRequest.isDone) await Task.Delay(10);
            return JsonConvert.DeserializeObject<T>(getRequest.downloadHandler.text);
        }
    
        public static async Task<T> Post<T>(string endpoint, object payload)
        {
            var postRequest = CreateRequest(endpoint, RequestType.POST, payload);
            postRequest.SendWebRequest();

            while (!postRequest.isDone) await Task.Delay(10);
            return JsonConvert.DeserializeObject<T>(postRequest.downloadHandler.text);
        }

        public static UnityWebRequest CreateRequest(string path, RequestType type = RequestType.GET, object payload = null)
        {

            var request = new UnityWebRequest(path, type.ToString());

            if (payload != null)
            {
                var bodyRaw = Encoding.UTF8.GetBytes(JsonUtility.ToJson(payload));
                request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            }

            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Context-Type", "application/json");

            return request;
        }

        private static void AttachHeader(UnityWebRequest request, string key, string value)
        {
            request.SetRequestHeader(key, value);
        }

    }
}