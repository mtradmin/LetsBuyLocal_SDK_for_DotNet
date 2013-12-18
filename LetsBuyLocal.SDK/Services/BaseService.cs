﻿using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Permissions;
using System.Web.Script.Serialization;

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
            try
            {
                BaseUrl = ConfigurationManager.AppSettings["BaseUrl"];
                ApiVersion = ConfigurationManager.AppSettings["ApiVersion"];
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to initialize LetsBuyLocal.SDK.Services.BaseService. " + ex.Message);
            }
        }

        /// <summary>
        /// Handles getting the specified object
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="path">Object path</param>
        /// <returns>A response object</returns>
        protected T Get<T>(string path)
        {
            try
            {
                string response = GetClient().DownloadString(BuildPath(path));
                var serializer = new JavaScriptSerializer();
                return serializer.Deserialize<T>(response);
            }
            catch (Exception ex)
            {
               throw new ApplicationException("Unable to Get object of specified type. " + ex.Message);
            }
        }

        protected Byte[] GetImageBytes(string url)
        {
            try
            {
                byte [] fileBytes = GetClient().DownloadData(BuildPath(url));
                return fileBytes;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to get QRCode image. " + ex.Message);
            }
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
            try
            {
                var serializer = new JavaScriptSerializer();
                string dataString = serializer.Serialize(data);
                string response = GetClient().UploadString(BuildPath(path), "Post", dataString);
                return serializer.Deserialize<T>(response);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to Post object of specified type with the specified data. " + ex.Message);
            }
        }

        /// <summary>
        /// Handles creating the specified object
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="path">Object path</param>
        /// <returns>A response object</returns>
        protected T Post<T>(string path)
        {
            try
            {
                var serializer = new JavaScriptSerializer();
                string response = GetClient().UploadString(BuildPath(path), "Post");
                return serializer.Deserialize<T>(response);
            }
            catch (Exception ex)
            {
               throw new ApplicationException("Unable to Post object of specified type. " + ex.Message);
            }
        }

        /// <summary>
        /// Handles deleting the specified object.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="path">Object path.</param>
        /// <returns>A response object.</returns>
        protected T Delete<T>(string path)
        {
            try
            {
                var serializer = new JavaScriptSerializer();
                string response = GetClient().UploadString(BuildPath(path), "DELETE", string.Empty);
                return serializer.Deserialize<T>(response);

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to Delete object of specified type. " + ex.Message);
            }
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
            try
            {
                var serializer = new JavaScriptSerializer();
                string dataString = serializer.Serialize(data);
                string response = GetClient().UploadString(BuildPath(path), "Put", dataString);
                return serializer.Deserialize<T>(response);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to Put specified object with the specified data. " + ex.Message);
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