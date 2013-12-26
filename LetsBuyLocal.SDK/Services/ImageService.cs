using System;
using System.Text;
using LetsBuyLocal.SDK.Models;

namespace LetsBuyLocal.SDK.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class ImageService : BaseService
    {
        /// <summary>
        /// Uploads an image.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="type">The type.</param>
        /// <param name="image">image stream.</param>
        /// <returns>A ResponseMessage containing an object of type Boolean.</returns>
        public ResponseMessage<bool> UploadImage(string id, string type, byte[] image)
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

            var resp = Upload<ResponseMessage<bool>>(path, image);
            return resp;
        }

        /// <summary>
        /// Gets an image by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A Byte array whose content is a PNG image stream.</returns>
        public Byte[] GetImageById(string id)
        {
            var sb = new StringBuilder();
            sb.Append("Image");
            sb.Append("/");
            sb.Append(id);
            var path = sb.ToString();

            var resp = GetImageBytes(path);
            return resp;
        }

        /// <summary>
        /// Gets the image by identifier and image type.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="imageType">Type of the image.</param>
        /// <returns>A Byte array whose content is a PNG image stream.</returns>
        public Byte[] GetImageByIdAndType(string id, string imageType)
        {
            var sb = new StringBuilder();
            sb.Append("Image");
            sb.Append("/");
            sb.Append(id);
            sb.Append("/");
            sb.Append(imageType);

            var path = sb.ToString();
            var resp = GetImageBytes(path);
            return resp;
        }
    }
}
