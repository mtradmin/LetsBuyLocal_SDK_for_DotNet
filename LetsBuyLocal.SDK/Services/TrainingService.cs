using System.Collections.Generic;
using LetsBuyLocal.SDK.Models;

namespace LetsBuyLocal.SDK.Services
{
    public class TrainingService : BaseService
    {
        /// <summary>
        /// Get a list of Training Videos
        /// </summary>
        /// <returns>A ResponseMessage returning the details of all available training videos.</returns>
        public ResponseMessage<IList<Video>> GetVideos()
        {
            var videos = Get<ResponseMessage<IList<Video>>>("Training");
            return videos;
        }
    }
}
