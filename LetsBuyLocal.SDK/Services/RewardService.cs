using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
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
        /// <exception cref="System.ApplicationException">Unable to create a the reward.  + ex.Message</exception>
        public ResponseMessage<Reward> CreateReward(Reward reward)
        {
            try
            {
                var resp = Post<ResponseMessage<Reward>>("Reward", reward);
                return resp;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to create a the reward. " + ex.Message);
            }
        }

        /// <summary>
        /// Gets the reward by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A ResponseMessage containing an object of type Reward.</returns>
        /// <exception cref="System.ApplicationException">Unable to get the specified reward.  + ex.Message</exception>
        public ResponseMessage<Reward> GetRewardById(string id)
        {
            try
            {
                var resp = Get<ResponseMessage<Reward>>("Reward" + "/" + id);
                return resp;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to get the specified reward. " + ex.Message);
            }
        }

        /// <summary>
        /// Updates the reward.
        /// </summary>
        /// <param name="reward">The reward.</param>
        /// <returns>A ResponseMessage containing an object of type Reward.</returns>
        /// <exception cref="System.ApplicationException">Unable to update the specified reward. + ex.Message</exception>
        public ResponseMessage<Reward> UpdateReward(Reward reward)
        {
            try
            {
                var resp = Put<ResponseMessage<Reward>>("Reward" + "/" + reward.Id, reward);
                return resp;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to update the specified reward. " + ex.Message);
            }
        }

        /// <summary>
        /// Deletes the reward.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A ResponseMessage containing an object of type bool.</returns>
        /// <exception cref="System.ApplicationException">Unable to delete the specified reward.  + ex.Message</exception>
        public ResponseMessage<bool> DeleteReward(string id)
        {
            try
            {
                var resp = Delete<ResponseMessage<bool>>("Reward/" + id);
                return resp;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to delete the specified reward. " + ex.Message);
            }
        }
    }
}
