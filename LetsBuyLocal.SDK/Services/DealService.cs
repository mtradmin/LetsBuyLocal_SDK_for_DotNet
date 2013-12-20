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
        /// <exception cref="System.ApplicationException">Unable to get specified deal.  + ex.Message</exception>
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
        /// <exception cref="System.ApplicationException">Unable to update specified deal.  + ex.Message</exception>
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
        /// <exception cref="System.ApplicationException">Unable to delete the specified deal.  + ex.Message</exception>
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
        /// <exception cref="System.ApplicationException">
        /// Unable to get the number of available reservations for the specified deal.  + ex.Message
        /// </exception>
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
        /// <exception cref="System.ApplicationException">
        /// Unable to determine if the specified deal has any active reservations.  + ex.Message
        /// </exception>
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
        /// <returns>A ResponseMessage containing an object of type IList Of Deal.</returns>
        public ResponseMessage<IList<Deal>> GetListOfDealsByStoreAndUser(string userId)
        {
            var sb = new StringBuilder();
            sb.Append("Deal");
            sb.Append("/");
            sb.Append("ListLostActiveAndFuture");
            sb.Append("/");
            sb.Append(userId);
            var path = sb.ToString();

            var resp = Post<ResponseMessage<IList<Deal>>>(path);
            return resp;
        }

        //public ResponseMessage<IList<Deal>> GetListOfActiveDealsByStore(string storeId)
        //{
        //    var sb = new StringBuilder();
        //    sb.Append("Deal");
        //    sb.Append("/");
        //    sb.Append("ListActive");
        //    var path = sb.ToString();

        //    var resp = Post<ResponseMessage<IList<Deal>>>(path, arrayofvalues);
        //}

    }
}
