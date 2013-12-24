using System;
using System.ComponentModel.DataAnnotations;

namespace LetsBuyLocal.SDK.Models
{
    /// <summary>
    /// Represents "pickup" of reserved Deal
    /// </summary>
    /// <remarks>
    /// Occurs automatically if user has Deal open and is at location.
    /// </remarks>
    public class StoreCheckin : BaseEntity
    {
        /// <summary>
        /// Gets or sets the store identifier.
        /// </summary>
        /// <value>
        /// The store identifier.
        /// </value>
        [Required]
        public string StoreId { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        [Required]
        public string UserId { get; set; }
        /// <summary>
        /// Gets or sets the checkin date.
        /// </summary>
        /// <value>
        /// The checkin date.
        /// </value>
        [Required]
        public DateTime CheckinDate { get; set; }
        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        [Required]
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the reward.
        /// </summary>
        /// <value>
        /// The reward.
        /// </value>
        public Reward Reward { get; set; }
    }
}
