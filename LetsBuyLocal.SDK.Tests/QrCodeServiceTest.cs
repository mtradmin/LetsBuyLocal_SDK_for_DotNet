using System;
using System.Configuration;
using System.IO;
using System.Text;
using LetsBuyLocal.SDK.Services;
using LetsBuyLocal.SDK.Tests.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LetsBuyLocal.SDK.Tests
{
    [TestClass]
    public class QrCodeServiceTest
    {
        [TestMethod]
        public void GetQrCodeForStoreTest()
        {
            var svc = new QrCodeService();

            //Create a store for this test.
            var userSvc = new UserService();
            var owner = TestingHelper.NewUser(userSvc, true);

            string category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.DarkMagenta, Colors.Gray, owner.Id);

            var resp = svc.GetQrCodeForStore(store.Id);
            Assert.IsNotNull(resp);

            //Now let's check if it can be written to file
            var pathUser = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var pathDownload = Path.Combine(pathUser, "Downloads");
            var imageFolder = ConfigurationManager.AppSettings["ImagePath"];

            var sb = new StringBuilder();
            sb.Append(pathDownload);
            sb.Append(imageFolder);
            sb.Append(store.Id);
            sb.Append(".png");
            var path = sb.ToString();

            File.WriteAllBytes(path, resp);

            Assert.IsTrue(File.Exists(path));
        }
    }
}
