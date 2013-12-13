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
            //Create a new store for this test
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

        [TestMethod]
        public void GetStoreApiKeyTest()
        {
            var svc = new StoreService();

            //Create a new store for this test
            var store = TestingHelper.CreateTestStore().Object;

            var resp = svc.GetStoreApiKey(store.Id);
            Assert.IsNotNull(resp);
        }

        [TestMethod]
        public void UpdateStoreTest()
        {
            var svc = new StoreService();

            //Create a new store for this test
            var store = TestingHelper.CreateTestStore().Object;
            TestingHelper.UpdateStore(store);

            var resp = svc.UpdateStore(store.Id, store);
            Assert.IsNotNull(resp);
        }

        [TestMethod]
        public void UpdateStoreLocationTest()
        {
            var svc = new StoreService();

            //Create a new store for this test and do standard updates
            var store = TestingHelper.CreateTestStore().Object;
            store = TestingHelper.UpdateStore(store);
            store = svc.UpdateStore(store.Id, store).Object;

            //Now update the location
            var geoPoint = TestingHelper.GetGeoPoint();

            var resp = svc.UpdateStoreLocation(store.Id, geoPoint);
        }

    }


}
