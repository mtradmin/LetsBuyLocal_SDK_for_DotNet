using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsBuyLocal.SDK.Models;

namespace LetsBuyLocal.SDK.Services
{
    public class ImageService : BaseService
    {
        /// <summary>
        /// Uploads an image.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="type">The type.</param>
        /// <returns>A ResponseMessage containing an object of type Boolean.</returns>
        public ResponseMessage<bool> UploadImage(string id, string type)
        {
            var sb = new StringBuilder();
            sb.Append("Image");
            sb.Append("/");
            sb.Append("Upload");
            sb.Append("/");
            sb.Append(id);
            sb.Append("/");
            sb.Append(type);
            var path = sb.ToString();

            var resp = Post<ResponseMessage<bool>>(path);
            return resp;
        }
    }
}
