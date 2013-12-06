using System;

namespace LetsBuyLocal.SDK.Models
{
    public class Authorization : BaseEntity
    {
        public string UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
