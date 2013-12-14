using LetsBuyLocal.SDK.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LetsBuyLocal.SDK.Tests
{
    [TestClass]
    public class ConfigurationServiceTest
    {
        [TestMethod]
        public void GetListOfStandardOptionsTest()
        {
            var svc = new ConfigurationService();

            var resp = svc.GetListOfStandardOptions();
            Assert.IsNotNull(resp.Object);
        }
    }
}
