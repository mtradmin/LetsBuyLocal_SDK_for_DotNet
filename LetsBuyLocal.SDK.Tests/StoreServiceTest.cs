using System;
using LetsBuyLocal.SDK.Models;
using LetsBuyLocal.SDK.Services;
using LetsBuyLocal.SDK.Shared;
using LetsBuyLocal.SDK.Tests.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LetsBuyLocal.SDK.Tests
{
    [TestClass]
    public class StoreServiceTest
    {
        [TestMethod]
        public void CreateStoreTest()
        {
            //Create a new store for this test
            var userSvc = new UserService();
            var owner = TestingHelper.NewUser(userSvc, true);
            string category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.Green, Colors.DarkOrange, owner.Id);
            Assert.IsNotNull(store);
        }

        [TestMethod]
        public void GetStoreByIdTest()
        {
            var svc = new StoreService();

            //Create a new store for this test
            var userSvc = new UserService();
            var owner = TestingHelper.NewUser(userSvc, true);

            string category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.Green, Colors.DarkOrange, owner.Id);

            var resp = svc.GetStoreById(store.Id);
            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void DeleteStoreTest()
        {
            var svc = new StoreService();

            //Create a new store for this test
            var userSvc = new UserService();
            var owner = TestingHelper.NewUser(userSvc, true);

            string category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.Green, Colors.DarkOrange, owner.Id);

            var resp = svc.DeleteStore(store.Id);
            Assert.IsTrue(resp.Object);
        }

        [TestMethod]
        public void GetStoreByUrlTest()
        {
            var svc = new StoreService();

            //Create a new store for this test
            var userSvc = new UserService();
            var owner = TestingHelper.NewUser(userSvc, true);

            string category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.Green, Colors.BurlyWood, owner.Id);

            var resp = svc.GetStoreByUrl(store);
            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void GetStoreApiKeyTest()
        {
            var svc = new StoreService();

            //Create a new store for this test
            var userSvc = new UserService();
            var owner = TestingHelper.NewUser(userSvc, true);

            string category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.Green, Colors.DarkOrange, owner.Id);

            var resp = svc.GetStoreApiKey(store.Id);
            Assert.IsNotNull(resp);
        }

        [TestMethod]
        public void UpdateStoreTest()
        {
            var svc = new StoreService();

            //Create a new store for this test
            var userSvc = new UserService();
            var owner = TestingHelper.NewUser(userSvc, true);

            string category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.Blue, Colors.DarkOrange, owner.Id);
            TestingHelper.UpdateStore(store);

            var resp = svc.UpdateStore(store.Id, store);
            Assert.IsNotNull(resp);
        }

        [TestMethod]
        public void LoadStoreDetailsByUserTest()
        {
            var svc = new StoreService();

            //Create a deal (and store) for this test
            var dealSvc = new DealService();
            var deal = TestingHelper.CreateTestDealInMemory();
            var dealResp = dealSvc.CreateDeal(deal);
            if (dealResp.Object == null)
                throw new ApplicationException("Unable to create a deal as part of the set up for this test.");

            //Create a user for this test
            var userSvc = new UserService();
            var user = TestingHelper.NewUser(userSvc, false);
            if (user == null)
                throw new ApplicationException("Unable to create a user as part of the set up for this test.");

            //Create an alert for the store for this test
            var alertSvc = new AlertService();
            var alertA = TestingHelper.NewAlert(alertSvc, AlertTypes.StoreAlert, deal.StoreId);
            if (alertA == null)
                throw new ApplicationException("Unable to create an alert message as part of the setup for this test.");

            var resp = svc.LoadStoreDetailsByUser(deal.StoreId, user.Id);
            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void UpdateStoreLocationTest()
        {
            var svc = new StoreService();

            //Create a new store for this test and do standard updates
            var userSvc = new UserService();
            var owner = TestingHelper.NewUser(userSvc, true);

            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.DarkMagenta, Colors.DarkOrange, owner.Id);
            store = TestingHelper.UpdateStore(store);
            store = svc.UpdateStore(store.Id, store).Object;

            //Now update the location
            var geoPoint = TestingHelper.GetGeoPoint();

            var resp = svc.UpdateStoreLocation(store.Id, geoPoint);
            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void LinkStoreToFacebookAccountTest()
        {
            try
            {
                var svc = new StoreService();

                //Create a store for this test.
                var userSvc = new UserService();
                var owner = TestingHelper.NewUser(userSvc, true);

                var category = TestingHelper.GetRandomStoreCategory();
                var store = TestingHelper.NewStore(category, Colors.Brown, Colors.BurlyWood, owner.Id);

                var settings = new FBSettings
                {
                    Account = TestingHelper.GetRandomNumeric(9),
                    Page = "http://www.facebook.com/" + store.Name,
                    PageAccessToken = TestingHelper.GetRandomString(195),
                    PublishAlerts = true,
                    PublishDeals = true
                };

                var resp = svc.LinkStoreToFacebookAccount(store.Id, settings);
                Assert.IsNotNull(resp.Object);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to link specified store to Facebook account. " + ex.Message);
            }
        }

        [TestMethod]
        public void RemoveFacebookAcccountFromStoreTest()
        {
            var svc = new StoreService();

            //Create a store for this test.
            var userSvc = new UserService();
            var owner = TestingHelper.NewUser(userSvc, true);

            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.Brown, Colors.BurlyWood, owner.Id);

            //Link its Facebook settings
            var settings = new FBSettings
            {
                Account = TestingHelper.GetRandomNumeric(9),
                Page = "http://www.facebook.com/" + store.Name,
                PageAccessToken = TestingHelper.GetRandomString(195),
                PublishAlerts = true,
                PublishDeals = true
            };

            var settingsResp = svc.LinkStoreToFacebookAccount(store.Id, settings);

            //Now remove them and check result
            var resp = svc.RemoveFacebookAccountFromStore(store.Id);
            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void OrderMediaKitTest()
        {
            var svc = new StoreService();

            //Create a store for this test.
            var userSvc = new UserService();
            var owner = TestingHelper.NewUser(userSvc, true);

            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.Brown, Colors.BurlyWood, owner.Id);

            //Now test ordering a media kit
            var resp = svc.OrderMediaKit(store.Id, owner);
            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void EmailMediaKitTest()
        {
            var svc = new StoreService();

            //Create a store for this test.
            var userSvc = new UserService();
            var owner = TestingHelper.NewUser(userSvc, true);

            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.Brown, Colors.BurlyWood, owner.Id);

            //Now test by submitting an email for a media kit for a user
            var resp = svc.EmailMediaKit(store.Id, owner);
            Assert.IsNotNull(resp.Object);

        }

        [TestMethod]
        public void StoreExistsForUrlTest()
        {
            var svc = new StoreService();

            //Create a store for this test.
            var userSvc = new UserService();
            var owner = TestingHelper.NewUser(userSvc, true);

            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.CornflowerBlue, Colors.BurlyWood, owner.Id);

            //Now check if we can find it by Url
            var resp = svc.StoreExistsForUrl(store.Website);
            Assert.IsNotNull(resp);
        }

        [TestMethod]
        public void GetStoresForOwnerTest()
        {
            var svc = new StoreService();

            //Create a store for this test.
            var userSvc = new UserService();
            var owner = TestingHelper.NewUser(userSvc, true);

            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.Brown, Colors.BurlyWood, owner.Id);


            //Now get this store for this owner
            var resp = svc.GetStoresForOwner(owner.Id);
            Assert.IsNotNull(resp.Object);
            //ToDo: Once know how store-owner relationship maintained, create 2 stores for owner and Assert count == 2.
        }

        [TestMethod]
        public void LocateStoreTest()
        {
            var svc = new StoreService();

            //Create a store at a location for this test
            var userSvc = new UserService();
            var owner = TestingHelper.NewUser(userSvc, true);

            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.Brown, Colors.BurlyWood, owner.Id);
            store.Published = true;
            var geoPointA = TestingHelper.GetGeoPoint();
            store = svc.UpdateStoreLocation(store.Id, geoPointA).Object;

            var resp = svc.LocateStore(geoPointA);
            bool isGreaterThanZero = resp.Object.Count > 0;
            Assert.IsTrue(isGreaterThanZero);
        }
        
        [TestMethod]
        public void CheckIfIsAtStoreTest()
        {
            var svc = new StoreService();

            //Create a store at a location for this test
            var userSvc = new UserService();
            var owner = TestingHelper.NewUser(userSvc, true);

            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.Brown, Colors.BurlyWood, owner.Id);
            var geoPointA = TestingHelper.GetGeoPoint();
            store = svc.UpdateStoreLocation(store.Id, geoPointA).Object;

            var resp = svc.CheckIfIsAtStore(store.Id, geoPointA);
            Assert.IsTrue(resp.Object);
        }


        [TestMethod]
        public void CheckInAtStoreTest()
        {
            var svc = new StoreService();
            var userSvc = new UserService();

            //Create a store for this test
            var owner = TestingHelper.NewUser(userSvc, true);

            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.Brown, Colors.BurlyWood, owner.Id);

            //Create a user for this test
            var user = TestingHelper.NewUser(userSvc, false);

            //Co-locate the store and user.
            var geoPoint = TestingHelper.GetGeoPoint();
            store = svc.UpdateStoreLocation(store.Id, geoPoint).Object;

            //Now check the user in at store
            var resp = svc.CheckInAtStore(store.Id, user.Id, geoPoint);
            Assert.IsNotNull(resp.Object);
        }

    }


}
