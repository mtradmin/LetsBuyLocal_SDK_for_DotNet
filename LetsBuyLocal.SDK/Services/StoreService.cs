using System;
using System.Text;
using LetsBuyLocal.SDK.Models;
using LetsBuyLocal.SDK.Shared;

namespace LetsBuyLocal.SDK.Services
{
    public class StoreService : BaseService
    {
        /// <summary>
        /// Creates a new store
        /// </summary>
        /// <param name="store">A Store object to create</param>
        /// <returns>
        /// A ResponseMessage of type Store
        /// </returns>
        /// <exception cref="System.ApplicationException">Unable to create store.  + ex.Message</exception>
        public ResponseMessage<Store> CreateStore(Store store)
        {
            try
            {
                var resp = Post<ResponseMessage<Store>>("Store", store);
                return resp;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to create store. " + ex.Message);
            }
        }

        /// <summary>
        /// Gets a Store by Id
        /// </summary>
        /// <param name="id">An Id string for the store to get</param>
        /// <returns>
        /// A ResponseMessage of type Store
        /// </returns>
        /// <exception cref="System.ApplicationException">Unable to get specified store.  + ex.Message</exception>
        public ResponseMessage<Store> GetStoreById(string id)
        {
            try
            {
                var resp = Get<ResponseMessage<Store>>("Store" + "/" + id);
                return resp;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to get specified store. " + ex.Message);
            }
        }

        /// <summary>
        /// Gets the store's API key.
        /// </summary>
        /// <param name="id">The store's identifier string.</param>
        /// <returns>ResponseMessage of type String</returns>
        /// <exception cref="System.ApplicationException">Unable to get specified store's API Key.  + ex.Message</exception>
        public ResponseMessage<Store> GetStoreApiKey(string id)
        {
            try
            {
                var sb = new StringBuilder();
                sb.Append("Store");
                sb.Append("/");
                sb.Append("API");
                sb.Append("/");
                var s = sb.ToString();

                var resp = Get<ResponseMessage<Store>>(s + id);
                return resp;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to get specified store's API Key. " + ex.Message);
            }
        }

        /// <summary>
        /// Updates the store.
        /// </summary>
        /// <param name="id">The store identifier string.</param>
        /// <param name="store">The store.</param>
        /// <returns>The store</returns>
        /// <exception cref="System.ApplicationException">Unable to update specified store.  + ex.Message</exception>
        public ResponseMessage<Store> UpdateStore(string id, Store store)
        {
            try
            {
                var resp = Put<ResponseMessage<Store>>("Store" + "/" + store.Id, store);
                return resp;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to update specified store. " + ex.Message);
            }

        }


    }
}
