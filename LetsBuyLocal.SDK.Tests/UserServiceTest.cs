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

            user.Email = GetEmailAlias(baseEmailName, "@gmail.com");
            user.Password = GetRandomString(7);
            user.FirstName = GetRandomString(5);
            user.LastName = GetRandomString(7); ;
            user.MobilePhoneNumber = GetRandomString(10);
        
            UserService svc = new UserService();
            var resp = svc.CreateUser(user);

            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void GetUserByIdTest()
        {
            string id = "3872417b-3657-47df-8661-e13557a056d3";
            UserService svc = new UserService();
            var resp = svc.GetUserById(id);
            Assert.IsNotNull(resp.Object);
        }




        private string GetRandomString(int len)
        {
            Random r = new Random();
            string str = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
            StringBuilder sb = new StringBuilder();
            while ((len) > 0)
            {
                sb.Append(str[(int) r.NextDouble()*str.Length]);
                len--;
            }
            return sb.ToString();
        }

        private string GetEmailAlias(string baseEmailName, string atEmail)
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

        
    }
}
