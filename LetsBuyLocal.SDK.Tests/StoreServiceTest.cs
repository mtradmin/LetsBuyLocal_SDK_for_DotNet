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
            string category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, "green", "gold");
            Assert.IsNotNull(store);
        }

        [TestMethod]
        public void GetStoreByIdTest()
        {
            var svc = new StoreService();

            //Create a new store for this test
            string category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, "green", "gold");

            var resp = svc.GetStoreById(store.Id);
            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void GetStoreApiKeyTest()
        {
            var svc = new StoreService();

            //Create a new store for this test
            string category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, "green", "gold");

            var resp = svc.GetStoreApiKey(store.Id);
            Assert.IsNotNull(resp);
        }

        [TestMethod]
        public void UpdateStoreTest()
        {
            var svc = new StoreService();

            //Create a new store for this test
            string category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, "blue", "gold");
            TestingHelper.UpdateStore(store);

            var resp = svc.UpdateStore(store.Id, store);
            Assert.IsNotNull(resp);
        }

        [TestMethod]
        public void UpdateStoreLocationTest()
        {
            var svc = new StoreService();

            //Create a new store for this test and do standard updates
            string category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, "purple", "gold");
            store = TestingHelper.UpdateStore(store);
            store = svc.UpdateStore(store.Id, store).Object;

            //Now update the location
            var geoPoint = TestingHelper.GetGeoPoint();

            var resp = svc.UpdateStoreLocation(store.Id, geoPoint);
            Assert.IsNotNull(resp.Object);
        }

    }


}
