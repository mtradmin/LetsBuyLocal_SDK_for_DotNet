using System;
using LetsBuyLocal.SDK.Shared;
using LetsBuyLocal.SDK.Models;

namespace LetsBuyLocal.SDK.Services
{
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

    }
}
