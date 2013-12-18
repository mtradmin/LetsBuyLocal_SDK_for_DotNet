using System;
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
            try
            {
                var resp = Post<ResponseMessage<Deal>>("Deal", deal);
                return resp;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to create deal. " + ex.Message);
            }
        }

        /// <summary>
        /// Gets the deal by identifier.
        /// </summary>
        /// <param name="id">The Deal identifier.</param>
        /// <returns>A ResponseMessage containing an object of type Deal.</returns>
        /// <exception cref="System.ApplicationException">Unable to get specified deal.  + ex.Message</exception>
        public ResponseMessage<Deal> GetDealById(string id)
        {
            try
            {
                var resp = Get<ResponseMessage<Deal>>("Deal" + "/" + id);
                return resp;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to get specified deal. " + ex.Message);
            }
        }

        /// <summary>
        /// Updates the deal.
        /// </summary>
        /// <param name="deal">The deal.</param>
        /// <returns>A ResponseMessage containing an object of type Deal.</returns>
        /// <exception cref="System.ApplicationException">Unable to update specified deal.  + ex.Message</exception>
        public ResponseMessage<Deal> UpdateDeal(Deal deal)
        {
            try
            {
                var resp = Put<ResponseMessage<Deal>>("Deal" + "/" + deal.Id, deal);
                return resp;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to update specified deal. " + ex.Message);
            }
        }

        /// <summary>
        /// Deletes the deal.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A ResponseMessage containing an object of type bool.</returns>
        /// <exception cref="System.ApplicationException">Unable to delete the specified deal.  + ex.Message</exception>
        public ResponseMessage<bool> DeleteDeal(string id)
        {
            try
            {
                var resp = Delete<ResponseMessage<bool>>("Deal/" + id);
                return resp;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to delete the specified deal. " + ex.Message);
            }
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
            try
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
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to get the number of available reservations for the specified deal. " + ex.Message);
            }
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
            try
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
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to determine if the specified deal has any active reservations. " + ex.Message);
            }
        }

        //public ResponseMessage<object> CreateRedemptionOfDeal(string dealId, string purchaseId, string userId)
        //{
            
        //}

    }
}
