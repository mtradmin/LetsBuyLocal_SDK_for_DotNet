using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace LetsBuyLocal.SDK.Models
{

    /// <summary>
    /// Represents a Store entity
    /// </summary>
    /// <remarks>
    /// 1. A Store will not be visible unless it has at least one active Deal 
    ///    or the last active Deal expired within the last 15 days.
    /// 2. A User who is an owner of a Store is identified based on the User that creates the store.
    /// 3. Owners cannot be added to an existing store.
    /// </remarks>
    public class Store : BaseEntity
    {
        [Required]
        public string Website { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string Phone { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Zip { get; set; }
        public string Country { get; set; }
        [Required]
        public string TimeZone { get; set; }
        public string SundayOpenTime { get; set; }
        public string SundayCloseTime { get; set; }
        public string MondayOpenTime { get; set; }
        public string MondayCloseTime { get; set; }
        public string TuesdayOpenTime { get; set; }
        public string TuesdayCloseTime { get; set; }
        public string WednesdayOpenTime { get; set; }
        public string WednesdayCloseTime { get; set; }
        public string ThursdayOpenTime { get; set; }
        public string ThursdayCloseTime { get; set; }
        public string FridayOpenTime { get; set; }
        public string FridayCloseTime { get; set; }
        public string SaturdayOpenTime { get; set; }
        public string SaturdayCloseTime { get; set; }
        public string PayPalEmail { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string ReceiptId { get; set; }
        public string RewardProgramType { get; set; } //null (no Rewards Program), ELECTRONIC, PHYSICAL
        public bool Published { get; set; } //Soft delete flag
        public bool Offline { get; set; } //Visibility flag
        public DateTime? LastDealExpirationDate { get; set; }
        public bool PublishAlertsToFb { get; set; }
        public bool PublishDealsToFb{ get; set; }
        public string FbAccount { get; set; }
        public string FbPage { get; set; }
        public string FbPageAccessToken { get; set; }
        public bool HasStoreRegisteredForRewards { get; set; }
        public string CustomUrl { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
        public string TermsAndConditions { get; set; }
        public bool? DealsEnabled { get; set; }
        public bool? CheckInsEnabled { get; set; }


        public List<string> OwnerIds { get; set; }  //List of ids for users that have admin rights to the store

        public bool WizardStep1Complete { get; set; }
        public bool WizardStep2Complete { get; set; }
        public bool WizardStep3Complete { get; set; }

        public int UserRating { get; set; }

        public string MoreThanRewardsUserId { get; set; }

        public double Distance { get; set; }

        public int Followers { get; set; }

        public string PhoneString { get; set; }

        public IDictionary<string, string> HoursOfOperation { get; set; }

    }
}
