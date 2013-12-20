using LetsBuyLocal.SDK.Services;
using LetsBuyLocal.SDK.Shared;
using LetsBuyLocal.SDK.Tests.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LetsBuyLocal.SDK.Tests
{
    [TestClass]
    public class AlertServiceTest
    {
        [TestMethod]
        public void CreateAlertTest()
        {
            var svc = new AlertService();

            //Create a new store for this test.
            var userSvc = new UserService();
            var owner = TestingHelper.NewUser(userSvc, true);
            string category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.Green, Colors.DarkOrange, owner.Id);

            //Create 3 different types of alerts for this test.
            var alertS = TestingHelper.NewAlert(svc, AlertTypes.StoreAlert, store.Id);
            var alertD = TestingHelper.NewAlert(svc, AlertTypes.DealAlert, store.Id);
            var alertC = TestingHelper.NewAlert(svc, AlertTypes.CouponAlert, store.Id);

            Assert.IsNotNull(alertS);
            Assert.IsNotNull(alertD);
            Assert.IsNotNull(alertC);
        }

        [TestMethod]
        public void GetAlertByIdTest()
        {
            var svc = new AlertService();

            //Create new store for this test.
            var userSvc = new UserService();
            var owner = TestingHelper.NewUser(userSvc, true);

            string category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.Green, Colors.DarkOrange, owner.Id);

            //Create 3 different types of alerts for this test.
            var alertS = TestingHelper.NewAlert(svc, AlertTypes.StoreAlert, store.Id);
            var alertD = TestingHelper.NewAlert(svc, AlertTypes.DealAlert, store.Id);
            var alertC = TestingHelper.NewAlert(svc, AlertTypes.CouponAlert, store.Id);

            //Get the 3 different types of alerts
            var respS = svc.GetAlertById(alertS.Id);
            var respD = svc.GetAlertById(alertD.Id);
            var respC = svc.GetAlertById(alertC.Id);

            Assert.IsNotNull(respS.Object);
            Assert.IsNotNull(respD.Object);
            Assert.IsNotNull(respC.Object);
        }

        [TestMethod]
        public void GetAlertListForStoreByTypeTest()
        {
            var svc = new AlertService();

            //Create a new store & alert for this test.
            var userSvc = new UserService();
            var owner = TestingHelper.NewUser(userSvc, true);

            string category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.Green, Colors.Blue, owner.Id);
            var alertA = TestingHelper.NewAlert(svc, AlertTypes.StoreAlert, store.Id);

            var resp = svc.GetAlertListForStoreByType(store.Id, alertA.Type);
            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void GetAlertListForUserByStoreByTypeTest()
        {
            var svc = new AlertService();

            //Create a user for this test
            var userSvc = new UserService();
            var user = TestingHelper.NewUser(userSvc, false);

            //Create a new store
            var owner = TestingHelper.NewUser(userSvc, true);

            string category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.Green, Colors.DarkOrange, owner.Id);

            //Create 2 types of alerts for the store
            //Should get
            var storeAlertA = TestingHelper.NewAlert(svc, AlertTypes.StoreAlert, store.Id);
            var storeAlertB = TestingHelper.NewAlert(svc, AlertTypes.StoreAlert, store.Id);
            //Should not get
            var couponAlert = TestingHelper.NewAlert(svc, AlertTypes.CouponAlert, store.Id);

            //Alerts created above are not reduntant code.  Creating conditions of test.
            var resp = svc.GetAlertListForUserByStoreByType(store.Id, AlertTypes.StoreAlert, user.Id);
            Assert.IsNotNull(resp.Object);
            Assert.AreEqual(2, resp.Object.Count);
        }

        [TestMethod]
        public void DeleteUserAlertTest()
        {
            var svc = new AlertService();

            //Create a user for this test
            var userSvc = new UserService();
            var user = TestingHelper.NewUser(userSvc, false);

            //Create a new store
            var owner = TestingHelper.NewUser(userSvc, true);

            string category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.Green, Colors.DarkOrange, owner.Id);

            //Create an alert for the store
            var alert = TestingHelper.NewAlert(svc, AlertTypes.StoreAlert, store.Id);

            //Now delete it
            var resp = svc.DeleteUserAlert(alert.Id, user.Id);
            Assert.IsTrue(resp.Object);

        }
    }
}
