﻿using System;
using System.Management.Instrumentation;
using System.Threading;
using LetsBuyLocal.SDK.Services;
using LetsBuyLocal.SDK.Tests.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LetsBuyLocal.SDK.Tests
{
    [TestClass]
    public class DealServiceTest
    {
        [TestMethod]
        public void CreateDealTest()
        {
            var svc = new DealService();

            var deal = TestingHelper.CreateTestDealInMemory();
            var resp = svc.CreateDeal(deal);

            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void GetDealByIdTest()
        {
            var svc = new DealService();

            //Create a deal to get
            var deal = TestingHelper.CreateTestDealInMemory();
            var createdResp = svc.CreateDeal(deal);

            var id = createdResp.Object.Id;
            var resp = svc.GetDealById(id);

            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void UpdateDealTest()
        {
            var svc = new DealService();

            //Create a deal to update
            var deal = TestingHelper.CreateTestDealInMemory();
            var createdResp = svc.CreateDeal(deal);

            //Make updates
            var updatedDeal = TestingHelper.UpdateDeal(createdResp.Object, DateTime.Now, DateTime.Now.AddDays(30));
            var resp = svc.UpdateDeal(updatedDeal);

            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void DeleteDealTest()
        {
            var svc = new DealService();

            //Create a deal to delete
            var deal = TestingHelper.CreateTestDealInMemory();
            var createdResp = svc.CreateDeal(deal);

            var resp = svc.DeleteDeal(createdResp.Object.Id);
            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void GetNumberAvailableReservationsTest()
        {
            var svc = new DealService();

            //Create a deal for this test.
            var deal = TestingHelper.CreateTestDealInMemory();
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

            //Create a deal for this test.
            var deal = TestingHelper.CreateTestDealInMemory();
            var createdResp = svc.CreateDeal(deal);

            var resp = svc.DealHasActiveReservations(createdResp.Object.Id);
            Assert.IsTrue(resp.Success);
            //ToDo: Once users can reserve deals, add making a reservation and recode test for resp.Object isTrue
        }

        [TestMethod]
        public void UnpublishDealTest()
        {
            var svc = new DealService();

            //Create and publish a Deal to unpublish
            var deal = TestingHelper.CreateTestDealInMemory();
            var createdResp = svc.CreateDeal(deal);

            //Make updates
            var updatedDeal = TestingHelper.UpdateDeal(createdResp.Object, DateTime.Now, DateTime.Now.AddDays(30));
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
            
            //ToDo: This will fail until can publish a deal; restest when that method works!
            //Create a deal and publish it
            var deal = TestingHelper.CreateTestDealInMemory();
            var createdResp = svc.CreateDeal(deal);

            //Make updates
            var updatedDeal = TestingHelper.UpdateDeal(createdResp.Object, DateTime.Now, DateTime.Now.AddDays(30));
            updatedDeal.Published = true;
            var pubDeal = svc.UpdateDeal(updatedDeal).Object;

            var resp = svc.GetLatestPublishedDealDate(pubDeal.StoreId);
            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void GetListOfDealsByStoreAndUser()
        {
            var svc = new DealService();

            //Create 3 published deals (expired, active, future)
            var dealA = TestingHelper.CreateTestDealInMemory();
            var createdRespA = svc.CreateDeal(dealA);

            var dealB = TestingHelper.CreateTestDealInMemory();
            var createdRespB = svc.CreateDeal(dealB);

            var dealC = TestingHelper.CreateTestDealInMemory();
            var createdRespC = svc.CreateDeal(dealC);

            //Set up some times
            var earliestTime = DateTime.Now;

            //Make updates for expired deal
            var updatedDealA = TestingHelper.UpdateDeal(createdRespA.Object, earliestTime, earliestTime.AddMilliseconds(60));
            updatedDealA.OnCompleteAction = OnCompleteAction.SaveForLater;
            var expiredDeal = svc.UpdateDeal(updatedDealA).Object;
            //Publish it
            expiredDeal.Published = true;
            expiredDeal = svc.UpdateDeal(expiredDeal).Object;

            //Make sure the expired deal has expired
            Thread.Sleep(60);

            //Make updates for active deal
            var updatedDealB = TestingHelper.UpdateDeal(createdRespB.Object, earliestTime.AddMilliseconds(61), earliestTime.AddDays(30));
            updatedDealB.ExpirationDate = DateTime.Now.AddDays(30);
            updatedDealB.OnCompleteAction = OnCompleteAction.SaveForLater;
            var activeDeal = svc.UpdateDeal(updatedDealB).Object;
            //Publish it
            activeDeal.Published = true;
            activeDeal = svc.UpdateDeal(activeDeal).Object;

            var updatedDealC = TestingHelper.UpdateDeal(createdRespC.Object, earliestTime.AddDays(35), earliestTime.AddDays(40));
            updatedDealC.ExpirationDate = DateTime.Now.AddDays(60);
            updatedDealC.OnCompleteAction = OnCompleteAction.RunAgain;
            var futureDeal = svc.UpdateDeal(updatedDealC).Object;
            //Publish it
            futureDeal.Published = true;
            futureDeal = svc.UpdateDeal(futureDeal).Object;

            //Create a user and have user track this store
            var userSvc = new UserService();
            var user = TestingHelper.NewUser(userSvc);
            user.StoreIds.Add(expiredDeal.Id);
            var userResp = userSvc.UpdateUser(user);

            //Now see what we get
            var resp = svc.GetListOfDealsByStoreAndUser(userResp.Object.Id);
            Assert.IsNotNull(resp.Object);
            Assert.AreEqual(3, resp.Object.Count);
        }

    }
}
