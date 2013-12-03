using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsBuyLocal.SDK.Models
{
    public class Reservation : BaseEntity
    {
        public string UserId { get; set; }  //User that made the reservation
        public string DealId { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime? ReservedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
