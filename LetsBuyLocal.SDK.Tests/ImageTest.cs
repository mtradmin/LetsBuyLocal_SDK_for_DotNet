using System;
using System.Collections.Generic;
using LetsBuyLocal.SDK.Services;
using LetsBuyLocal.SDK.Tests.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LetsBuyLocal.SDK.Tests
{
    [TestClass]
    public class ImageTest
    {
        [TestMethod]
        public void UploadImageTest()
        {
            bool copiedImage = false;
            var svc = new ImageService();
            var id = string.Empty;

            // Choose an image type randomly.
            var types = new[] {ImageTypes.Deals, ImageTypes.Stores, ImageTypes.Users};
            var random = new Random();
            int i = random.Next(0, 2);
            var imageType = types[i];

            if (imageType == ImageTypes.Deals)
            {
                //Will need to create a Deal and get its Id
                var dSvc = new DealService();

                //Create a new store for this test
                var storeSvc = new StoreService();
                var userSvc = new UserService();
                var owner = TestingHelper.NewUser(userSvc, true);

                var category = TestingHelper.GetRandomStoreCategory();
                var store = TestingHelper.NewStore(category, Colors.Green, Colors.DarkOrange, owner.Id);

                var deal = TestingHelper.CreateTestDealInMemory(store);
                var createdResp = dSvc.CreateDeal(deal);

                //Create an image to upload
                copiedImage = TestingHelper.AbleToCopyAndRenameSourceImage(createdResp.Object.Id);
                if (copiedImage)
                    id = createdResp.Object.Id;
            }
            else if (imageType == ImageTypes.Stores)
            {
                //Will need to create a Store and get its Id
                var userSvc = new UserService();
                var owner = TestingHelper.NewUser(userSvc, true);

                string category = TestingHelper.GetRandomStoreCategory();
                var store = TestingHelper.NewStore(category, Colors.Green, Colors.DarkOrange, owner.Id);

                //Create an image to upload
                copiedImage = TestingHelper.AbleToCopyAndRenameSourceImage(store.Id);
                if (copiedImage)
                    id = store.Id;
            }
            else
            {
                //Create a User and get its Id
                var uSvc = new UserService();
                var user = TestingHelper.NewUser(uSvc, false);

                //Create an image to upload
                copiedImage = TestingHelper.AbleToCopyAndRenameSourceImage(user.Id);
                if (copiedImage)
                    id = user.Id;
            }

            //Now, try to upload the image
            if (id != String.Empty)
            {
                var resp = svc.UploadImage(id, imageType);
                Assert.IsTrue(resp.Object);
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}
