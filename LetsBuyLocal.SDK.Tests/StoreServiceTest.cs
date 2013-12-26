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
            //Create a new store for this test
            var svc = new StoreService();
            var userSvc = new UserService();
            var owner = TestingHelper.NewUser(userSvc, true);

            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.Green, Colors.DarkOrange, owner.Id);

            //Create a deal for this test
            var dealSvc = new DealService();
            var deal = TestingHelper.CreateTestDealInMemory(store);
            var dealResp = dealSvc.CreateDeal(deal);
            if (dealResp.Object == null)
                throw new ApplicationException("Unable to create a deal as part of the set up for this test.");

            //Create a user for this test
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
        public void GetLastStoreCheckinForUserTest()
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
            var checkinResp = svc.CheckInAtStore(store.Id, user.Id, geoPoint);  //Used to create the Checkin.

            //And get the Checkin
            var resp = svc.GetLastStoreCheckinForUser(store.Id, user.Id);
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

            var categoryA = TestingHelper.GetRandomStoreCategory();
            var storeA = TestingHelper.NewStore(categoryA, Colors.Brown, Colors.BurlyWood, owner.Id);

            //Now create another store for the same owner
            var categoryB = TestingHelper.GetRandomStoreCategory();
            var storeB = TestingHelper.NewStore(categoryA, Colors.DarkRed, Colors.BurlyWood, owner.Id);

            //Now get these stores for this owner
            var resp = svc.GetStoresForOwner(owner.Id);
            Assert.IsNotNull(resp.Object);
            Assert.IsTrue(resp.Object.Count == 2);
        }

        [TestMethod]
        public void LocateStoreTest()
        {
            var svc = new StoreService();
            var dealSvc = new DealService();

            //Create a store at a location for this test
            var userSvc = new UserService();
            var owner = TestingHelper.NewUser(userSvc, true);

            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.Brown, Colors.BurlyWood, owner.Id);
            store.Published = true;

            //Create a published (active)  deal for this store
            var deal = TestingHelper.CreateTestDealInMemory(store);
            var testDeal = dealSvc.CreateDeal(deal).Object;
            var updatedDeal = TestingHelper.UpdateDeal(testDeal, true, DateTime.Now, DateTime.Now.AddDays(30));
            var activeDeal = dealSvc.UpdateDeal(updatedDeal).Object;        //Creates active deal               

            //Create a reward for this test
            var rewardSvc = new RewardService();
            var reward = TestingHelper.NewReward(rewardSvc, store.Id, 1);
            var rewardResp = rewardSvc.CreateReward(reward);
            Assert.IsNotNull(rewardResp.Object);

            //Now get its location
            var geoPointA = TestingHelper.GetGeoPoint();
            store = svc.UpdateStoreLocation(store.Id, geoPointA).Object;

            var resp = svc.LocateStore(geoPointA);
            bool isGreaterThanZero = resp.Object.Count> 0;
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
        public void GetStoreStatusTest()
        {
            var svc = new StoreService();
            var userSvc = new UserService();
            var dealSvc = new DealService();

            //Create a new store for this test
            var storeSvc = new StoreService();
            var owner = TestingHelper.NewUser(userSvc, true);

            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.Green, Colors.DarkOrange, owner.Id);

            //Create an unpublished (inactive) deal for this store
            var deal2 = TestingHelper.CreateTestDealInMemory(store);
            var inactiveDeal = dealSvc.CreateDeal(deal2).Object;            //Creates inactive deal

            //Create a published (active)  deal for this store
            var deal = TestingHelper.CreateTestDealInMemory(store);
            var testDeal = dealSvc.CreateDeal(deal).Object;
            var updatedDeal = TestingHelper.UpdateDeal(testDeal, true, DateTime.Now, DateTime.Now.AddDays(30));
            var activeDeal = dealSvc.UpdateDeal(updatedDeal).Object;        //Creates active deal               

            //Create a reward for this test
            var rewardSvc = new RewardService();
            var reward = TestingHelper.NewReward(rewardSvc, store.Id, 1);
            var rewardResp = rewardSvc.CreateReward(reward);
            Assert.IsNotNull(rewardResp.Object);

            var resp = svc.GetStoreStatus(store.Id);
            Assert.IsTrue(resp.Object.HasRewards);
            Assert.IsTrue(resp.Object.HasDeals);
            Assert.IsTrue(resp.Object.HasInactiveDeals);
        }

        [TestMethod]
        public void GetNumberStoreFollowersTest()
        {
            var svc = new StoreService();
            var userSvc = new UserService();

            //Create a store for this test.
            var owner = TestingHelper.NewUser(userSvc, true);
            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.CornflowerBlue, Colors.BurlyWood, owner.Id);

            //Create a user for this test
            var user = TestingHelper.NewUser(userSvc, false);

            //Update the user
            var stores = new[] { store.Id };
            var values = new ArrayOfValues { Values = stores };
            var listResp = userSvc.CreateListOfStoresUserFollowing(user.Id, values);    //Variable not used, but creates list!

            //Now check how many users following store.
            var resp = svc.GetNumberStoreFollowers(store.Id);
            Assert.IsTrue(resp.Object == 2);                                            //Owner and user
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

        /// <summary>
        /// Tests the add rewards card for user test.
        /// </summary>
        /// <remarks>Valid rewards numbers: NP1337, ET0251, and BT2126 for testing.</remarks>
        [TestMethod]
        public void AddRewardsCardForUserTest()
        {
            var svc = new StoreService();
            var userSvc = new UserService();

            //Create a store for this test
            var owner = TestingHelper.NewUser(userSvc, true);

            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.Brown, Colors.BurlyWood, owner.Id);

            //Create a user for this test
            var user = TestingHelper.NewUser(userSvc, false);

            //Create a rewardsNumber
            const string rewardsNumber = "NP1337"; //A valid rewards number for testing purposes.

            var resp = svc.AddRewardsCardForUser(store.Id, user.Id, rewardsNumber);
            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void RemoveRewardsCardForUserTest()
        {
            var svc = new StoreService();
            var userSvc = new UserService();

            //Create a store for this test
            var owner = TestingHelper.NewUser(userSvc, true);

            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.Brown, Colors.BurlyWood, owner.Id);

            //Create a user for this test
            var user = TestingHelper.NewUser(userSvc, false);

            //Create a rewardsNumber
            const string rewardsNumber = "NP1337"; //A valid rewards number for testing purposes.

            //Add a rewards card for the user
            var addResp = svc.AddRewardsCardForUser(store.Id, user.Id, rewardsNumber);

            var resp = svc.RemoveRewardsCardForUser(store.Id, user.Id);
            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void GetRewardsCardBalanceTest()
        {
            var svc = new StoreService();
            var userSvc = new UserService();

            //Create a store for this test
            var owner = TestingHelper.NewUser(userSvc, true);

            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.Brown, Colors.BurlyWood, owner.Id);

            //Create a user for this test
            var user = TestingHelper.NewUser(userSvc, false);

            //Create a rewardsNumber
            const string rewardsNumber = "NP1337"; //A valid rewards number for testing purposes.

            //Add a rewards card for the user
            var addResp = svc.AddRewardsCardForUser(store.Id, user.Id, rewardsNumber);

            var resp = svc.GetRewardsCardBalance(addResp.Object.ToString());
            Assert.IsNotNull(resp.Object.Data);
        }

        [TestMethod]
        public void GetRewardsCardInvoicesAndDetailsTest()
        {
            var svc = new StoreService();
            var userSvc = new UserService();

            //Create a store for this test
            var owner = TestingHelper.NewUser(userSvc, true);

            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.Brown, Colors.BurlyWood, owner.Id);

            //Create a user for this test
            var user = TestingHelper.NewUser(userSvc, false);

            //Create a rewardsNumber
            const string rewardsNumber = "NP1337"; //A valid rewards number for testing purposes.

            //Add a rewards card for the user
            var addResp = svc.AddRewardsCardForUser(store.Id, user.Id, rewardsNumber);

            var resp = svc.GetRewardsCardInvoicesAndDetails(addResp.Object.ToString(), 1, 1, true);
            Assert.IsNotNull(resp.Object.Data.Data);
        }

        [TestMethod]
        public void GetRewardsCardInvoiceDetailsTest()
        {
            var svc = new StoreService();
            var userSvc = new UserService();

            //Create a store for this test
            var owner = TestingHelper.NewUser(userSvc, true);

            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.Brown, Colors.BurlyWood, owner.Id);

            //Create a user for this test
            var user = TestingHelper.NewUser(userSvc, false);

            //Create a rewardsNumber
            const string rewardsNumber = "NP1337"; //A valid rewards number for testing purposes.

            //Add a rewards card for the user
            var addResp = svc.AddRewardsCardForUser(store.Id, user.Id, rewardsNumber);
            var mtrUserId = addResp.Object.ToString();

            //Get information from the list of invoices for an invoice to look for.
            var invoicesResp = svc.GetRewardsCardInvoicesAndDetails(addResp.Object.ToString(), 1, 1, true);
            var dealerId = invoicesResp.Object.Data.Data[0].DealerId;
            var invoiceId = invoicesResp.Object.Data.Data[0].Id;

            var resp = svc.GetRewardsCardInvoiceDetails(mtrUserId, dealerId, invoiceId);
            Assert.IsNotNull(resp.Object.Data);
        }

    }


}
