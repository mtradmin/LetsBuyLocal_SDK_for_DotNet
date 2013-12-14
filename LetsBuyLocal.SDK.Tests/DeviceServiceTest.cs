using LetsBuyLocal.SDK.Models;
using LetsBuyLocal.SDK.Services;
using LetsBuyLocal.SDK.Tests.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LetsBuyLocal.SDK.Tests
{
    [TestClass]
    public class DeviceServiceTest
    {
        [TestMethod]
        public void CreateDeviceTest()
        {
            var svc = new DeviceService();

            var device = TestingHelper.CreateDeviceInMemory();

            var resp = svc.CreateDevice(device);
            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void GetDeviceByIdTest()
        {
            var svc = new DeviceService();

            //Create a device to get
            var device = TestingHelper.CreateDeviceInMemory();
            var createResp = svc.CreateDevice(device);

            //Now get the device
            var resp = svc.GetDeviceById(createResp.Object.Id);
            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void GetDeviceDetailsForDevicesTest()
        {
            var svc = new DeviceService();

            //Create devices to be added to ArrayOfValues
            var devA = TestingHelper.CreateDeviceInMemory();
            var devB = TestingHelper.CreateDeviceInMemory();
            var deviceA = svc.CreateDevice(devA).Object;
            var deviceB = svc.CreateDevice(devB).Object;

            //Add the devices to a string array
            var devices = new[] { deviceA.Id, deviceB.Id};
            var values = new ArrayOfValues { Values = devices };

            var resp = svc.GetDeviceDetailsForDevices(values);
            Assert.IsNotNull(resp.Object);
        }

    }



}
