using System;
using System.Configuration;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using LetsBuyLocal.SDK.Models;
using LetsBuyLocal.SDK.Services;
using LetsBuyLocal.SDK.Tests.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LetsBuyLocal.SDK.Tests
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        public void CreateUserTest()
        {
            var svc = new UserService();

            //Create a new user for this test.
            var user = TestingHelper.CreateNewTestUserInMemory();

            var resp = svc.CreateUser(user);
            Assert.IsNotNull(resp.Object);

            //Create a new user (owner) for this test.
            var owner = TestingHelper.CreateNewTestStoreOwnerInMemory();
            var ownerResp = svc.CreateUser(owner);
            Assert.IsNotNull((ownerResp.Object));
        }

        [TestMethod]
        public void GetUserByIdTest()
        {
            var svc = new UserService();

            //Create a new user for this test.
            var user = TestingHelper.CreateNewTestUserInMemory();

            var testUser = svc.CreateUser(user).Object;
            var resp = svc.GetUserById(testUser.Id);

            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void UpdateUserTest()
        {
            var svc = new UserService();

            //Create a new user for this test.
            var user = TestingHelper.CreateNewTestUserInMemory();
            var testUser = svc.CreateUser(user).Object;
            var updatedUser = TestingHelper.UpdateUser(testUser);

            var resp = svc.UpdateUser(updatedUser);
            Assert.IsNotNull(resp.Object);

            //Now make the user an owner
            var anotherUser = TestingHelper.CreateNewTestUserInMemory();
            var anotherTestUser = svc.CreateUser(anotherUser).Object;
            var updatedAsOwner = TestingHelper.UpdateUser(testUser, true);

            var ownerResp = svc.UpdateUser(updatedAsOwner);
            Assert.IsNotNull(ownerResp.Object);
        }

        //ToDo: Create a user, store user is following that has deals as prerequisite


        //[TestMethod]
        //public void UserReadStoreAlertTest()
        //{
        //    var readTime = DateTime.Now;
        //    var dateParam = new DateParameter();
        //    dateParam.datetime = readTime;
        //    var svc = new UserService();
        //    var resp = svc.UserReadStoreAlert(userId, storeId, dateParam);
        //    Assert.IsNotNull(resp.Object);
        //}

        //[TestMethod]
        //public void UserViewedDealTest()
        //{
        //    const string userId = TestingHelper.TestUserId;
        //    const string storeId = TestingHelper.TestStoreId;
        //    var readTime = DateTime.Now;
        //    var dateParam = new DateParameter();
        //    dateParam.datetime = readTime;

        //    var svc = new UserService();
        //    var resp = svc.UserViewedDeal(userId, storeId, dateParam);
        //    Assert.IsNotNull(resp.Object);
        //}

        //[TestMethod]
        //public void AssignDeviceToUserTest()
        //{
        //    //Create a new device, so assured that is not already assigned.
        //    var device = new Device();
        //    device.Id = Guid.NewGuid().ToString();
        //    device.Platform = TestingHelper.GetPlatform();
        //    device.DeviceToken = TestingHelper.GetDeviceToken(device.Platform);

        //    var tempSvc = new DeviceService();
        //    var tempResp = tempSvc.CreateDevice(device);
        //    string deviceId = tempResp.Object.Id;

        //    var svc = new UserService();
        //    var resp = svc.AssignDeviceToUser(TestingHelper.TestUserId, deviceId);
        //    Assert.IsTrue(resp.Success);
        //}

        
    }
}
