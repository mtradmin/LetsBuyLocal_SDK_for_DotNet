using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LetsBuyLocal.SDK.Services;

namespace LetsBuyLocal.SDK.Tests
{
    [TestClass]
    public class TrainingServiceTest
    {
        [TestMethod]
        public void GetVideosTest()
        {
            TrainingService svc = new TrainingService();
            var resp = svc.GetVideos();
            Assert.IsTrue(resp.Success);
        }
    }
}
