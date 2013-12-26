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
        public ResponseMessage<OptionSets> GetListOfStandardOptions()
        {
            var resp = Get<ResponseMessage<OptionSets>>("Configuration");
            return resp;
        }
    }
}
