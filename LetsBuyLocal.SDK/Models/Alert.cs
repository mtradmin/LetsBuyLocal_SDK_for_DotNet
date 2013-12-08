using System;
using System.ComponentModel.DataAnnotations;

namespace LetsBuyLocal.SDK.Models
{
    public class Alert : BaseEntity
    {
        [Required]
        public string StoreId { get; set; }
        public string EntityId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Type { get; set; } //STORE, DEAL, COUPON

        public DateTime? ScheduleFor { get; set; }

        public DateTime? DateSent { get; set; }

        public DateTime? PostedToFacebook { get; set; }

        public string FbPostError { get; set; }

        public bool Read { get; set; } //used internally to know if the Alert has been read
    }
}
