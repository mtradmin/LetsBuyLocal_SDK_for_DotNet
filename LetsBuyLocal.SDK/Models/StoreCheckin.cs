using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LetsBuyLocal.SDK.Models
{
    public class StoreCheckin : BaseEntity
    {
        [Required]
        public string StoreId { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public DateTime CheckinDate { get; set; }
        [Required]
        public int Count { get; set; }

        public Reward Reward { get; set; }
    }
}
