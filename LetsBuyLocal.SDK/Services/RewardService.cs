using System.Collections.Generic;
using System.Text;
using LetsBuyLocal.SDK.Models;

namespace LetsBuyLocal.SDK.Services
{
    /// <summary>
    /// Handles CRUD operations for rewards.
    /// </summary>
    public class RewardService : BaseService
    {
        /// <summary>
        /// Creates the reward.
        /// </summary>
        /// <param name="reward">The reward.</param>
        /// <returns>A ResponseMessage containing an object of type Reward.</returns>
        public ResponseMessage<Reward> CreateReward(Reward reward)
        {
            var resp = Post<ResponseMessage<Reward>>("Reward", reward);
            return resp;
        }

        /// <summary>
        /// Gets the reward by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A ResponseMessage containing an object of type Reward.</returns>
        public ResponseMessage<Reward> GetRewardById(string id)
        {
            var resp = Get<ResponseMessage<Reward>>("Reward" + "/" + id);
            return resp;
        }

        /// <summary>
        /// Updates the reward.
        /// </summary>
        /// <param name="reward">The reward.</param>
        /// <returns>A ResponseMessage containing an object of type Reward.</returns>
        public ResponseMessage<Reward> UpdateReward(Reward reward)
        {
            var resp = Put<ResponseMessage<Reward>>("Reward" + "/" + reward.Id, reward);
            return resp;
        }

        /// <summary>
        /// Deletes the reward.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A ResponseMessage containing an object of type bool.</returns>
        public ResponseMessage<bool> DeleteReward(string id)
        {
            var resp = Delete<ResponseMessage<bool>>("Reward/" + id);
            return resp;
        }

        /// <summary>
        /// Lists all rewards for store.
        /// </summary>
        /// <param name="storeId">The store identifier.</param>
        /// <returns>A ResponseMessage containing an object of type IList Of Reward.</returns>
        public ResponseMessage<IList<Reward>> ListAllRewardsForStore(string storeId)
        {
            var sb = new StringBuilder();
            sb.Append("Reward");
            sb.Append("/");
            sb.Append("ListByStore");
            sb.Append("/");
            sb.Append(storeId);
            var path = sb.ToString();

            var resp = Get<ResponseMessage<IList<Reward>>>(path);
            return resp;
        }

        /// <summary>
        /// Updates the rewards sort order.
        /// </summary>
        /// <param name="rewards">A list of the rewards in desired order.</param>
        /// <returns>
        /// A ResponseMessage containing an object of type Boolean (True, if successful, else false).
        /// </returns>
        public ResponseMessage<bool> UpdateRewardsSortOrder(List<Reward> rewards)
        {
            var sb = new StringBuilder();
            sb.Append("Reward");
            sb.Append("/");
            sb.Append("Sort");
            var path = sb.ToString();

            var resp = Post<ResponseMessage<bool>>(path, rewards);
            return resp;
        }

        /// <summary>
        /// Gets the next reward for user from specified store.
        /// </summary>
        /// <param name="storeId">The store identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>A ResponseMessage containing an object of Type Reward</returns>
        public ResponseMessage<Reward> GetNextRewardForUser(string storeId, string userId)
        {
            var sb = new StringBuilder();
            sb.Append("Reward");
            sb.Append("/");
            sb.Append("Next");
            sb.Append("/");
            sb.Append(storeId);
            sb.Append("/");
            sb.Append("userId");
            var path = sb.ToString();

            var resp = Get<ResponseMessage<Reward>>(path);
            return resp;
        }

    }
}
