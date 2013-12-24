using System;

namespace LetsBuyLocal.SDK.Models
{
    /// <summary>
    /// Represents a deal reservation
    /// </summary>
    public class Reservation : BaseEntity
    {
        /// <summary>
        /// Identifies User reserving a Deal.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public string UserId { get; set; }

        /// <summary>
        /// Identifies Deal being reserved.
        /// </summary>
        /// <value>
        /// The deal identifier.
        /// </value>
        public string DealId { get; set; }

        /// <summary>
        /// Gets or sets the issued date.
        /// </summary>
        /// <value>
        /// The issued date.
        /// </value>
        public DateTime IssuedDate { get; set; }

        /// <summary>
        /// Date User reserved the Deal
        /// </summary>
        /// <value>
        /// The reserved date.
        /// </value>
        public DateTime? ReservedDate { get; set; }
        /// <summary>
        /// Gets or sets the expiration date.
        /// </summary>
        /// <value>
        /// The expiration date.
        /// </value>
        public DateTime ExpirationDate { get; set; }
    }
}
