using System.Configuration;
using LetsBuyLocal.SDK.Models;
using LetsBuyLocal.SDK.Services;
using LetsBuyLocal.SDK.Tests.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LetsBuyLocal.SDK.Tests
{
    [TestClass]
    public class ErrorServiceTest
    {
        [TestMethod]
        public void CreateErrorTest()
        {
            var svc = new ErrorService();
            var userSvc = new UserService();
            var storeSvc = new StoreService();

            //Create a new user for this test
            var user = TestingHelper.NewUser(userSvc, false);

            //Create a new store for this test
            var owner = TestingHelper.NewUser(userSvc, true);

            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.Green, Colors.DarkOrange, owner.Id);

            //Create an error for this test
            var error = new Error
            {
                UserId = user.Id,
                StoreId = store.Id,
                Screen = TestingHelper.GetRandomString(5),
                Api = ConfigurationManager.AppSettings["ApiVersion"],
                Data = TestingHelper.GetRandomString(100),
                Description = TestingHelper.GetRandomString(50)
            };

            //Now check if successfully create error
            var resp = svc.CreateError(error);
            Assert.IsTrue(resp.Object);
        }

    }
}
