using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace LetsBuyLocal.SDK.Models
{

    /// <summary>
    /// Represents a store.
    /// </summary>
    /// <remarks>
    /// 1. A Store will not be visible unless it has at least one active Deal.
    ///    or the last active Deal expired within the last 15 days.
    /// 2. A User who is an owner of a Store is identified based on the User that creates the store.
    /// 3. Owners cannot be added to an existing store, only one that is in the process of being created.
    /// </remarks>
    public class Store : BaseEntity
    {
        /// <summary>
        /// Gets or sets the website.
        /// </summary>
        /// <value>
        /// The website.
        /// </value>
        [Required]
        public string Website { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>
        /// The phone.
        /// </value>
        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string Phone { get; set; }
        /// <summary>
        /// Gets or sets the address line1.
        /// </summary>
        /// <value>
        /// The address line1.
        /// </value>
        [Required]
        public string AddressLine1 { get; set; }
        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        [Required]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        /// <remarks>Must be in ConfigurationService.GetListOfStandardOptions State</remarks>
        [Required]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the zip.
        /// </summary>
        /// <value>
        /// The zip.
        /// </value>
        [Required]
        public string Zip { get; set; }

        /// <summary>
        /// Gets or sets the time zone.
        /// </summary>
        /// <value>
        /// The time zone.
        /// </value>
        /// <remarks>Must be in ConfigurationService.GetListOfStandardOptions TimeZone</remarks>
        [Required]
        public string TimeZone { get; set; }

        /// <summary>
        /// Gets or sets the Checkins enabled value.
        /// </summary>
        /// <value>
        /// The Checkins enabled value.
        /// </value>
        /// <remarks>Determines whether or not user will see the Rewards(Checkins) setup wizard.</remarks>
        public bool? CheckInsEnabled { get; set; }


        /// <summary>
        /// Gets or sets the latitude of store's cash register.
        /// </summary>
        /// <value>
        /// The latitude.
        /// </value>
        public decimal Latitude { get; set; }
        /// <summary>
        /// Gets or sets the longitude of store's cash register.
        /// </summary>
        /// <value>
        /// The longitude.
        /// </value>
        public decimal Longitude { get; set; }


        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        /// <remarks>Must be in ConfigurationService.GetListOfStandardOptions StoreCategory</remarks>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the address line2.
        /// </summary>
        /// <value>
        /// The address line2.
        /// </value>
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        /// <remarks>Must be in ConfigurationService.GetListOfStandardOptions Country</remarks>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the sunday open time.
        /// </summary>
        /// <value>
        /// The sunday open time.
        /// </value>
        public string SundayOpenTime { get; set; }
        /// <summary>
        /// Gets or sets the sunday close time.
        /// </summary>
        /// <value>
        /// The sunday close time.
        /// </value>
        public string SundayCloseTime { get; set; }
        /// <summary>
        /// Gets or sets the monday open time.
        /// </summary>
        /// <value>
        /// The monday open time.
        /// </value>
        public string MondayOpenTime { get; set; }
        /// <summary>
        /// Gets or sets the monday close time.
        /// </summary>
        /// <value>
        /// The monday close time.
        /// </value>
        public string MondayCloseTime { get; set; }
        /// <summary>
        /// Gets or sets the tuesday open time.
        /// </summary>
        /// <value>
        /// The tuesday open time.
        /// </value>
        public string TuesdayOpenTime { get; set; }
        /// <summary>
        /// Gets or sets the tuesday close time.
        /// </summary>
        /// <value>
        /// The tuesday close time.
        /// </value>
        public string TuesdayCloseTime { get; set; }
        /// <summary>
        /// Gets or sets the wednesday open time.
        /// </summary>
        /// <value>
        /// The wednesday open time.
        /// </value>
        public string WednesdayOpenTime { get; set; }
        /// <summary>
        /// Gets or sets the wednesday close time.
        /// </summary>
        /// <value>
        /// The wednesday close time.
        /// </value>
        public string WednesdayCloseTime { get; set; }
        /// <summary>
        /// Gets or sets the thursday open time.
        /// </summary>
        /// <value>
        /// The thursday open time.
        /// </value>
        public string ThursdayOpenTime { get; set; }
        /// <summary>
        /// Gets or sets the thursday close time.
        /// </summary>
        /// <value>
        /// The thursday close time.
        /// </value>
        public string ThursdayCloseTime { get; set; }
        /// <summary>
        /// Gets or sets the friday open time.
        /// </summary>
        /// <value>
        /// The friday open time.
        /// </value>
        public string FridayOpenTime { get; set; }
        /// <summary>
        /// Gets or sets the friday close time.
        /// </summary>
        /// <value>
        /// The friday close time.
        /// </value>
        public string FridayCloseTime { get; set; }
        /// <summary>
        /// Gets or sets the saturday open time.
        /// </summary>
        /// <value>
        /// The saturday open time.
        /// </value>
        public string SaturdayOpenTime { get; set; }
        /// <summary>
        /// Gets or sets the saturday close time.
        /// </summary>
        /// <value>
        /// The saturday close time.
        /// </value>
        public string SaturdayCloseTime { get; set; }

        /// <summary>
        /// Gets or sets the pay pal email.
        /// </summary>
        /// <value>
        /// The pay pal email.
        /// </value>
        public string PayPalEmail { get; set; }
        /// <summary>
        /// Gets or sets the receipt identifier.
        /// </summary>
        /// <value>
        /// The receipt identifier.
        /// </value>
        public string ReceiptId { get; set; }
        /// <summary>
        /// Gets or sets the type of the reward program.
        /// </summary>
        /// <value>
        /// The type of the reward program.
        /// </value>
        /// <remarks>null (no Rewards Program)/ELECTRONIC/PHYSICAL</remarks>
        public string RewardProgramType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [published].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [published]; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>Soft delete flag.</remarks>
        public bool Published { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether visible or not[offline].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [offline]; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// 1. Will automatically go offline after 15 days if has no published deals.
        /// 2. Will automatically come online when publish a deal.
        /// </remarks>
        public bool Offline { get; set; }

        /// <summary>
        /// Gets or sets the last deal expiration date.
        /// </summary>
        /// <value>
        /// The last deal expiration date.
        /// </value>
        public DateTime? LastDealExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [publish alerts to Facebook].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [publish alerts to Facebook]; otherwise, <c>false</c>.
        /// </value>
        public bool PublishAlertsToFb { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [publish deals to Facebook].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [publish deals to Facebook]; otherwise, <c>false</c>.
        /// </value>
        public bool PublishDealsToFb{ get; set; }
        /// <summary>
        /// Gets or sets the Facebook account Id.
        /// </summary>
        /// <value>
        /// The Facebook account identifier.
        /// </value>
        public string FbAccount { get; set; }
        /// <summary>
        /// Gets or sets the Facebook page.
        /// </summary>
        /// <value>
        /// The Facebook page.
        /// </value>
        public string FbPage { get; set; }
        /// <summary>
        /// Gets or sets the Facebook page access token.
        /// </summary>
        /// <value>
        /// The Facebook page access token.
        /// </value>
        public string FbPageAccessToken { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [has store registered for rewards].
        /// </summary>
        /// <value>
        /// <c>true</c> if [has store registered for rewards]; otherwise, <c>false</c>.
        /// </value>
        public bool HasStoreRegisteredForRewards { get; set; }

        /// <summary>
        /// Gets or sets the custom URL that will be appended to site address.
        /// </summary>
        /// <value>
        /// The custom URL.
        /// </value>
        public string CustomUrl { get; set; }
        /// <summary>
        /// Gets or sets the primary color used by the store.
        /// </summary>
        /// <value>
        /// The primary color.
        /// </value>
        /// <remarks>Hex value</remarks>
        public string PrimaryColor { get; set; }        
        /// <summary>
        /// Gets or sets the secondary color used by the store.
        /// </summary>
        /// <value>
        /// The secondary color.
        /// </value>
        /// <remarks>Hex value</remarks>
        public string SecondaryColor { get; set; }
        /// <summary>
        /// Gets or sets the terms and conditions.
        /// </summary>
        /// <value>
        /// The terms and conditions.
        /// </value>
        public string TermsAndConditions { get; set; }

        /// <summary>
        /// Gets or sets the deals enabled.
        /// </summary>
        /// <value>
        /// The deals enabled.
        /// </value>
        /// <remarks>Flag determines whether user/owner will have UI interface for Deals</remarks>
        public bool? DealsEnabled { get; set; }

        /// <summary>
        /// Gets or sets the owner ids.
        /// </summary>
        /// <value>
        /// The owner ids.
        /// </value>
        /// <remarks>
        /// Tie between user/owner(s) and store(s).
        /// </remarks>
        public List<string> OwnerIds { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [wizard step1 complete].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [wizard step1 complete]; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>Business setup wizard.</remarks>
        public bool WizardStep1Complete { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [wizard step2 complete].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [wizard step2 complete]; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>Rewards (Checkins) setup wizard.</remarks>
        public bool WizardStep2Complete { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [wizard step3 complete].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [wizard step3 complete]; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>Deals wizard (store needs at least 1 to be visible).</remarks>
        public bool WizardStep3Complete { get; set; }

        /// <summary>
        /// Gets or sets the user rating.
        /// </summary>
        /// <value>
        /// The user rating.
        /// </value>
        public int UserRating { get; set; }

        /// <summary>
        /// Gets or sets the more than rewards user identifier.
        /// </summary>
        /// <value>
        /// The more than rewards user identifier.
        /// </value>
        public string MoreThanRewardsUserId { get; set; }

        /// <summary>
        /// Gets or sets the distance.
        /// </summary>
        /// <value>
        /// The distance.
        /// </value>
        public double Distance { get; set; }

        /// <summary>
        /// Gets or sets the followers.
        /// </summary>
        /// <value>
        /// The followers.
        /// </value>
        public int Followers { get; set; }

        /// <summary>
        /// Gets or sets the phone string.
        /// </summary>
        /// <value>
        /// The phone string.
        /// </value>
        public string PhoneString { get; set; }

        /// <summary>
        /// Gets or sets the hours of operation.
        /// </summary>
        /// <value>
        /// The hours of operation.
        /// </value>
        public IDictionary<string, string> HoursOfOperation { get; set; }

    }
}
