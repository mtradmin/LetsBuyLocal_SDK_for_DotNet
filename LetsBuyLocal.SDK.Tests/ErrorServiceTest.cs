using System;
using LetsBuyLocal.SDK.Models;
using LetsBuyLocal.SDK.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LetsBuyLocal.SDK.Tests
{
    [TestClass]
    public class ErrorServiceTest
    {
        [TestMethod]
        public void CreateErrorSuccess()
        {
            ErrorService svc = new ErrorService();
            Error error = new Error();
            error.UserId = "DEF456";
            error.StoreId = "ABC123";
            var resp = svc.CreateError(error);
            Assert.IsTrue(resp.Success);
        }

        //[TestMethod]
        //public void CreateErrorFailure()
        //{
        //    ErrorService svc = new ErrorService();
        //    Error error = new Error();
        //    error.UserId = "DEF456";
        //    error.StoreId = "ABC123";
        //    var resp = svc.CreateError(error);
        //    Assert.IsTrue((! resp.Success));

        //}
    }
}
