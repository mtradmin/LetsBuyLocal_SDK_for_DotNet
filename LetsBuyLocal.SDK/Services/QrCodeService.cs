using System;
using System.Text;

namespace LetsBuyLocal.SDK.Services
{
    /// <summary>
    /// Handles CRUD operations for QrCode entities.
    /// </summary>
    public class QrCodeService : BaseService
    {
        /// <summary>
        /// Gets the QRCode image for the specified store as an Array of Bytes.
        /// </summary>
        /// <param name="storeId">The store identifier.</param>
        /// <returns>A Byte array whose content is a PNG image stream.</returns>
        public Byte[] GetQrCodeForStore(string storeId)
        {
            var sb = new StringBuilder();
            sb.Append("QRCode");
            sb.Append("/");
            sb.Append("Store");
            sb.Append("/");
            sb.Append(storeId);
            var path = sb.ToString();

            var resp = GetImageBytes(path);
            return resp;
        }

        /// <summary>
        /// Gets the QR Code for a deal.
        /// </summary>
        /// <param name="dealId">The deal identifier.</param>
        /// <returns>A Byte array whose content is a PNG image stream.</returns>
        public Byte[] GetQrCodeForDeal(string dealId)
        {
            var sb = new StringBuilder();
            sb.Append("QRCode");
            sb.Append("/");
            sb.Append("Deal");
            sb.Append("/");
            sb.Append(dealId);
            var path = sb.ToString();

            var resp = GetImageBytes(path);
            return resp;
        }

        /// <summary>
        /// Gets the QR Code for a code string passed in.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>
        /// A Byte array whose content is a PNG image stream.
        /// </returns>
        public Byte[] GetQrCode(string code)
        {
            var sb = new StringBuilder();
            sb.Append("QRCode");
            sb.Append("/");
            sb.Append(code);
            var path = sb.ToString();

            var resp = GetImageBytes(path);
            return resp;
        }
    }
}
