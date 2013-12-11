using LetsBuyLocal.SDK.Services;
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
            var resp = TestingHelper.CreateTestStore();
            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void GetStoreByIdTest()
        {
            var svc = new StoreService();

            //Create a new store for this test
            var store = TestingHelper.CreateTestStore().Object;

            var resp = svc.GetStoreById(store.Id);
            Assert.IsNotNull(resp.Object);
        }
    }


}
