using System;

namespace LetsBuyLocal.SDK.Models
{
    /// <summary>
    /// Represents the reservation of a Deal by a User.
    /// </summary>
    /// <remarks>
    /// 1. User must have reservation (points) available - User.Field????
    /// - Increase with checkins
    /// 2. Can reserve Deal early if have KeyToTheCity
    /// - 10 checkins = a KeyToTheCity
    /// 3. Expires after 24 hours (when does clock start for early reservations????)
    /// Note: Renamed from "DealPurchase".
    /// </remarks>
    public class DealReservation : BaseEntity
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
        /// Gets or sets the receipt identifier.
        /// </summary>
        /// <value>
        /// The receipt identifier.
        /// </value>
        public string ReceiptId { get; set; }
        /// <summary>
        /// Gets or sets the reservation date.
        /// </summary>
        /// <value>
        /// The reservation date.
        /// </value>
        public DateTime ReservationDate { get; set; }
        /// <summary>
        /// Gets or sets the expiration date.
        /// </summary>
        /// <value>
        /// The expiration date.
        /// </value>
        public DateTime ExpirationDate { get; set; }
        /// <summary>
        /// Gets or sets the redemption identifier.
        /// </summary>
        /// <value>
        /// The redemption identifier.
        /// </value>
        public string RedemptionId { get; set; }

        /// <summary>
        /// Gets or sets the remaining days.
        /// </summary>
        /// <value>
        /// The remaining days.
        /// </value>
        public int RemainingDays { get; set; }

        /// <summary>
        /// Gets or sets the redemption.
        /// </summary>
        /// <value>
        /// The redemption.
        /// </value>
        public DealRedemption Redemption { get; set; }
    }
}
