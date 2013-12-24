using System;

namespace LetsBuyLocal.SDK.Models
{
    /// <summary>
    /// Represents a key to the city, allowing a user to unlock deals early
    /// </summary>
    public class KeyToTheCity : BaseEntity
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public string UserId { get; set; }
        /// <summary>
        /// Gets or sets the issued date.
        /// </summary>
        /// <value>
        /// The issued date.
        /// </value>
        public DateTime IssuedDate { get; set; }
        /// <summary>
        /// Gets or sets the redeemed date.
        /// </summary>
        /// <value>
        /// The redeemed date.
        /// </value>
        public DateTime? RedeemedDate { get; set; }
        /// <summary>
        /// Gets or sets the deal identifier.
        /// </summary>
        /// <value>
        /// The deal identifier.
        /// </value>
        public string DealId { get; set; }
    }
}
