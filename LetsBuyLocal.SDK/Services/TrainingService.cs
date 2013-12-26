using System.Collections.Generic;
using LetsBuyLocal.SDK.Models;

namespace LetsBuyLocal.SDK.Services
{
    /// <summary>
    /// Handles CRUD operations for training videos.
    /// </summary>
    public class TrainingService : BaseService
    {
        /// <summary>
        /// Get a list of Training Videos
        /// </summary>
        /// <returns>
        /// A ResponseMessage returning the details of all available training videos.
        /// </returns>
        public ResponseMessage<IList<Video>> GetVideos()
        {
            var resp = Get<ResponseMessage<IList<Video>>>("Training");
            return resp;
        }
    }
}
