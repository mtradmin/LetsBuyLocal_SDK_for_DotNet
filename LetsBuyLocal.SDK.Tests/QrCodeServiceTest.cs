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

            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.DarkMagenta, Colors.Gray, owner.Id);

            var resp = svc.GetQrCodeForStore(store.Id);
            Assert.IsNotNull(resp);

            //Now let's check if it can be written to file
            var path = TestingHelper.WriteImageToFilePath(store.Id, resp);

            Assert.IsTrue(File.Exists(path));
        }

        [TestMethod]
        public void GetQrCodeForDealTest()
        {
            var svc = new QrCodeService();

            //Create a store for this test.
            var userSvc = new UserService();
            var owner = TestingHelper.NewUser(userSvc, true);

            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.Blue, Colors.Gray, owner.Id);

            //Create a deal for this store
            var dealSvc = new DealService();
            var deal = TestingHelper.CreateTestDealInMemory(store);
            var dealResp = dealSvc.CreateDeal(deal);

            var resp = svc.GetQrCodeForDeal(dealResp.Object.Id);
            Assert.IsNotNull(resp);

            //Now let's check if it can be written to file
            var path = TestingHelper.WriteImageToFilePath(deal.Id, resp);

            Assert.IsTrue(File.Exists(path));
        }

        [TestMethod]
        public void GetQrCodeTest()
        {
            var svc = new QrCodeService();

            const string code = "I am a QRCode";
            var resp = svc.GetQrCode(code);
            Assert.IsNotNull(resp);

            //Now let's check if it can be written to file
            var pathUser = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var pathDownload = Path.Combine(pathUser, "Downloads");
            var imageFolder = ConfigurationManager.AppSettings["ImagePath"];

            var sb = new StringBuilder();
            sb.Append(pathDownload);
            sb.Append(imageFolder);
            sb.Append(code);
            sb.Append(".png");
            var path = sb.ToString();

            if (!Directory.Exists(pathDownload + imageFolder))
                Directory.CreateDirectory(pathDownload + imageFolder);

            File.WriteAllBytes(path, resp);

            Assert.IsTrue(File.Exists(path));
        }
       

    }
}
