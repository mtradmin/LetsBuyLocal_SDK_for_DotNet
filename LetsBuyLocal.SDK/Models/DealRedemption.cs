using System;

namespace LetsBuyLocal.SDK.Models
{
    public class DealRedemption : BaseEntity
    {
        public string StoreId { get; set; }
        public string DealId { get; set; }
        public string UserId { get; set; }
        public DateTime RedemptionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
