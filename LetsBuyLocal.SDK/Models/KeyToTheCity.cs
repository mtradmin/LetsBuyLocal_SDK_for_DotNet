using System;

namespace LetsBuyLocal.SDK.Models
{
    public class KeyToTheCity : BaseEntity
    {
        public string UserId { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime? RedeemedDate { get; set; }
        public string DealId { get; set; }
    }
}
