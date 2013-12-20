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
    /// </remarks>
    public class Reservation : BaseEntity
    {
        /// <summary>
        /// Identifies User reserving a Deal.
        /// </summary>
        public string UserId { get; set; } 
 
        /// <summary>
        /// Identifies Deal being reserved.
        /// </summary>
        public string DealId { get; set; }

        public DateTime IssuedDate { get; set; }

        /// <summary>
        /// Date User reserved the Deal
        /// </summary>
        public DateTime? ReservedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
