using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsBuyLocal.SDK.Models;

namespace LetsBuyLocal.SDK.Services
{
    public class TrainingService : BaseService
    {

        public ResponseMessage<IList<Video>> GetVideos()
        {
            var videos = Get<ResponseMessage<IList<Video>>>("Training");
            return videos;
        }
    }
}
