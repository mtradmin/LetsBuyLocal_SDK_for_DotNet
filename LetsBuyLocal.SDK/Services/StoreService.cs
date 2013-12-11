using System;
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

        public ResponseMessage<Store> UpdateStore(string id, Store store)
        {
            try
            {
                //ToDo: Code this with correct return
                return new ResponseMessage<Store>();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to update store '" + id + "'. " + ex.Message);
            }

        }


    }
}
