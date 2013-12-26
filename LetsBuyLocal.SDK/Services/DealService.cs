using System;
using System.Collections.Generic;
using System.Text;
using LetsBuyLocal.SDK.Models;

namespace LetsBuyLocal.SDK.Services
{
    /// <summary>
    /// Handles CRUD operations for Deals.
    /// </summary>
    public class DealService : BaseService
    {
        /// <summary>
        /// Creates the deal.
        /// </summary>
        /// <param name="deal">The deal.</param>
        /// <returns>A ResponseMessage containing an object of type Deal.</returns>
        public ResponseMessage<Deal> CreateDeal(Deal deal)
        {
            var resp = Post<ResponseMessage<Deal>>("Deal", deal);
            return resp;
        }

        /// <summary>
        /// Gets the deal by identifier.
        /// </summary>
        /// <param name="id">The Deal identifier.</param>
        /// <returns>A ResponseMessage containing an object of type Deal.</returns>
        public ResponseMessage<Deal> GetDealById(string id)
        {
            var resp = Get<ResponseMessage<Deal>>("Deal" + "/" + id);
            return resp;
        }

        /// <summary>
        /// Updates the deal.
        /// </summary>
        /// <param name="deal">The deal.</param>
        /// <returns>A ResponseMessage containing an object of type Deal.</returns>
        public ResponseMessage<Deal> UpdateDeal(Deal deal)
        {
            var resp = Put<ResponseMessage<Deal>>("Deal" + "/" + deal.Id, deal);
            return resp;
        }

        /// <summary>
        /// Deletes the deal.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A ResponseMessage containing an object of type bool.</returns>
        public ResponseMessage<bool> DeleteDeal(string id)
        {
            var resp = Delete<ResponseMessage<bool>>("Deal/" + id);
            return resp;
        }

        /// <summary>
        /// Gets the number of available reservations for this deal.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A ResponseMessage containing an object of type Int32.</returns>
        public ResponseMessage<Int32> GetNumberAvailableReservations(string id)
        {
            var sb = new StringBuilder();
            sb.Append("Deal");
            sb.Append("/");
            sb.Append("GetTotalAvailable");
            sb.Append("/");
            sb.Append(id);
            var path = sb.ToString();

            var resp = Get<ResponseMessage<Int32>>(path);
            return resp;
        }

        /// <summary>
        /// Checks if the deal has any active reservations.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A ResponseMessage containing an object of type Boolean.</returns>
        public ResponseMessage<bool> DealHasActiveReservations(string id)
        {
            var sb = new StringBuilder();
            sb.Append("Deal");
            sb.Append("/");
            sb.Append("HasActiveReservations");
            sb.Append("/");
            sb.Append(id);
            var path = sb.ToString();

            var resp = Get<ResponseMessage<bool>>(path);
            return resp;
        }

        /// <summary>
        /// Unpublishes the deal.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A ResponseMessage containing an object of type Deal.</returns>
        public ResponseMessage<Deal> UnpublishDeal(string id)
        {
            var sb = new StringBuilder();
            sb.Append("Deal");
            sb.Append("/");
            sb.Append("Unpublish");
            sb.Append("/");
            sb.Append(id);
            var path = sb.ToString();

            var resp = Post<ResponseMessage<Deal>>(path);
            return resp;
        }

        /// <summary>
        /// Gets the end date of the last Deal in the queue. 
        /// (The Start Date for the next deal queue item.)
        /// </summary>
        /// <param name="storeId">The store identifier.</param>
        /// <returns>A ResponseMessage containing an object of type DateTime.</returns>
        public ResponseMessage<DateTime> GetLatestPublishedDealDate(string storeId)
        {
            var sb = new StringBuilder();
            sb.Append("Deal");
            sb.Append("/");
            sb.Append("GetLatestPublishedDate");
            sb.Append("/");
            sb.Append(storeId);
            var path = sb.ToString();

            var resp = Get<ResponseMessage<DateTime>>(path);
            return resp;
        }

        /// <summary>
        /// Gets a list of last expired deal 
        /// and all active/future deals for the specified user and stores they are tracking.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="storeIds">List of store identifiers</param>
        /// <returns>A ResponseMessage containing an object of type IList Of Deal.</returns>
        public ResponseMessage<IList<Deal>> GetListOfDealsByStoreAndUser(string userId, string[] storeIds)
        {
            var sb = new StringBuilder();
            sb.Append("Deal");
            sb.Append("/");
            sb.Append("ListLostActiveAndFuture");
            sb.Append("/");
            sb.Append(userId);
            var path = sb.ToString();

            var stores = new ArrayOfValues { Values = storeIds };
            var resp = Post<ResponseMessage<IList<Deal>>>(path, stores);
            return resp;
        }

        /// <summary>
        /// Gets the list of active deals by store.
        /// </summary>
        /// <param name="stores">The ArrayOfValues (stores) object.</param>
        /// <returns>
        /// A ResponseMessage containing an object of type IList Of Deal
        /// </returns>
        public ResponseMessage<IList<Deal>> GetListOfActiveDealsByStore(ArrayOfValues stores)
        {
            var sb = new StringBuilder();
            sb.Append("Deal");
            sb.Append("/");
            sb.Append("ListActive");
            var path = sb.ToString();

            var resp = Post<ResponseMessage<IList<Deal>>>(path, stores);
            return resp;
        }


        /// <summary>
        /// Gets the list of recent lost deals by store and user.
        /// </summary>
        /// <param name="storeId">The store identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>A ResponseMessage containing an object of type Ilist Of Deal</returns>
        public ResponseMessage<IList<Deal>> GetListOfLostDealsByStoreAndUser(string storeId, string userId)
        {
            var sb = new StringBuilder();
            sb.Append("Deal");
            sb.Append("/");
            sb.Append("ListLost");
            sb.Append("/");
            sb.Append(storeId);
            sb.Append("/");
            sb.Append(userId);
            var path = sb.ToString();

            var resp = Get<ResponseMessage<IList<Deal>>>(path);
            return resp;
        }

        /// <summary>
        /// Gets the list of active and future deals by store and user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="stores">The stores as an ArrayOfValues.</param>
        /// <returns>A ResponseMessage containing an object of type IList Of Deal</returns>
        public ResponseMessage<IList<Deal>> GetListOfActiveAndFutureDealsByStoreAndUser(string userId, ArrayOfValues stores)
        {
            var sb = new StringBuilder();
            sb.Append("Deal");
            sb.Append("/");
            sb.Append("ListActiveAndFuture");
            sb.Append("/");
            sb.Append(userId);
            var path = sb.ToString();

            var resp = Post<ResponseMessage<IList<Deal>>>(path, stores);
            return resp;
        }

        /// <summary>
        /// Gets the list of all deals by store.
        /// </summary>
        /// <param name="stores">The stores as an ArrayOfValues.</param>
        /// <returns>A ResponseMessage containing an object of type IList Of Deal</returns>
        public ResponseMessage<IList<Deal>> GetListOfAllDealsByStore(ArrayOfValues stores)
        {
            var sb = new StringBuilder();
            sb.Append("Deal");
            sb.Append("/");
            sb.Append("ListAll");
            var path = sb.ToString();

            var resp = Post<ResponseMessage<IList<Deal>>>(path, stores);
            return resp;
        }

        /// <summary>
        /// Gets the deal by redemption identifier.
        /// </summary>
        /// <param name="redemptionId">The redemption identifier.</param>
        /// <returns>A ResponseMessage containing an object of type Deal.</returns>
        public ResponseMessage<Deal> GetDealByRedemptionId(string redemptionId)
        {
            var sb = new StringBuilder();
            sb.Append("Deal");
            sb.Append("/");
            sb.Append("GetRedemption");
            sb.Append("/");
            sb.Append(redemptionId);
            var path = sb.ToString();

            var resp = Get<ResponseMessage<Deal>>(path);
            return resp;
        }

        /// <summary>
        /// Redeems the deal.
        /// </summary>
        /// <param name="dealId">The deal identifier.</param>
        /// <param name="purchaseId">The purchase identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>A ResponseMessage containing an object.</returns>
        public ResponseMessage<object> RedeemDeal(string dealId, string purchaseId, string userId)
        {
            var sb = new StringBuilder();
            sb.Append("Deal");
            sb.Append("/");
            sb.Append("Redeem");
            sb.Append("/");
            sb.Append(dealId);
            sb.Append("/");
            sb.Append(purchaseId);
            sb.Append("/");
            sb.Append(userId);
            var path = sb.ToString();

            var resp = Post<ResponseMessage<object>>(path);
            return resp;
        }

        /// <summary>
        /// Reserves the deal.
        /// </summary>
        /// <param name="dealId">The deal identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="storeId">The store identifier.</param>
        /// <param name="receiptId">The receipt identifier.</param>
        /// <returns>A ResponseMessage containing an object.</returns>
        public ResponseMessage<object> ReserveDeal(string dealId, string userId, string storeId, string receiptId)
        {
            var sb = new StringBuilder();
            sb.Append("Deal");
            sb.Append("/");
            sb.Append("Reserve");
            sb.Append("/");
            sb.Append(dealId);
            sb.Append("/");
            sb.Append(userId);
            sb.Append("/");
            sb.Append(storeId);
            sb.Append("/");
            sb.Append(receiptId);
            var path = sb.ToString();

            var resp = Post<ResponseMessage<object>>(path);
            return resp;
        }

        /// <summary>
        /// Unlocks the deal.
        /// </summary>
        /// <param name="dealId">The deal identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="storeId">The store identifier.</param>
        /// <param name="receiptId">The receipt identifier.</param>
        /// <returns>A ResponseMessage containing an object.</returns>
        public ResponseMessage<Object> UnlockDeal(string dealId, string userId, string storeId, string receiptId)
        {
            var sb = new StringBuilder();
            sb.Append("Deal");
            sb.Append("/");
            sb.Append("Unlock");
            sb.Append("/");
            sb.Append(dealId);
            sb.Append("/");
            sb.Append(userId);
            sb.Append("/");
            sb.Append(storeId);
            sb.Append("/");
            sb.Append(receiptId);
            var path = sb.ToString();

            var resp = Post<ResponseMessage<object>>(path);
            return resp;
        }

    }
}
