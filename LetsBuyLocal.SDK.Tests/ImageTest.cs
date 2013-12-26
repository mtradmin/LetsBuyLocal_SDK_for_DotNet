using System;
using System.IO;
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
            var svc = new ImageService();

            //Create an image
            var imageType = TestingHelper.GetRandomImageType();
            var id = TestingHelper.CreateImageOfSpecifiedType(imageType);

            //Now, try to upload the image
            if (id != String.Empty)
            {
                var resp = svc.UploadImage(id, imageType, TestingHelper.CreateImage("TESTING"));
                Assert.IsTrue(resp.Object);
            }
            else
            {
                Assert.Fail();
            }
        }


        [TestMethod]
        public void GetImageByIdTest()
        {
            var svc = new ImageService();

            //Create an image
            var imageType = TestingHelper.GetRandomImageType();
            var id = TestingHelper.CreateImageOfSpecifiedType(imageType);

            //Upload it
            var uploadResp = svc.UploadImage(id, imageType, TestingHelper.CreateImage("TESTING"));

            //Now get it
            var resp = svc.GetImageById(id);

            //Now let's check if it can be written to file
            var path = TestingHelper.WriteImageToFilePath(id, resp);

            Assert.IsTrue(File.Exists(path));
        }

        [TestMethod]
        public void GetImageByIdAndTypeTest()
        {
            var svc = new ImageService();

            //Create an image
            var imageType = TestingHelper.GetRandomImageType();
            var id = TestingHelper.CreateImageOfSpecifiedType(imageType);

            //Upload it
            var uploadResp = svc.UploadImage(id, imageType, TestingHelper.CreateImage("TESTING"));

            //Now get it
            var resp = svc.GetImageByIdAndType(id, imageType);

            //Now let's check if it can be written to file
            var path = TestingHelper.WriteImageToFilePath(id, resp);

            Assert.IsTrue(File.Exists(path));
        }
    }
}
