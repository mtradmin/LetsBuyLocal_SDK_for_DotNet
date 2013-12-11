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
        public ResponseMessage<bool> CreateDeal(Deal deal)
        {
            try
            {
                var resp = Post<ResponseMessage<bool>>("Deal", deal);
                if (resp.Errors.Count <= 0)
                    return resp;
                else
                    throw new ApplicationException("Unable to create deal. " + Utilities.ResponseErrors(resp.Errors));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to create deal. " + ex.Message);
            }
        }

        public ResponseMessage<Deal> GetDealById(string id)
        {
            var resp = Get<ResponseMessage<Deal>>("Deal" + "/" + id);
            return resp;
        }

    }
}
