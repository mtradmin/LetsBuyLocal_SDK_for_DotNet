using LetsBuyLocal.SDK.Models;
using LetsBuyLocal.SDK.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LetsBuyLocal.SDK.Tests
{
    [TestClass]
    public class StoreServiceTest
    {
        [TestMethod]
        public void CreateStoreTest()
        {
            string website = "http://www.zebrastore" + TestingHelper.GetRandomString(10) + ".com";

            var store = new Store();
            store.Website = website;
            store.Name = TestingHelper.GetRandomString(30);
            store.Phone = TestingHelper.GetRandomPhoneNo(10);
            store.AddressLine1 = TestingHelper.GetRandomString(30);
            store.City = TestingHelper.GetRandomString(15);
            store.State = "WI";
            store.Zip = "53186";
            store.TimeZone = "CST";

            var svc = new StoreService();
            var resp = svc.CreateStore(store);
            Assert.IsNotNull(resp);
        }

        [TestMethod]
        public void GetStoreByIdTest()
        {
            const string id = "977572de-c1c2-4295-878f-447eb7485905";
            var svc = new StoreService();
            var resp = svc.GetStoreById(id);
            Assert.IsNotNull(resp.Object);
        }
    }


}
