using LetsBuyLocal.SDK.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LetsBuyLocal.SDK.Tests
{
    [TestClass]
    public class AuthenticationTest
    {
        [TestMethod]
        public void AuthenticateTest()
        {
            var svc = new AuthenticationService();

            var resp = svc.Authenticate(TestingHelper.TestEmail, TestingHelper.TestPassword);
            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void RequestPasswordResetTest()
        {
            var svc = new AuthenticationService();

            var resp = svc.RequestPasswordReset(TestingHelper.TestEmail);
            Assert.IsTrue(resp.Success);
        }
    }
}
