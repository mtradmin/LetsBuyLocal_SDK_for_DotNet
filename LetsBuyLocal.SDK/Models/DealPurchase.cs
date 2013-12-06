using System;

namespace LetsBuyLocal.SDK.Models
{
    public class DealPurchase : BaseEntity
    {
        public string StoreId { get; set; }
        public string DealId { get; set; }
        public string UserId { get; set; }
        public string ReceiptId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string RedemptionId { get; set; }

        public int RemainingDays { get; set; }

        public DealRedemption Redemption { get; set; }
    }
}
