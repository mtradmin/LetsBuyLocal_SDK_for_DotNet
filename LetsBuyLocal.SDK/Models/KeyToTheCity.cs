using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
