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

    }
}
