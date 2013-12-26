using System;
using System.Configuration;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;

namespace LetsBuyLocal.SDK.Services
{
    /// <summary>
    /// Handles CRUD operations for all models through WebClient and LetsBuyLocal.API
    /// </summary>
    public class BaseService
    {
        private static readonly string BaseUrl;
        private static readonly string ApiVersion;

        /// <summary>
        /// Initializes BaseService, setting base URL and API version for path.
        /// </summary>
        static BaseService()
        {
                BaseUrl = ConfigurationManager.AppSettings["BaseUrl"];
                ApiVersion = ConfigurationManager.AppSettings["ApiVersion"];
        }

        /// <summary>
        /// Handles getting the specified object
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="path">Object path</param>
        /// <returns>A response object</returns>
        protected T Get<T>(string path)
        {
            string response = GetClient().DownloadString(BuildPath(path));
            return JsonConvert.DeserializeObject<T>(response);
        }

        /// <summary>
        /// Gets the image bytes from an HTTPResponseMessage.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>A response containing an Array of Bytes.</returns>        
        protected Byte[] GetImageBytes(string url)
        {
            byte [] fileBytes = GetClient().DownloadData(BuildPath(url));
            return fileBytes;
        }

        /// <summary>
        /// Handles creating the specified object
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="path">Object path</param>
        /// <param name="data">Object data</param>
        /// <returns>A response object</returns>
        protected T Post<T>(string path, Object data)
        {
            string dataString = JsonConvert.SerializeObject(data);
            string response = GetClient().UploadString(BuildPath(path), "POST", dataString);
            return JsonConvert.DeserializeObject<T>(response);
        }

        /// <summary>
        /// Handles creating the specified object
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="path">Object path</param>
        /// <returns>A response object</returns>
        protected T Post<T>(string path)
        {
            string response = GetClient().UploadString(BuildPath(path), "POST");
            return JsonConvert.DeserializeObject<T>(response);
        }

        /// <summary>
        /// Handles deleting the specified object.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="path">Object path.</param>
        /// <returns>A response object.</returns>
        protected T Delete<T>(string path)
        {
            string response = GetClient().UploadString(BuildPath(path), "DELETE", string.Empty);
            return JsonConvert.DeserializeObject<T>(response);
        }

        /// <summary>
        /// Handles updating the specified object
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="path">Object path</param>
        /// <param name="data">Object data</param>
        /// <returns>A response object</returns>
        protected T Put<T>(string path, Object data)
        {
            string dataString = JsonConvert.SerializeObject(data);
            string response = GetClient().UploadString(BuildPath(path), "PUT", dataString);
            return JsonConvert.DeserializeObject<T>(response);
        }

        /// <summary>
        /// Uploads a file to the server
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="path">Object path</param>
        /// <param name="file">File stream</param>
        /// <returns>A response object</returns>
        protected T Upload<T>(string path, byte[] file)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", ConfigurationManager.AppSettings["AuthorizationToken"]);

            //if there is a store api key, send it
            if (ConfigurationManager.AppSettings["StoreApiKey"] != null)
            {
                client.DefaultRequestHeaders.Add("StoreApiKey", ConfigurationManager.AppSettings["StoreApiKey"]);
            }

            using (var ms = new MemoryStream(file))
            {
                ms.Position = 0;
                var content = new StreamContent(ms);
                var mpcontent = new MultipartFormDataContent {{content, "image/png", "tmp.png"}};

                var response = client.PostAsync(BuildPath(path), mpcontent).Result.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(response);
            }
        }

        /// <summary>
        ///     Gets a WebClient with the appropriate information added to the Headers.
        /// </summary>
        /// <returns>A WebClient object</returns>
        private WebClient GetClient()
        {
            var client = new WebClient();
            client.Headers.Add("content-type", "application/Json");
            client.Headers.Add("Authorization", ConfigurationManager.AppSettings["AuthorizationToken"]);

            //if there is a store api key, send it
            if (ConfigurationManager.AppSettings["StoreApiKey"] != null)
            {
                client.Headers.Add("StoreApiKey", ConfigurationManager.AppSettings["StoreApiKey"]);
            }

            return client;
        }

        /// <summary>
        ///     Builds an URL to be sent to the LetsBuyLocal API
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string BuildPath(string path)
        {
            return BaseUrl + ApiVersion + "/" + path;
        }

    }
}