using System;
using System.Threading;
using LetsBuyLocal.SDK.Models;
using LetsBuyLocal.SDK.Services;
using LetsBuyLocal.SDK.Tests.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LetsBuyLocal.SDK.Tests
{
    [TestClass]
    public class DealServiceTest
    {
        [TestMethod]
        public void CreateDealTest()
        {
            var svc = new DealService();

            //Create a new store for this test
            var storeSvc = new StoreService();
            var userSvc = new UserService();
            var owner = TestingHelper.NewUser(userSvc, true);

            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.Green, Colors.DarkOrange, owner.Id);

            //Now create the deal
            var deal = TestingHelper.CreateTestDealInMemory(store);
            var resp = svc.CreateDeal(deal);

            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void GetDealByIdTest()
        {
            var svc = new DealService();

            //Create a new store for this test
            var storeSvc = new StoreService();
            var userSvc = new UserService();
            var owner = TestingHelper.NewUser(userSvc, true);

            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.Green, Colors.DarkOrange, owner.Id);

            //Create a deal to get
            var deal = TestingHelper.CreateTestDealInMemory(store);
            var createdResp = svc.CreateDeal(deal);

            var id = createdResp.Object.Id;
            var resp = svc.GetDealById(id);

            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void UpdateDealTest()
        {
            var svc = new DealService();

            //Create a new store for this test
            var storeSvc = new StoreService();
            var userSvc = new UserService();
            var owner = TestingHelper.NewUser(userSvc, true);

            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.Green, Colors.DarkOrange, owner.Id);

            //Create a deal to update
            var deal = TestingHelper.CreateTestDealInMemory(store);
            var createdResp = svc.CreateDeal(deal);

            //Make updates
            var updatedDeal = TestingHelper.UpdateDeal(createdResp.Object, false, DateTime.Now, DateTime.Now.AddDays(3));
            var resp = svc.UpdateDeal(updatedDeal);
            Assert.IsNotNull(resp.Object);

            //Publish it
            Deal pubDeal = resp.Object;
            pubDeal.Published = true;
            var pubResp = svc.UpdateDeal(pubDeal);
            Assert.IsNotNull(pubResp.Object);
        }

        [TestMethod]
        public void DeleteDealTest()
        {
            var svc = new DealService();

            //Create a new store for this test
            var storeSvc = new StoreService();
            var userSvc = new UserService();
            var owner = TestingHelper.NewUser(userSvc, true);

            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.Green, Colors.DarkOrange, owner.Id);

            //Create a deal to delete
            var deal = TestingHelper.CreateTestDealInMemory(store);
            var createdResp = svc.CreateDeal(deal);

            var resp = svc.DeleteDeal(createdResp.Object.Id);
            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void GetNumberAvailableReservationsTest()
        {
            var svc = new DealService();

            //Create a new store for this test
            var storeSvc = new StoreService();
            var userSvc = new UserService();
            var owner = TestingHelper.NewUser(userSvc, true);

            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.Green, Colors.DarkOrange, owner.Id);

            //Create a deal for this test.
            var deal = TestingHelper.CreateTestDealInMemory(store);
            var createdResp = svc.CreateDeal(deal);

            //Check that the method was able to return its response, since the number could be 0.
            var resp = svc.GetNumberAvailableReservations(createdResp.Object.Id);
            Assert.IsTrue(resp.Success);
            //ToDo: Once users can reserve deals, add making reservations and recode test for anticipated number
        }

        [TestMethod]
        public void DealHasActiveReservationsTest()
        {
            var svc = new DealService();

            //Create a new store for this test
            var storeSvc = new StoreService();
            var userSvc = new UserService();
            var owner = TestingHelper.NewUser(userSvc, true);

            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.Green, Colors.DarkOrange, owner.Id);

            //Create a deal for this test.
            var deal = TestingHelper.CreateTestDealInMemory(store);
            var createdResp = svc.CreateDeal(deal);

            var resp = svc.DealHasActiveReservations(createdResp.Object.Id);
            Assert.IsTrue(resp.Success);
            //ToDo: Once users can reserve deals, add making a reservation and recode test for resp.Object isTrue
        }

        [TestMethod]
        public void UnpublishDealTest()
        {
            var svc = new DealService();

            //Create a new store for this test
            var storeSvc = new StoreService();
            var userSvc = new UserService();
            var owner = TestingHelper.NewUser(userSvc, true);

            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.Green, Colors.DarkOrange, owner.Id);

            //Create and publish a Deal to unpublish
            var deal = TestingHelper.CreateTestDealInMemory(store);
            var createdResp = svc.CreateDeal(deal);

            //Make updates (including publishing it).
            var updatedDeal = TestingHelper.UpdateDeal(createdResp.Object, true, DateTime.Now, DateTime.Now.AddDays(30));
            updatedDeal.Published = true;
            var pubDeal = svc.UpdateDeal(updatedDeal).Object;

            //Now unpublish it
            var resp = svc.UnpublishDeal(pubDeal.Id);
            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void GetLatestPublishedDealDate()
        {
            var svc = new DealService();
            
            //Create a new store for this test
            var storeSvc = new StoreService();
            var userSvc = new UserService();
            var owner = TestingHelper.NewUser(userSvc, true);

            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.Green, Colors.DarkOrange, owner.Id);
            
            //Create a deal and publish it
            var deal = TestingHelper.CreateTestDealInMemory(store);
            var createdResp = svc.CreateDeal(deal);

            //Make updates
            var updatedDeal = TestingHelper.UpdateDeal(createdResp.Object, true, DateTime.Now, DateTime.Now.AddDays(30));
            var pubDeal = svc.UpdateDeal(updatedDeal).Object;

            var resp = svc.GetLatestPublishedDealDate(pubDeal.StoreId);
            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void GetListOfDealsByStoreAndUser()
        {
            var svc = new DealService();

            //Create a new store for this test
            var storeSvc = new StoreService();
            var userSvc = new UserService();
            var owner = TestingHelper.NewUser(userSvc, true);

            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.Green, Colors.DarkOrange, owner.Id);

            //Create 3 published deals (expired, active, future)
            var dealA = TestingHelper.CreateTestDealInMemory(store);
            var createdRespA = svc.CreateDeal(dealA);

            var dealB = TestingHelper.CreateTestDealInMemory(store);
            var createdRespB = svc.CreateDeal(dealB);

            var dealC = TestingHelper.CreateTestDealInMemory(store);
            var createdRespC = svc.CreateDeal(dealC);

            //Set up some times
            var earliestTime = DateTime.Now;

            //Make updates for expired deal
            var updatedDealA = TestingHelper.UpdateDeal(createdRespA.Object, true, earliestTime, earliestTime.AddMinutes(1));
            updatedDealA.OnCompleteAction = OnCompleteAction.SaveForLater;
            var expiredDeal = svc.UpdateDeal(updatedDealA).Object;
            //Publish it
            expiredDeal.StartDate = DateTime.Now;
            expiredDeal.ExpirationDate = DateTime.Now.AddMinutes(1);
            expiredDeal = svc.UpdateDeal(expiredDeal).Object;

            //Make sure the expired deal has expired
            Thread.Sleep(60000);

            //Make updates for active deal
            var updatedDealB = TestingHelper.UpdateDeal(createdRespB.Object, true, earliestTime.AddMinutes(1), earliestTime.AddDays(30));
            updatedDealB.ExpirationDate = DateTime.Now.AddDays(30);
            updatedDealB.OnCompleteAction = OnCompleteAction.SaveForLater;
            var activeDeal = svc.UpdateDeal(updatedDealB).Object;

            //Make updates for future deal
            var updatedDealC = TestingHelper.UpdateDeal(createdRespC.Object, true, earliestTime.AddDays(35), earliestTime.AddDays(40));
            var futureDeal = svc.UpdateDeal(updatedDealC).Object;

            //Create a user and have user track this store
            var user = TestingHelper.NewUser(userSvc, false);
            user.StoreIds = new List<string> {expiredDeal.StoreId};
            var userResp = userSvc.UpdateUser(user);

            //Now see what we get
            var resp = svc.GetListOfDealsByStoreAndUser(userResp.Object.Id, new[] { expiredDeal.StoreId });
            Assert.IsNotNull(resp.Object);
            Assert.AreEqual(3, resp.Object.Count);
        }

        [TestMethod]
        public void GetListOfActiveDealsByStoreTest()
        {
            var svc = new DealService();
            var storeSvc = new StoreService();
            var userSvc = new UserService();

            //Create 2 new stores for this test
            var owner = TestingHelper.NewUser(userSvc, true);

            var categoryA = TestingHelper.GetRandomStoreCategory();
            var storeA = TestingHelper.NewStore(categoryA, Colors.Green, Colors.DarkOrange, owner.Id);

            var categoryB = TestingHelper.GetRandomStoreCategory();
            var storeB = TestingHelper.NewStore(categoryA, Colors.Green, Colors.DarkOrange, owner.Id);


            //Create a published deal for each store

            //Store A
            var dealStoreA = TestingHelper.CreateTestDealInMemory(storeA);
            var createdRespA = svc.CreateDeal(dealStoreA);

            var updatedDealStoreA = TestingHelper.UpdateDeal(createdRespA.Object, true, DateTime.Now, DateTime.Now.AddDays(1));
            var activeDealStoreA = svc.UpdateDeal(updatedDealStoreA).Object;                //Updates deal

            //Store B
            var dealStoreB = TestingHelper.CreateTestDealInMemory(storeB);
            var createdRespB = svc.CreateDeal(dealStoreB);

            var updatedDealStoreB = TestingHelper.UpdateDeal(createdRespB.Object, true, DateTime.Now, DateTime.Now.AddDays(1));
            var activeDealStoreB = svc.UpdateDeal(updatedDealStoreB).Object;                //Updates deal

            //Add both stores to a string array of stores.
            var stores = new[] {storeA.Id, storeB.Id};

            //Get an array of values (stores)
            var values = new ArrayOfValues {Values = stores};

            var resp = svc.GetListOfActiveDealsByStore(values);
            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void GetListOfLostDealsByStoreAndUserTest()
        {
            var svc = new DealService();
            var storeSvc = new StoreService();
            var userSvc = new UserService();

            //Create a new store for this test
            var owner = TestingHelper.NewUser(userSvc, true);

            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.Green, Colors.DarkOrange, owner.Id);

            //Create a published deal for the store
            var deal = TestingHelper.CreateTestDealInMemory(store);
            var createdResp = svc.CreateDeal(deal);
            var updatedDeal = TestingHelper.UpdateDeal(createdResp.Object, true, DateTime.Now, DateTime.Now.AddMilliseconds(1));
            var activeDeal = svc.UpdateDeal(updatedDeal).Object;                //Updates deal

            //Create a user who is following this store.
            var user = TestingHelper.NewUser(userSvc, false);

            var stores = new[] {store.Id};
            var values = new ArrayOfValues {Values = stores};

            var followingResp = userSvc.CreateListOfStoresUserFollowing(user.Id, values);

            //Get the deals lost by user at one of the stores.
            var resp = svc.GetListOfLostDealsByStoreAndUser(store.Id, user.Id);
            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void GetListOfActiveAndFutureDealsByStoreAndUserTest()
        {
            var svc = new DealService();
            var userSvc = new UserService();

            //Create a new owner for this test
            var owner = TestingHelper.NewUser(userSvc, true);

            //Create 2 stores
            var categoryA = TestingHelper.GetRandomStoreCategory();
            var storeA = TestingHelper.NewStore(categoryA, Colors.Green, Colors.DarkOrange, owner.Id);

            var categoryB = TestingHelper.GetRandomStoreCategory();
            var storeB = TestingHelper.NewStore(categoryB, Colors.CornflowerBlue, Colors.DarkMagenta, owner.Id);

            //Create a published deal for the storeA
            var dealA = TestingHelper.CreateTestDealInMemory(storeA);
            var createdRespA = svc.CreateDeal(dealA);
            var updatedDealA = TestingHelper.UpdateDeal(createdRespA.Object, true, DateTime.Now, DateTime.Now.AddDays(30));
            var activeDeal = svc.UpdateDeal(updatedDealA).Object;                //Updates deal

            //Create a future deal for storeB
            var dealB = TestingHelper.CreateTestDealInMemory(storeB);
            var createdRespB = svc.CreateDeal(dealB);
            var updatedDealB = TestingHelper.UpdateDeal(createdRespB.Object, true, DateTime.Now.AddDays(35), DateTime.Now.AddDays(40));
            var futureDeal = svc.UpdateDeal(updatedDealB).Object;               //Updates deal

            //Create a user who is following this store.
            var user = TestingHelper.NewUser(userSvc, false);

            var stores = new[] { storeA.Id, storeB.Id };
            var values = new ArrayOfValues { Values = stores };

            var followingResp = userSvc.CreateListOfStoresUserFollowing(user.Id, values);   //Sets user to following these stores

            var resp = svc.GetListOfActiveAndFutureDealsByStoreAndUser(user.Id, values);
            Assert.IsTrue(resp.Object.Count == 2);
        }

        [TestMethod]
        public void GetListOfAllDealsByStoreTest()
        {
            var svc = new DealService();
            var userSvc = new UserService();

            //Create a new owner for this test
            var owner = TestingHelper.NewUser(userSvc, true);

            //Create 3 stores
            var categoryA = TestingHelper.GetRandomStoreCategory();
            var storeA = TestingHelper.NewStore(categoryA, Colors.Green, Colors.DarkOrange, owner.Id);

            var categoryB = TestingHelper.GetRandomStoreCategory();
            var storeB = TestingHelper.NewStore(categoryB, Colors.CornflowerBlue, Colors.DarkMagenta, owner.Id);

            var categoryC = TestingHelper.GetRandomStoreCategory();
            var storeC = TestingHelper.NewStore(categoryC, Colors.Gray, Colors.DarkRed, owner.Id);

            //Create an expired deal for storeC
            var dealC = TestingHelper.CreateTestDealInMemory(storeC);
            var createdRespC = svc.CreateDeal(dealC);
            var updatedDealC = TestingHelper.UpdateDeal(createdRespC.Object, true, DateTime.Now,
                DateTime.Now.AddMilliseconds(1));                               //Updates deal

            //Create a published deal for the storeA
            var dealA = TestingHelper.CreateTestDealInMemory(storeA);
            var createdRespA = svc.CreateDeal(dealA);
            var updatedDealA = TestingHelper.UpdateDeal(createdRespA.Object, true, DateTime.Now, DateTime.Now.AddDays(30));
            var activeDeal = svc.UpdateDeal(updatedDealA).Object;                //Updates deal

            //Create a future deal for storeB
            var dealB = TestingHelper.CreateTestDealInMemory(storeB);
            var createdRespB = svc.CreateDeal(dealB);
            var updatedDealB = TestingHelper.UpdateDeal(createdRespB.Object, true, DateTime.Now.AddDays(35), DateTime.Now.AddDays(40));
            var futureDeal = svc.UpdateDeal(updatedDealB).Object;               //Updates deal

            //Build the array of values.
            var stores = new[] { storeA.Id, storeB.Id, storeC.Id };
            var values = new ArrayOfValues { Values = stores };

            var resp = svc.GetListOfAllDealsByStore(values);
            Assert.IsTrue(resp.Object.Count == 3);
        }

        [TestMethod]
        public void GetDealByRedemptionIdTest()
        {
            //var svc = new DealService();
            //var resp = svc.GetDealByRedemptionId(redemptionId);
            //Assert.IsNotNull(resp.Object);

            Assert.Fail();
        }


        [TestMethod]
        public void RedeemDealTest()
        {
            var svc = new DealService();

            //var resp = svc.RedeemDeal(dealId, purchaseId, userId);
            //Assert.IsNotNull(resp.Object);

            Assert.Fail();
            //ToDo: Write tests to split child objects out from this object.
        }

        [TestMethod]
        public void ReserveDealTest()
        {
            //var svc = new DealService();


            //var resp = svc.ReserveDeal(dealId, userId, storeId, receiptId);
            //Assert.IsNotNull(resp.Object);
            ////ToDo: Write tests to split child objects out from this object.
            Assert.Fail();
        }

        [TestMethod]
        public void UnlockDealTest()
        {
            var svc = new DealService();
            var storeSvc = new StoreService();
            var userSvc = new UserService();

            //Create a new store for this test
            var owner = TestingHelper.NewUser(userSvc, true);

            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.Green, Colors.DarkOrange, owner.Id);

            //Create a published deal for the store
            var deal = TestingHelper.CreateTestDealInMemory(store);
            var createdResp = svc.CreateDeal(deal);
            var updatedDeal = TestingHelper.UpdateDeal(createdResp.Object, true, DateTime.Now, DateTime.Now.AddMilliseconds(1));
            var activeDeal = svc.UpdateDeal(updatedDeal).Object;                

            //Create a user who is following this store.
            var user = TestingHelper.NewUser(userSvc, false);
            var stores = new[] { store.Id };
            var values = new ArrayOfValues { Values = stores };
            var followingResp = userSvc.CreateListOfStoresUserFollowing(user.Id, values);   //Updates user's list of stores is following

            var receiptId = TestingHelper.GetRandomString(15);

            var resp = svc.UnlockDeal(activeDeal.Id, user.Id, store.Id, receiptId);
            Assert.IsNotNull(resp);
            if (user.KeysToTheCity != null)
                Assert.IsNotNull(resp.Object);

            //ToDo: Once know how to create a user with KeysToTheCity, create a 2nd user following this deal and check that resp.Object is not null
        }
    }
}
