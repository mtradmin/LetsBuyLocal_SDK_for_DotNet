using System;
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

        /// <summary>
        /// Short hint about deal.
        /// </summary>
        /// <remarks>Required, if Published.</remarks>
        public string Hint { get; set; }  
              
        public int ExtensionDays { get; set; }

        /// <summary>
        /// Identifies action to be taken when deal completes (RunAgain/SaveForLater/Delete)
        /// </summary>
        public string OnCompleteAction { get; set; }    
        public DateTime? ExpirationDate { get; set; }

        /// <summary>
        /// Date deal starts
        /// </summary>
        /// <remarks>Cannot start until previous deal has expired.</remarks>
        public DateTime? StartDate { get; set; }     
        
        /// <summary>
        /// Gets or sets a value indicating whether [published] (Active).
        /// </summary>
        /// <value>
        ///   <c>true</c> if [published]; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// 1. Cannot modify a deal while this value is true.
        /// 2. Cannot set this value to false if this deal has any reservations made.
        /// </remarks>
        public bool Published { get; set; }
     
        
        public decimal? NormalPrice { get; set; }
        public int? PercentOff { get; set; }

        public string CopiedFromId { get; set; }
        public DateTime? PostedToFacebook { get; set; }
        public string FbPostError { get; set; }
        public bool PublishCompleteActionDone { get; set; }

        public bool HasActiveReservations { get; set; }

        public decimal? Savings { get; set; }

        public string NormalPriceString { get; set; }

        public string DealPriceString { get; set; }

        public string SavingsString { get; set; }

        public string PercentOffString { get; set; }

        public DealReservation UserPurchase { get; set; }

        public Store Store { get; set; }
    }
}
