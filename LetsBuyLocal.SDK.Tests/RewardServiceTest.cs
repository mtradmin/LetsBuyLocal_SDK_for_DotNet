using System.Collections.Generic;
using LetsBuyLocal.SDK.Models;
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
            var userSvc = new UserService();
            var owner = TestingHelper.NewUser(userSvc, true);
            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.DarkRed, Colors.Gray, owner.Id);

            //Create a Reward object.
            var reward = TestingHelper.CreateNewRewardInMemory(store.Id, 1);

            var resp = svc.CreateReward(reward);
            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void GetRewardByIdTest()
        {
            var svc = new RewardService();

            //Create a store for this test
            var userSvc = new UserService();
            var owner = TestingHelper.NewUser(userSvc, true);

            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.DarkRed, Colors.Gray, owner.Id);

            //Create a reward for this test
            var reward = TestingHelper.NewReward(svc, store.Id, 1);

            var resp = svc.GetRewardById(reward.Id);
            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void UpdateRewardTest()
        {
            var svc = new RewardService();

            //Create a store for this test
            var userSvc = new UserService();
            var owner = TestingHelper.NewUser(userSvc, true);

            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.DarkRed, Colors.Gray, owner.Id);

            //Create a reward for this test
            var reward = TestingHelper.NewReward(svc, store.Id, 1);

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
            var userSvc = new UserService();
            var owner = TestingHelper.NewUser(userSvc, true);

            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.DarkRed, Colors.Gray, owner.Id);

            //Create a reward for this test
            var reward = TestingHelper.NewReward(svc, store.Id, 1);

            var resp = svc.DeleteReward(reward.Id);
            Assert.IsNotNull(resp.Object);
        }

        [TestMethod]
        public void ListAllRewardsForStoreTest()
        {
            var svc = new RewardService();

            //Create a store for this test
            var userSvc = new UserService();
            var owner = TestingHelper.NewUser(userSvc, true);
            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.DarkRed, Colors.Gray, owner.Id);

            //Create a couple of Reward objects.
            var rewardA = TestingHelper.NewReward(svc, store.Id, 1);
            var rewardB = TestingHelper.NewReward(svc, store.Id, 2);

            var resp = svc.ListAllRewardsForStore(store.Id);
            Assert.IsTrue(resp.Object.Count == 2);
        }

        [TestMethod]
        public void UpdateRewardsSortOrderTest()
        {
            var svc = new RewardService();

            //Create a store for this test
            var userSvc = new UserService();
            var owner = TestingHelper.NewUser(userSvc, true);
            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.DarkRed, Colors.Gray, owner.Id);

            //Create a couple of Reward objects.
            var rewardA = TestingHelper.NewReward(svc, store.Id, 1);
            var rewardB = TestingHelper.NewReward(svc, store.Id, 2);

            //Get the original list
            var originalList = svc.ListAllRewardsForStore(store.Id).Object;

            //Swap the order in a new list
            var rewards = new List<Reward> {originalList[1], originalList[0]};

            var resp = svc.UpdateRewardsSortOrder(rewards);
            Assert.IsTrue(resp.Object);

            bool worked = originalList[0].SortOrder == rewards[1].SortOrder;
            if (! worked)
                Assert.Fail();
        }

        [TestMethod]
        public void GetNextRewardForUserTest()
        {
            var svc = new RewardService();
            var userSvc = new UserService();

            //Create a store for this test
            var owner = TestingHelper.NewUser(userSvc, true);
            var category = TestingHelper.GetRandomStoreCategory();
            var store = TestingHelper.NewStore(category, Colors.DarkRed, Colors.Gray, owner.Id);

            //ToDo: Recode how user gets associated with reward(s).
            //Create a user following this store
            var user = TestingHelper.NewUser(userSvc, false);
            var stores = new ArrayOfValues {Values = new[] {store.Id}};
            var following = userSvc.CreateListOfStoresUserFollowing(user.Id, stores);

            //Create a couple of Reward objects.
            var rewardA = TestingHelper.NewReward(svc, store.Id, 1);
            var rewardB = TestingHelper.NewReward(svc, store.Id, 2);

            var resp = svc.GetNextRewardForUser(store.Id, user.Id);
            Assert.IsNotNull(resp.Object);
        }
    }
}
