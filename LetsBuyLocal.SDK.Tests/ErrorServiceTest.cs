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

            var error = new Error
            {
                UserId = "DEF456",
                StoreId = "ABC123",
                Screen = TestingHelper.GetRandomString(5),
                Api = ConfigurationManager.AppSettings["ApiVersion"],
                Data = TestingHelper.GetRandomString(100),
                Description = TestingHelper.GetRandomString(50)
            };

            var resp = svc.CreateError(error);
            Assert.IsTrue(resp.Success);
        }

    }
}
