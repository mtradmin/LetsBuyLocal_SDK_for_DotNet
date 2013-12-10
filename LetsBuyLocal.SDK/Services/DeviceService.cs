using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsBuyLocal.SDK.Models;

namespace LetsBuyLocal.SDK.Services
{
    public class DeviceService : BaseService
    {
        /// <summary>
        /// Creates a new device (ios or android)
        /// </summary>
        /// <param name="device">A Device object</param>
        /// <returns>A ResponseMessage containing the created Device object</returns>
        public ResponseMessage<Device> CreateDevice(Device device)
        {
            var newDevice = Post<ResponseMessage<Device>>("Device", device);
            return newDevice;
        }

        public ResponseMessage<Device> GetDeviceById(string id)
        {
            var device = Get<ResponseMessage<Device>>("Device" + "/" + id);
            return device;
        }
    }
}
