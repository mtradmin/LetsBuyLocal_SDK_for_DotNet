using System;
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
            var owner = TestingHelper.CreateNewTestUserInMemory();
            var ownerResp = svc.CreateUser(owner);
            Assert.IsNotNull((ownerResp.Object));
        }

        [TestMethod]
        public void GetUserByIdTest()
        {
            var svc = new UserService();

            //Create a new user for this test.
            var user = TestingHelper.NewUser(svc, false);

            var resp = svc.GetUserById(user.Id);

            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void UpdateUserTest()
        {
            var svc = new UserService();

            //Create a new user for this test.
            var user = TestingHelper.NewUser(svc, false);
            var updatedUser = TestingHelper.UpdateUser(user);

            var resp = svc.UpdateUser(updatedUser);
            Assert.IsNotNull(resp.Object);

            //Now make another user that is an owner
            var ownerUser = TestingHelper.CreateNewTestUserInMemory();
            var ownerTestUser = svc.CreateUser(ownerUser).Object;
            var updatedAsOwner = TestingHelper.UpdateUser(ownerTestUser, true);

            var ownerResp = svc.UpdateUser(updatedAsOwner);
            Assert.IsNotNull(ownerResp.Object);
        }

        [TestMethod]
        public void UserReadStoreAlertTest()
        {
            var svc = new UserService();
            var readTime = DateTime.Now;
            var dateParam = new DateParameter {Datetime = readTime};

            //Create a user for this test.
            var user = TestingHelper.NewUser(svc, false);

            //Create a store for this test.
            var userSvc = new UserService();
            var owner = TestingHelper.NewUser(userSvc, true);

            string category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.Green, Colors.Brown, owner.Id);

            var resp = svc.UserReadStoreAlert(user.Id, store.Id, dateParam);
            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void UserViewedDealTest()
        {
            var svc = new UserService();
            
            var readTime = DateTime.Now;
            var dateParam = new DateParameter {Datetime = readTime};

            //Create a user for this test.
            var user = TestingHelper.NewUser(svc, false);

            //Create a store for this test.
            var userSvc = new UserService();
            var owner = TestingHelper.NewUser(userSvc, true);

            string category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.DarkRed, Colors.Gray, owner.Id);

            var resp = svc.UserViewedDeal(user.Id, store.Id, dateParam);
            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void CreateListOfStoresUserFollowingTest()
        {
            var svc = new UserService();

            //Create a new user for this test
            var user = TestingHelper.NewUser(svc, false);

            //Create two new stores to be added to an ArrayOfValues
            var owner = TestingHelper.NewUser(svc, true);

            string categoryA = TestingHelper.GetRandomStoreCategory();
            var storeA = TestingHelper.NewStore(categoryA, Colors.Green, Colors.CornflowerBlue, owner.Id);

            string categoryB = TestingHelper.GetRandomStoreCategory();
            var storeB = TestingHelper.NewStore(categoryB, Colors.Blue, Colors.CornflowerBlue, owner.Id);

            //Add the two stores' Ids to an ArrayOfValues object
            var storesInit = new[] {storeA.Id, storeB.Id};
            var valuesInit = new ArrayOfValues {Values = storesInit};

            //Test creation of initial list
            var initResp = svc.CreateListOfStoresUserFollowing(user.Id, valuesInit);
            Assert.IsNotNull(initResp.Object);

            //Test modification of list
            //Add
            string category = TestingHelper.GetRandomStoreCategory();
            var storeC = TestingHelper.NewStore(category, Colors.Green, Colors.DarkOrange, owner.Id);

            var storesAdd = new[] { storeA.Id, storeB.Id, storeC.Id };
            var valuesAdd = new ArrayOfValues { Values = storesAdd };
            var addResp = svc.CreateListOfStoresUserFollowing(user.Id, valuesAdd);
            Assert.IsNotNull(addResp.Object);

            //Remove
            var storesRemove = new[] { storeB.Id, storeC.Id };
            var valuesRemove = new ArrayOfValues { Values = storesRemove };
            var removeResp = svc.CreateListOfStoresUserFollowing(user.Id, valuesRemove);
            Assert.IsNotNull(removeResp.Object);

            //Test deletion of list
            var valuesDelete = new ArrayOfValues {Values = null};
            var delResp = svc.CreateListOfStoresUserFollowing(user.Id, valuesDelete);
            var num = delResp.Object.Count;
            Assert.IsNotNull(delResp.Object);
            Assert.AreEqual(0, num);

        }

        [TestMethod]
        public void AssignDeviceToUserTest()
        {
            var svc = new UserService();
            var deviceSvc = new DeviceService();

            //Create a new user for this test.
            var user = TestingHelper.NewUser(svc, false);

            //Create a new device, so assured that is not already assigned.
            var device = new Device
            {
                Id = Guid.NewGuid().ToString(), 
                Platform = TestingHelper.GetPlatform()
            };
            device.DeviceToken = TestingHelper.GetDeviceToken(device.Platform);

            var createResp = deviceSvc.CreateDevice(device);
            string deviceId = createResp.Object.Id;

            var resp = svc.AssignDeviceToUser(user.Id, deviceId);

            Assert.IsTrue(resp.Success);
        }
    }
}
