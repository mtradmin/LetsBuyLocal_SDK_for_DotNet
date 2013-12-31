using LetsBuyLocal.SDK.Models;
using LetsBuyLocal.SDK.Services;
using LetsBuyLocal.SDK.Tests.Shared;
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

            //Create a new user for this test.
            var user = TestingHelper.CreateNewTestUserInMemory();
            var userSvc = new UserService();
            var testUser = userSvc.CreateUser(user).Object;

            //Verify that only two properties are required for an existing user .
            var minUser = new User {Email = testUser.Email, Password = testUser.Password};

            var resp = svc.Authenticate(minUser);
            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void RequestPasswordResetTest()
        {
            var svc = new AuthenticationService();

            //Create a new user for this test.
            var user = TestingHelper.CreateNewTestUserInMemory();
            var userSvc = new UserService();
            var testUser = userSvc.CreateUser(user).Object;

            //Verify that only email is required for an existing user.
            var minUser = new User { Email = testUser.Email };

            var isSuccessResp = svc.RequestPasswordReset(minUser);
            Assert.IsTrue(isSuccessResp.Success);
        }
    }
}
