using System;
using System.Configuration;
using System.Text;
using LetsBuyLocal.SDK.Models;
using LetsBuyLocal.SDK.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LetsBuyLocal.SDK.Tests
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        public void CreateUserTest()
        {
            var user = new User();
            string baseEmailName = ConfigurationManager.AppSettings["BaseEmailName"];
            string atEmail = ConfigurationManager.AppSettings["AtEmail"];

            user.Email = GetEmailAlias(baseEmailName, atEmail);
            user.Password = TestingHelper.GetRandomString(8);
            user.FirstName = TestingHelper.GetRandomString(12);
            user.LastName = TestingHelper.GetRandomString(25); 
            user.MobilePhoneNumber = TestingHelper.GetRandomPhoneNo(10);
        
            var svc = new UserService();
            var resp = svc.CreateUser(user);

            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void GetUserByIdTest()
        {
            var svc = new UserService();
            var resp = svc.GetUserById(TestingHelper.TestUserId);
            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void UpdateUserTest()
        {
            var svc = new UserService();
            var user = svc.GetUserById(TestingHelper.TestUserId).Object;
            var updatedUser = UpdateUser(user);

            var resp = svc.UpdateUser(updatedUser);
            Assert.IsNotNull(resp.Object);
        }

        //[TestMethod]
        //public void SetWhenMessageReadByUserTest()S
        //{
        //    const string ID = "caa2298a-e8d5-4d76-bce8-c98ffb102b23";
        //    UserService svc = new UserService();
        //    var user = svc.GetUserById(ID).Object;

        //}
        //Todo: Create enough services to get an alert to read

        #region Private Methods

        /// <summary>
        /// Updates user.
        /// </summary>
        /// <param name="user">A User object to update</param>
        /// <returns>A user object that has been updated</returns>
        /// <remarks>
        /// Test method subject to change; often used to create information that can be retrieved and used
        /// </remarks>
        private User UpdateUser(User user)
        {
            //string baseEmailName = ConfigurationManager.AppSettings["BaseEmailName"];
            //string atEmail = ConfigurationManager.AppSettings["AtEmail"];

            //user.Email = getEmailAlias(baseEmailName, atEmail);
            //user.Password = TestingHelper.GetRandomString(8);
            //user.FirstName = TestingHelper.GetRandomString(12);
            //user.LastName = TestingHelper.GetRandomString(25); ;

            //user.Email = "margakkrumins@gmail.com";
            //user.Password = "gibber1234";
            //user.FirstName = "Marga";
            //user.LastName = "Krumins";
            if (user.Sex != null)
            {
                if (user.Sex.ToUpper() == "F")
                    user.Sex = "M";
                else if (user.Sex.ToUpper() == "M")
                    user.Sex = "F";
                else
                    user.Sex = "F";
            }
            else
            {
                user.Sex = "F";
            }
            user.MobilePhoneNumber = TestingHelper.GetRandomPhoneNo(10);
            user.l
            return user;
        }


        private string GetEmailAlias(string baseEmailName, string atEmail)
        {
            var sb = new StringBuilder();
            Guid guid = Guid.NewGuid();

            sb.Append(baseEmailName);
            sb.Append("+");
            sb.Append(guid.ToString());
            sb.Append(atEmail);
            var s = sb.ToString();
            return s;
        }

        #endregion
        
    }
}
