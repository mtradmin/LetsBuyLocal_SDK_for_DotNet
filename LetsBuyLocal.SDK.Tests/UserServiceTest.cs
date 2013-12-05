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
            User user = new User();
            string baseEmailName = ConfigurationManager.AppSettings["BaseEmailName"];
            string atEmail = ConfigurationManager.AppSettings["AtEmail"];

            user.Email = getEmailAlias(baseEmailName, atEmail);
            user.Password = this.getRandomString(8);
            user.FirstName = this.getRandomString(12);
            user.LastName = this.getRandomString(25); ;
            user.MobilePhoneNumber = this.getRandomPhoneNo(10);
        
            UserService svc = new UserService();
            var resp = svc.CreateUser(user);

            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void GetUserByIdTest()
        {
            const string ID = "caa2298a-e8d5-4d76-bce8-c98ffb102b23";
            UserService svc = new UserService();
            var resp = svc.GetUserById(ID);
            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void UpdateUserTest()
        {
            const string ID = "caa2298a-e8d5-4d76-bce8-c98ffb102b23"; 
            UserService svc = new UserService();
            var user = svc.GetUserById(ID).Object;
            var updatedUser = this.updateUser(user);

            var resp = svc.UpdateUser(updatedUser);
            Assert.IsNotNull(resp.Object);
        }

        //[TestMethod]
        //public void SetWhenMessageReadByUserTest()
        //{
        //    const string ID = "caa2298a-e8d5-4d76-bce8-c98ffb102b23";
        //    UserService svc = new UserService();
        //    var user = svc.GetUserById(ID).Object;

        //}


        #region Private Methods

        private User updateUser(User user)
        {
            string baseEmailName = ConfigurationManager.AppSettings["BaseEmailName"];
            string atEmail = ConfigurationManager.AppSettings["AtEmail"];

            user.Email = getEmailAlias(baseEmailName, atEmail);
            user.Password = this.getRandomString(8);
            user.FirstName = this.getRandomString(12);
            user.LastName = this.getRandomString(25); ;
            user.MobilePhoneNumber = this.getRandomPhoneNo(10);
            return user;
        }

        private string getRandomString(int len)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var stringChars = new char[len];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new string(stringChars);
            return finalString;
        }

        private string getRandomPhoneNo(int len)
        {
            const string chars = "1234567890";
            var stringChars = new char[len];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new string(stringChars);
            return finalString;
        }

        private string getEmailAlias(string baseEmailName, string atEmail)
        {
            StringBuilder sb = new StringBuilder();
            string s = string.Empty;
            Guid guid = Guid.NewGuid();

            sb.Append(baseEmailName);
            sb.Append("+");
            sb.Append(guid.ToString());
            sb.Append(atEmail);
            s = sb.ToString();
            return s;
        }

        #endregion
        
    }
}
