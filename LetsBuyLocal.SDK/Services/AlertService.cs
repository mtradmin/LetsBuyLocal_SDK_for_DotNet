using System;
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
            try
            {
                var resp = Post<ResponseMessage<User>>("Alert", alert);
                return resp;
            }
            catch (System.Exception ex)
            {
                throw new ApplicationException("Unable to create the alert." + ex.Message);
            }
        }

        //Todo: GET /v1/Alert/{id}

        /// <summary>
        /// Gets list of alerts for store by type of alert.
        /// </summary>
        /// <param name="storeId">The store's Id string</param>
        /// <param name="type">The alert type string (STORE/DEAL/COUPON)</param>
        /// <returns>A ResponseMessage object of type IList of Alert objects</returns>
        public ResponseMessage<IList<Alert>> GetAlertListForStoreByType(string storeId, string type)
        {
            try
            {
                var resp = Get<ResponseMessage<IList<Alert>>>("Alert/List" + "/" + storeId + "/" + type);
                return resp;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to get a list of alerts for this store of the specified type." + ex.Message);
            }
        }

        //Todo: GET /v1/Alert/ListUserAlerts/{storeId}/{type}/{userId}

        //Todo: POST /v1/Alert/DeleteUserAlert/{id}/{userId}
    }
}
