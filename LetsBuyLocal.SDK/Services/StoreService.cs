using System;
using System.Text;
using LetsBuyLocal.SDK.Models;

namespace LetsBuyLocal.SDK.Services
{
    /// <summary>
    /// Handles CRUD operations for stores.
    /// </summary>
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

        /// <summary>
        /// Deletes the store.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>True, if successful; else, false.</returns>
        /// <exception cref="System.ApplicationException">Unable to delete specified store.  + ex.Message</exception>
        public ResponseMessage<bool> DeleteStore(string id)
        {
            try
            {
                var resp = Delete<ResponseMessage<bool>>("Store/" + id);
                return resp;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to delete specified store. " + ex.Message);
            }
        }

        /// <summary>
        /// Gets the store by its URL.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <returns> A ResponsMessage containing an object of type Store.</returns>
        /// <exception cref="System.ApplicationException">Unable to get specified store by its Url.  + ex.Message</exception>
        public ResponseMessage<Store> GetStoreByUrl(Store store)
        {
            try
            {
                var sb = new StringBuilder();
                sb.Append("Store");
                sb.Append("/");
                sb.Append("Url");
                var path = sb.ToString();

                var resp = Post<ResponseMessage<Store>>(path, store.Website);
                return resp;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to get specified store by its Url. " + ex.Message);
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
        /// Loads the store details by user.
        /// </summary>
        /// <param name="storeId">The store identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>A ResponseMessage containing an object of type Store</returns>
        /// <exception cref="System.ApplicationException">Unable to load the specified store's details for the specified user.  + ex.Message</exception>
        public ResponseMessage<Store> LoadStoreDetailsByUser(string storeId, string userId)
        {
            try 
	        {	        
		        var sb = new StringBuilder();
                sb.Append("Store");
                sb.Append("/");
                sb.Append("LoadDetails");
                sb.Append("/");
                sb.Append(storeId);
                sb.Append("/");
                sb.Append(userId);
	            var path = sb.ToString();

                var resp = Get<ResponseMessage<Store>>(path);
                return resp;
	        }
	        catch (Exception ex)
	        {
		        throw new ApplicationException("Unable to load the specified store's details for the specified user. " + ex.Message);
	        }
        }

        /// <summary>
        /// Updates the store's location.
        /// </summary>
        /// <param name="id">The store identifier.</param>
        /// <param name="geoPoint">The GeoPoint object.</param>
        /// <returns>a ResponseMessage containing an object of type Store.</returns>
        public ResponseMessage<Store> UpdateStoreLocation(string id, GeoPoint geoPoint)
        {
            try
            {
                var sb = new StringBuilder();
                sb.Append("Store");
                sb.Append("/");
                sb.Append("Location");
                sb.Append("/");
                var s = sb.ToString();

                var resp = Post<ResponseMessage<Store>>(s + id, geoPoint);
                return resp;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to update specified store's location. " + ex.Message);
            }
        }

        /// <summary>
        /// Links the store to facebook account.
        /// </summary>
        /// <param name="storeId">The store identifier.</param>
        /// <param name="settings">The FBSettings object.</param>
        /// <returns>A ResponseMessage containing an object of type Store.</returns>
        /// <exception cref="System.ApplicationException">Unable to link specified store to a Facebook account.  + ex.Message</exception>
        public ResponseMessage<Store> LinkStoreToFacebookAccount(string storeId, FBSettings settings)
        {
            try
            {
                var sb = new StringBuilder();
                sb.Append("Store");
                sb.Append("/");
                sb.Append("Facebook");
                sb.Append("/");
                var s = sb.ToString();

                var resp = Post<ResponseMessage<Store>>(s + storeId, settings);
                return resp;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to link specified store to a Facebook account. " + ex.Message);
            }
        }

        /// <summary>
        /// Removes the facebook account from the store.
        /// </summary>
        /// <param name="storeId">The store identifier.</param>
        /// <returns>A ResponseMessage containing an object of type Store.</returns>
        /// <exception cref="System.ApplicationException">Unable to remove Facebook account from specified store.  + ex.Message</exception>
        public ResponseMessage<Store> RemoveFacebookAccountFromStore(string storeId)
        {
            try
            {
                var sb = new StringBuilder();
                sb.Append("Store");
                sb.Append("/");
                sb.Append("Facebook");
                sb.Append("/");
                var s = sb.ToString();

                var resp = Delete<ResponseMessage<Store>>(s + storeId);
                return resp;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to remove Facebook account from specified store. " + ex.Message);
            }
        }

        /// <summary>
        /// Orders a Media Kit for user.
        /// </summary>
        /// <param name="storeId">The store identifier.</param>
        /// <param name="user">The user.</param>
        /// <returns>A ResponseMessage containing an object of type Store.</returns>
        public ResponseMessage<Store> OrderMediaKit(string storeId, User user)
        {
            try
            {
                var sb = new StringBuilder();
                sb.Append("Store");
                sb.Append("/");
                sb.Append("OrderMediaKit");
                sb.Append("/");
                var s = sb.ToString();

                var resp = Post<ResponseMessage<Store>>(s + storeId, user);
                return resp;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to order media kit for the specified store and user. " + ex.Message);
            }
        }

        /// <summary>
        /// Submits an email for a Media Kit for a user.
        /// </summary>
        /// <param name="storeId">The store identifier.</param>
        /// <param name="user">The user.</param>
        /// <returns>A ResponseMessage containing an object of type Store.</returns>
        public ResponseMessage<Store> EmailMediaKit(string storeId, User user)
        {
            try
            {
                var sb = new StringBuilder();
                sb.Append("Store");
                sb.Append("/");
                sb.Append("EmailMediaKit");
                sb.Append("/");
                var s = sb.ToString();

                var resp = Post<ResponseMessage<Store>>(s + storeId, user);
                return resp;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to submit an email for a media kit for the specified store and user. " + ex.Message);
            }
        }

        /// <summary>
        /// Checks if a store already exists for the given Url.
        /// </summary>
        /// <param name="url">The URL that would match the Website of the store being sought.</param>
        /// <returns>A ResponseMessage containing an object of type Store.</returns>
        public ResponseMessage<Store> StoreExistsForUrl(string url)
        {
            try
            {
                var sb = new StringBuilder();
                sb.Append("Store");
                sb.Append("/");
                sb.Append("Exists");
                var s = sb.ToString();

                var store = new Store {Website = url};

                var resp = Post<ResponseMessage<Store>>(s, store);
                return resp;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to determine if a store already exists for the specified Url. " + ex.Message);
            }
        }
    }
}
