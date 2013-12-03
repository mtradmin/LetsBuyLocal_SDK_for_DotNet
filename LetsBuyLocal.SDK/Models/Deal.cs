using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LetsBuyLocal.SDK.Models
{
    public class Deal : BaseEntity
    {
        [Required]
        public string StoreId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public int TotalAvailable { get; set; }
        public string Hint { get; set; }
        public int ExtensionDays { get; set; }
        public string OnCompleteAction { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime? StartDate { get; set; }
        public bool Published { get; set; }
        public decimal? NormalPrice { get; set; }
        public int? PercentOff { get; set; }
        public string CopiedFromId { get; set; }
        public DateTime? PostedToFacebook { get; set; }
        public string FBPostError { get; set; }
        public bool PublishCompleteActionDone { get; set; }

        public bool HasActiveReservations { get; set; }

        public decimal? Savings { get; set; }

        public string NormalPriceString { get; set; }

        public string DealPriceString { get; set; }

        public string SavingsString { get; set; }

        public string PercentOffString { get; set; }

        public DealPurchase UserPurchase { get; set; }

        public Store Store { get; set; }
    }
}
