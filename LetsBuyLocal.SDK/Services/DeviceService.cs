using LetsBuyLocal.SDK.Models;
using System.Collections.Generic;

namespace LetsBuyLocal.SDK.Services
{
    /// <summary>
    /// Handles CRUD operations for Devices.
    /// </summary>
    public class DeviceService : BaseService
    {
        /// <summary>
        /// Creates a new device (ios or android)
        /// </summary>
        /// <param name="device">A Device object</param>
        /// <returns>A ResponseMessage containing an object of type Device.</returns>
        /// <exception cref="System.Exception">Unable to create device.  + ex.Message</exception>
        public ResponseMessage<Device> CreateDevice(Device device)
        {
            var resp = Post<ResponseMessage<Device>>("Device", device);
            return resp;
        }

        /// <summary>
        /// Gets the device by identifier.
        /// </summary>
        /// <param name="id">The identifier string.</param>
        /// <returns>A ResponseMessage containing an object of type Device.</returns>
        public ResponseMessage<Device> GetDeviceById(string id)
        {
            var resp = Get<ResponseMessage<Device>>("Device" + "/" + id);
            return resp;
        }

        /// <summary>
        /// Gets the device details for devices.
        /// </summary>
        /// <param name="devices">The devices as an ArrayOfValues.</param>
        /// <returns>A List of Decice objects.</returns>
        public ResponseMessage<IList<Device>> GetDeviceDetailsForDevices(ArrayOfValues devices)
        {
            var resp = Post<ResponseMessage<IList<Device>>>("Deal/List", devices);
            return resp;
        }
    }
}
