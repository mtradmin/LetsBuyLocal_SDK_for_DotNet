using System;
using LetsBuyLocal.SDK.Services;
using LetsBuyLocal.SDK.Tests.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LetsBuyLocal.SDK.Tests
{
    [TestClass]
    public class RewardServiceTest
    {
        [TestMethod]
        public void CreateRewardTest()
        {
            var svc = new RewardService();

            //Create a store for this test
            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.DarkRed, Colors.Gray);

            //Create a Reward object.
            var reward = TestingHelper.CreateNewRewardInMemory(store.Id);

            var resp = svc.CreateReward(reward);
            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void GetRewardByIdTest()
        {
            var svc = new RewardService();

            //Create a store for this test
            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.DarkRed, Colors.Gray);

            //Create a reward for this test
            var reward = TestingHelper.NewReward(svc, store.Id);

            var resp = svc.GetRewardById(reward.Id);
            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void UpdateRewardTest()
        {
            var svc = new RewardService();

            //Create a store for this test
            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.DarkRed, Colors.Gray);

            //Create a reward for this test
            var reward = TestingHelper.NewReward(svc, store.Id);

            //Modify the reward
            reward.Description = TestingHelper.GetRandomString(50);

            var resp = svc.UpdateReward(reward);
            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void DeleteRewardTest()
        {
            var svc = new RewardService();

            //Create a store for this test
            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.DarkRed, Colors.Gray);

            //Create a reward for this test
            var reward = TestingHelper.NewReward(svc, store.Id);

            var resp = svc.DeleteReward(reward.Id);
            Assert.IsNotNull(resp.Object);
        }
    }
}
