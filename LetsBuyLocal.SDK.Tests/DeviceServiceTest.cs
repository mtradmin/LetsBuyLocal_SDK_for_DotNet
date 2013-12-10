using System;
using LetsBuyLocal.SDK.Models;
using LetsBuyLocal.SDK.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LetsBuyLocal.SDK.Tests
{
    [TestClass]
    public class DeviceServiceTest
    {
        [TestMethod]
        public void CreateDeviceTest()
        {
            var device = new Device();
            device.Id = Guid.NewGuid().ToString();
            device.Platform = TestingHelper.GetPlatform();
            device.DeviceToken = TestingHelper.GetDeviceToken(device.Platform);

            var svc = new DeviceService();
            var resp = svc.CreateDevice(device);

            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void GetDeviceByIdTest()
        {
            var svc = new DeviceService();
            var resp = svc.GetDeviceById("083b2ab6-2ae1-44a8-a406-7d3834ab8c92");
            
            Assert.IsNotNull(resp.Object);
        }



    }

 

}
