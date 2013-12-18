using System;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LetsBuyLocal.SDK.Services
{
    public class QrCodeService : BaseService
    {
        /// <summary>
        /// Gets the QRCode image for the specified store as an Array of Bytes.
        /// </summary>
        /// <param name="storeId">The store identifier.</param>
        /// <returns>A Byte arrau whose content is a PNG image stream.</returns>
        public Byte[] GetQrCodeForStore(string storeId)
        {
            try
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
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to get QRCode for the specified store. " + ex.Message);
            }
        }
    }
}
