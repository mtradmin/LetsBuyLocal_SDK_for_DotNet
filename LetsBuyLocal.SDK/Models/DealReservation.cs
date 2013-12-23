using System;

namespace LetsBuyLocal.SDK.Models
{
    /// <summary>
    /// Represents the reservation of a Deal by a User.
    /// </summary>
    /// <remarks>
    /// 1. User must have reservation (points) available - User.Field????
    ///     - Increase with checkins
    /// 2. Can reserve Deal early if have KeyToTheCity
    ///     - 10 checkins = a KeyToTheCity
    /// 3. Expires after 24 hours (when does clock start for early reservations????)
    /// 
    /// Note: Renamed from "DealPurchase".
    /// </remarks>
    public class DealReservation : BaseEntity
    {
        public string StoreId { get; set; }
        public string DealId { get; set; }
        public string UserId { get; set; }
        public string ReceiptId { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string RedemptionId { get; set; }

        public int RemainingDays { get; set; }

        public DealRedemption Redemption { get; set; }
    }
}
