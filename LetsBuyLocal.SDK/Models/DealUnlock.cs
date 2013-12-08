using System;

namespace LetsBuyLocal.SDK.Models
{
    public class DealUnlock : BaseEntity
    {
        public string StoreId { get; set; }
        public string DealId { get; set; }
        public string UserId { get; set; }
        public DateTime UnlockDate { get; set; }
        public string ReceiptId { get; set; }
    }
}
