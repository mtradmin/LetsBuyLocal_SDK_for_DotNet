using System;
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
        /// <exception cref="System.ApplicationException">Unable to get the list of training videos.  + ex.Message</exception>
        public ResponseMessage<IList<Video>> GetVideos()
        {
            var resp = Get<ResponseMessage<IList<Video>>>("Training");
            return resp;
        }
    }
}
