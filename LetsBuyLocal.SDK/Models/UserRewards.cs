using System;
namespace LetsBuyLocal.SDK.Models
{
    /// <summary>
    /// Represents the Data object contained within the Object returned when getting a rewards card balance.
    /// </summary>
    public class UserRewards
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the rewards number.
        /// </summary>
        /// <value>
        /// The rewards number.
        /// </value>
        public string RewardsNumber { get; set; }
        /// <summary>
        /// Gets or sets the total points.
        /// </summary>
        /// <value>
        /// The total points.
        /// </value>
        public int TotalPoints { get; set; }
        /// <summary>
        /// Gets or sets the maximum cashout.
        /// </summary>
        /// <value>
        /// The maximum cashout.
        /// </value>
        public decimal MaxCashout { get; set; }
        /// <summary>
        /// Gets or sets the next reward.
        /// </summary>
        /// <value>
        /// The next reward.
        /// </value>
        public decimal NextReward { get; set; }
        /// <summary>
        /// Gets or sets the total spent to next reward.
        /// </summary>
        /// <value>
        /// The total spent to next reward.
        /// </value>
        public decimal TotalSpentToNextReward { get; set; }
        /// <summary>
        /// Gets or sets the goal to next reward.
        /// </summary>
        /// <value>
        /// The goal to next reward.
        /// </value>
        public decimal GoalToNextReward { get; set; }
        /// <summary>
        /// Gets or sets the days to display rewards.
        /// </summary>
        /// <value>
        /// The days to display rewards.
        /// </value>
        public int DaysToDisplayRewards { get; set; }
        /// <summary>
        /// Gets or sets the last updated.
        /// </summary>
        /// <value>
        /// The last updated.
        /// </value>
        public DateTime LastUpdated { get; set; }
    }
}
