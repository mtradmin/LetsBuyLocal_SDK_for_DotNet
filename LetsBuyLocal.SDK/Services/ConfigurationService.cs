using System;
using LetsBuyLocal.SDK.Models;

namespace LetsBuyLocal.SDK.Services
{

    /// <summary>
    /// Handles CRUD operations for OptionSets (StoreCategories, States, Countries, TimeZones).
    /// </summary>
    public class ConfigurationService : BaseService
    {
        /// <summary>
        /// Gets the list of standard options.
        /// </summary>
        /// <returns>A ResponseMessage containing an object of type OptionSets</returns>
        /// <exception cref="System.ApplicationException">Unable to get list of standard options.  + ex.Message</exception>
        public ResponseMessage<OptionSets> GetListOfStandardOptions()
        {
            try
            {
                var resp = Get<ResponseMessage<OptionSets>>("Configuration");
                return resp;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to get list of standard options. " + ex.Message);
            }
        }
    }
}
