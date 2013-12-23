using System;

namespace LetsBuyLocal.SDK.Models
{
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
