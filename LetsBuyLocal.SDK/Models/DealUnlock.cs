using System;

namespace LetsBuyLocal.SDK.Models
{
    /// <summary>
    /// Represents the unlocking of a Deal.
    /// </summary>
    public class DealUnlock : BaseEntity
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
        /// Gets or sets the unlock date.
        /// </summary>
        /// <value>
        /// The unlock date.
        /// </value>
        public DateTime UnlockDate { get; set; }
        /// <summary>
        /// Gets or sets the receipt identifier.
        /// </summary>
        /// <value>
        /// The receipt identifier.
        /// </value>
        public string ReceiptId { get; set; }
    }
}
