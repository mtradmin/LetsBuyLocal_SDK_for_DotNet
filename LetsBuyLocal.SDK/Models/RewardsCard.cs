namespace LetsBuyLocal.SDK.Models
{
    /// <summary>
    /// Represents a rewards card.
    /// </summary>
    public class RewardsCard : BaseEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public override string Id { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public string UserId { get; set; }
        /// <summary>
        /// Gets or sets the store identifier.
        /// </summary>
        /// <value>
        /// The store identifier.
        /// </value>
        public string StoreId { get; set; }
        /// <summary>
        /// Gets or sets the more than rewards user identifier.
        /// </summary>
        /// <value>
        /// The more than rewards user identifier.
        /// </value>
        public string MoreThanRewardsUserId { get; set; }
        /// <summary>
        /// Gets or sets the rewards card number.
        /// </summary>
        /// <value>
        /// The rewards card number.
        /// </value>
        public string RewardsCardNumber { get; set; }
    }
}
