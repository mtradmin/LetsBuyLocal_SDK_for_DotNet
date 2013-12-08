using LetsBuyLocal.SDK.Models;

namespace LetsBuyLocal.SDK.Services
{
    public class StoreService : BaseService
    {
        /// <summary>
        /// Creates a new store
        /// </summary>
        /// <param name="store">A Store object to create</param>
        /// <returns>A Store object</returns>
        public ResponseMessage<Store> CreateStore(Store store)
        {
            var newStore = Post<ResponseMessage<Store>>("Store", store);
            return newStore;
        }

        /// <summary>
        /// Gets a Store by Id
        /// </summary>
        /// <param name="id">An Id string for the store to get</param>
        /// <returns>A Store object</returns>
        public ResponseMessage<Store> GetStoreById(string id)
        {
            var store = Get<ResponseMessage<Store>>("Store" + "/" + id);
            return store;
        }

    }
}
