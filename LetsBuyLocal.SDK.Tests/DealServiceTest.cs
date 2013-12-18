using System;
using System.Management.Instrumentation;
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
            var updatedDeal = TestingHelper.UpdateDeal(createdResp.Object);
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


    }
}
