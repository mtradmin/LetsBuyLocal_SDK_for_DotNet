using System;

namespace LetsBuyLocal.SDK.Models
{
    /// <summary>
    /// Represents the redemption of a Deal
    /// </summary>
    public class DealRedemption : BaseEntity
    {
        /// <summary>
        /// Gets or sets the store identifier.
        /// </summary>
        /// <value>
        /// The store identifier.
        /// </value>
        public string StoreId { get; set; }
        /// <summary>
        /// Gets or sets the deal identifier.
        /// </summary>
        /// <value>
        /// The deal identifier.
        /// </value>
        public string DealId { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public string UserId { get; set; }
        /// <summary>
        /// Gets or sets the redemption date.
        /// </summary>
        /// <value>
        /// The redemption date.
        /// </value>
        public DateTime RedemptionDate { get; set; }
        /// <summary>
        /// Gets or sets the expiration date.
        /// </summary>
        /// <value>
        /// The expiration date.
        /// </value>
        public DateTime ExpirationDate { get; set; }
    }
}
