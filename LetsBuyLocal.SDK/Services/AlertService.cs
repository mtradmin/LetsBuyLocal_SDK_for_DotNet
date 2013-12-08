using System.Collections.Generic;
using LetsBuyLocal.SDK.Models;

namespace LetsBuyLocal.SDK.Services
{
    public class AlertService : BaseService
    {
        /// <summary>
        /// Creates a new alert
        /// </summary>
        /// <param name="alert">An alert object</param>
        /// <returns>A ResponseMessage object of type Alert</returns>
        public ResponseMessage<User> CreateAlert(Alert alert)
        {
            var newAlert = Post<ResponseMessage<User>>("Alert", alert);
            return newAlert;
        }

        /// <summary>
        /// Gets list of alerts for store by type of alert.
        /// </summary>
        /// <param name="storeId">The store's Id string</param>
        /// <param name="type">The alert type string (STORE/DEAL)</param>
        /// <returns>A ResponseMessage object of type IList of Alert objects</returns>
        public ResponseMessage<IList<Alert>> GetAlertListForStoreByType(string storeId, string type)
        {
            var alerts = Get<ResponseMessage<IList<Alert>>>("Alert/List" + "/" + storeId + "/" + type);
            return alerts;
        }
    }
}
