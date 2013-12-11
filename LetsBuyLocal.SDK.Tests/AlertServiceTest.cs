using LetsBuyLocal.SDK.Models;
using LetsBuyLocal.SDK.Shared;
using LetsBuyLocal.SDK.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LetsBuyLocal.SDK.Tests
{
    //[TestClass]
    //public class AlertServiceTest
    //{
    //    [TestMethod]
    //    public void CreateAlertTest()
    //    {
    //        var alert = new Alert();

    //        //Create a new store for this test.
    //        var store = new Store();
    //        store = TestingHelper.CreateTestStore().Object;

    //        alert.StoreId = store.Id;
    //        alert.Description = TestingHelper.GetRandomString(30);
    //        alert.Type = AlertTypes.StoreAlert;

    //        var svc = new AlertService();
    //        var resp = svc.CreateAlert(alert);

    //        Assert.IsNotNull(resp.Object);
    //    }

    //    [TestMethod]
    //    public void GetAlertTest()
    //    {
    //        //Create an alert for this test.
    //        var alert = TestingHelper.CreateNewTestAlertInMemory();
    //        var svc = new AlertService();
    //        var createResp = svc.CreateAlert(alert);

    //        var resp = svc.GetAlert(createResp.Object.Id);

    //        Assert.IsNotNull(createResp.Object);
    //    }

    //    //[TestMethod]
    //    //public void GetAlertListForStoreByTypeTest()
    //    //{
    //    //    var svc = new AlertService();
    //    //    var resp = svc.GetAlertListForStoreByType(TestingHelper.TestStoreId, AlertTypes.StoreAlert);

    //    //    Assert.IsNotNull(resp.Object);
    //    //}

    //    //[TestMethod]
    //    //public void GetAlertListForUserByStoreByTypeTest()
    //    //{
    //    //    var svc = new AlertService();
    //    //    var resp = svc.GetAlertListForUserByStoreByType(TestingHelper.TestStoreId, AlertTypes.StoreAlert,
    //    //        TestingHelper.TestUserId);

    //    //    Assert.IsNotNull(resp.Object);
    //    //}
    //}
}
