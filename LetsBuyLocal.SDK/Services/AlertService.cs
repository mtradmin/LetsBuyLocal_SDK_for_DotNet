using System.Collections.Generic;
using System.Text;
using LetsBuyLocal.SDK.Models;

namespace LetsBuyLocal.SDK.Services
{
    /// <summary>
    /// Handles CRUD operations for Alerts.
    /// </summary>
    public class AlertService : BaseService
    {
        /// <summary>
        /// Creates a new alert
        /// </summary>
        /// <param name="alert">An alert object</param>
        /// <returns>A ResponseMessage object of type Alert</returns>
        public ResponseMessage<Alert> CreateAlert(Alert alert)
        {
            var resp = Post<ResponseMessage<Alert>>("Alert", alert);
            return resp;
        }

        /// <summary>
        /// Gets the alert.
        /// </summary>
        /// <param name="alertId">The alert identifier string</param>
        /// <returns>A ResponseMessage of type Alert</returns>
        public ResponseMessage<Alert> GetAlertById(string alertId)
        {
            var resp = Get<ResponseMessage<Alert>>("Alert" + "/" + alertId);
            return resp;
        }

        /// <summary>
        /// Gets list of alerts for store by type of alert.
        /// </summary>
        /// <param name="storeId">The store's Id string</param>
        /// <param name="type">The alert type string (STORE/DEAL/COUPON)</param>
        /// <returns>A ResponseMessage object of type IList of Alert objects</returns>
        public ResponseMessage<IList<Alert>> GetAlertListForStoreByType(string storeId, string type)
        {
            var sb = new StringBuilder();
            sb.Append("Alert");
            sb.Append("/");
            sb.Append("List");
            sb.Append("/");
            sb.Append(storeId);
            sb.Append("/");
            sb.Append(type);
            string path = sb.ToString();

            var resp = Get<ResponseMessage<IList<Alert>>>(path);
            return resp;
        }

        /// <summary>
        /// Gets a list of alerts for user from specified store and of specified type (STORE/DEAL).
        /// </summary>
        /// <param name="storeId">The store identifier string.</param>
        /// <param name="type">The alert type identifier string.</param>
        /// <param name="userId">The user identifier string.</param>
        /// <returns>A ResponseMessage of type IList of Alert.</returns>
        public ResponseMessage<IList<Alert>> GetAlertListForUserByStoreByType(string storeId, string type, string userId)
        {
            var sb = new StringBuilder();
            sb.Append("Alert");
            sb.Append("/");
            sb.Append("ListUserAlerts");
            sb.Append("/");
            sb.Append(storeId);
            sb.Append("/");
            sb.Append(type);
            sb.Append("/");
            sb.Append(userId);
            string path = sb.ToString();

            var resp = Get<ResponseMessage<IList<Alert>>>(path);
            return resp;
        }

        /// <summary>
        /// Deletes the user alert.
        /// </summary>
        /// <param name="alertId">The alert identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>true, if successful; else, false</returns>
        public ResponseMessage<bool> DeleteUserAlert(string alertId, string userId)
        {
            var sb = new StringBuilder();
            sb.Append("Alert");
            sb.Append("/");
            sb.Append("DeleteUserAlert");
            sb.Append("/");
            sb.Append(alertId);
            sb.Append("/");
            sb.Append(userId);
            string path = sb.ToString();

            var resp = Post<ResponseMessage<bool>>(path);
            return resp;
        }
    }
}
