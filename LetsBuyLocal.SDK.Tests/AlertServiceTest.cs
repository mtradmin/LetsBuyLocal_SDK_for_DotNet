using LetsBuyLocal.SDK.Models;
using LetsBuyLocal.SDK.Shared;
using LetsBuyLocal.SDK.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LetsBuyLocal.SDK.Tests
{
    [TestClass]
    public class AlertServiceTest
    {
        [TestMethod]
        public void CreateAlertTest()
        {
            var alert = new Alert();
            alert.StoreId = "977572de-c1c2-4295-878f-447eb7485905";
            alert.Description = TestingHelper.GetRandomString(30);
            alert.Type = AlertTypes.StoreAlert;

            var svc = new AlertService();
            var resp = svc.CreateAlert(alert);

            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void GetAlertListForStoreByTypeTest()
        {
            const string storeId = "977572de-c1c2-4295-878f-447eb7485905";
            var type = AlertTypes.StoreAlert;

            var svc = new AlertService();
            var resp = svc.GetAlertListForStoreByType(storeId, type);
        }
    }
}
