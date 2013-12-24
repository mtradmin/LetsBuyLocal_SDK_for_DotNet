
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LetsBuyLocal.SDK.Models
{

    /// <summary>
    /// Represents a user.
    /// A user who is an owner of a Store is identified based on the user that creates the store.
    /// </summary>
    public class User : BaseEntity
    {
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }

        //1st screen
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [Required(ErrorMessage = "Email is a required field.")]
        [EmailAddress(ErrorMessage = "Email address is not valid.")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        [Required(ErrorMessage = "First Name is a required field.")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        [Required(ErrorMessage = "Last Name is a required field.")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the mobile phone number.
        /// </summary>
        /// <value>
        /// The mobile phone number.
        /// </value>
        [Required(ErrorMessage = "Mobile Phone is a required field.")]
        public string MobilePhoneNumber { get; set; }


        /// <summary>
        /// Gets or sets the image on 2nd screen.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        public string Image { get; set; }

        /// <summary>
        /// Denotes whether or not user is also a business Owner.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is store owner]; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// Is automatically set [True] when user creates first Store they own.
        /// </remarks>
        public bool IsStoreOwner { get; set; }

        /// <summary>
        /// Gets or sets the sex.
        /// </summary>
        /// <value>
        /// The sex.
        /// </value>
        public string Sex { get; set; }
        /// <summary>
        /// Gets or sets the home phone number.
        /// </summary>
        /// <value>
        /// The home phone number.
        /// </value>
        public string HomePhoneNumber { get; set; }
        /// <summary>
        /// Gets or sets the address line1.
        /// </summary>
        /// <value>
        /// The address line1.
        /// </value>
        public string AddressLine1 { get; set; }
        /// <summary>
        /// Gets or sets the address line2.
        /// </summary>
        /// <value>
        /// The address line2.
        /// </value>
        public string AddressLine2 { get; set; }
        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        public string City { get; set; }
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        /// <remarks>Must be in ConfigurationService.GetListOfStandardOptions State.</remarks>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the zip.
        /// </summary>
        /// <value>
        /// The zip.
        /// </value>
        public string Zip { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        /// <remarks>Must be in ConfigurationService.GetListOfStandardOptions Country</remarks>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        /// <value>
        /// The birth date.
        /// </value>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the time zone.
        /// </summary>
        /// <value>
        /// The time zone.
        /// </value>
        /// <remarks>Must be in ConfigurationService.GetListOfStandardOptions TimeZone</remarks>
        public string TimeZone { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [show store alerts].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show store alerts]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowStoreAlerts { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [show deal alerts].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show deal alerts]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowDealAlerts { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [show coupon alerts].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show coupon alerts]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowCouponAlerts { get; set; }
        /// <summary>
        /// Gets or sets the facebook user identifier.
        /// </summary>
        /// <value>
        /// The facebook user identifier.
        /// </value>
        public string FacebookUserId { get; set; }
        /// <summary>
        /// Gets or sets the reserved deals.
        /// </summary>
        /// <value>
        /// The reserved deals.
        /// </value>
        public int ReservedDeals { get; set; }
        /// <summary>
        /// Gets or sets the redeemed deals.
        /// </summary>
        /// <value>
        /// The redeemed deals.
        /// </value>
        public int RedeemedDeals { get; set; }
        /// <summary>
        /// Gets or sets the current level (points).
        /// </summary>
        /// <value>
        /// The current level.
        /// </value>
        public int CurrentLevel { get; set; }

        //Is set internally
        /// <summary>
        /// Gets or sets a value indicating whether [has followed store].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [has followed store]; otherwise, <c>false</c>.
        /// </value>
        public bool HasFollowedStore { get; set; }

        /// <summary>
        /// Gets or sets the agreed to terms.
        /// </summary>
        /// <value>
        /// The agreed to terms.
        /// </value>
        public DateTime? AgreedToTerms { get; set; }

        #region Size Information
        /// <summary>
        /// Gets or sets the size of the shoe.
        /// </summary>
        /// <value>
        /// The size of the shoe.
        /// </value>
        public string ShoeSize { get; set; }
        /// <summary>
        /// Gets or sets the size of the glove.
        /// </summary>
        /// <value>
        /// The size of the glove.
        /// </value>
        public string GloveSize { get; set; }
        /// <summary>
        /// Gets or sets the favorite brand.
        /// </summary>
        /// <value>
        /// The favorite brand.
        /// </value>
        public string FavoriteBrand { get; set; }
        /// <summary>
        /// Gets or sets the size of the tshirt.
        /// </summary>
        /// <value>
        /// The size of the tshirt.
        /// </value>
        public string TshirtSize { get; set; }
        /// <summary>
        /// Gets or sets the pants waist.
        /// </summary>
        /// <value>
        /// The pants waist.
        /// </value>
        public string PantsWaist { get; set; }
        /// <summary>
        /// Gets or sets the color of the favorite.
        /// </summary>
        /// <value>
        /// The color of the favorite.
        /// </value>
        public string FavoriteColor { get; set; }
        /// <summary>
        /// Gets or sets the dress.
        /// </summary>
        /// <value>
        /// The dress.
        /// </value>
        public string Dress { get; set; }
        /// <summary>
        /// Gets or sets the pants inseam.
        /// </summary>
        /// <value>
        /// The pants inseam.
        /// </value>
        public string PantsInseam { get; set; }
        /// <summary>
        /// Gets or sets the share size information.
        /// </summary>
        /// <value>
        /// The share size information.
        /// </value>
        public bool? ShareSizeInfo { get; set; }
        #endregion

        #region Marketing Information
        /// <summary>
        /// Gets or sets whether send offers by email.
        /// </summary>
        /// <value>
        /// The send offers by email.
        /// </value>
        public bool? SendOffersByEmail { get; set; }
        /// <summary>
        /// Gets or sets whether send offers by text.
        /// </summary>
        /// <value>
        /// The send offers by text.
        /// </value>
        public bool? SendOffersByText { get; set; }
        /// <summary>
        /// Gets or sets whether send offers by Facebook.
        /// </summary>
        /// <value>
        /// The send offers by Facebook.
        /// </value>
        public bool? SendOffersByFacebook { get; set; }
        /// <summary>
        /// Gets or sets the send offers by us mail.
        /// </summary>
        /// <value>
        /// The send offers by us mail.
        /// </value>
        public bool? SendOffersByUsMail { get; set; }
        #endregion


        /// <summary>
        /// List of stores that user owns.
        /// </summary>
        /// <value>
        /// The store ids.
        /// </value>
        /// <remarks>
        /// If list not empty, IsStoreOwner is automatically set to [True].
        /// </remarks>
        public List<string> StoreIds { get; set; }

        /// <summary>
        /// Gets or sets the store ratings.
        /// </summary>
        /// <value>
        /// The store ratings.
        /// </value>
        public List<string> StoreRatings { get; set; } //List of concatenated StoreIds and their rating [ StoreId|Rating ]

        /// <summary>
        /// Gets or sets the device ids.
        /// </summary>
        /// <value>
        /// The device ids.
        /// </value>
        public List<string> DeviceIds { get; set; } //List of Ids for devices that the user uses

        /// <summary>
        /// Gets or sets the keys to the city.
        /// </summary>
        /// <value>
        /// The keys to the city.
        /// </value>
        public List<string> KeysToTheCity { get; set; } //List of Key To The City that the user uses

        /// <summary>
        /// Gets or sets the reservations.
        /// </summary>
        /// <value>
        /// The reservations.
        /// </value>
        public List<string> Reservations { get; set; } //List of reservation that the user has

        /// <summary>
        /// Gets or sets the index of the store reward.
        /// </summary>
        /// <value>
        /// The index of the store reward.
        /// </value>
        public List<string> StoreRewardIndex { get; set; } //List of StoreIds-rewardIndex

        /// <summary>
        /// Gets or sets the last viewed store deals list.
        /// </summary>
        /// <value>
        /// The last viewed store deals list.
        /// </value>
        public List<string> LastViewedStoreDealsList { get; set; } //Date of last viewed deal by Store [StoreId|DateTime]

        /// <summary>
        /// Gets or sets the last read store alerts list.
        /// </summary>
        /// <value>
        /// The last read store alerts list.
        /// </value>
        public List<string> LastReadStoreAlertsList { get; set; } //Date of last read alert by Store [StoreId|DateTime]

        /// <summary>
        /// Gets or sets the deleted alert ids.
        /// </summary>
        /// <value>
        /// The deleted alert ids.
        /// </value>
        public List<string> DeletedAlertIds { get; set; } //List of Alert Ids that have been deleted

        /// <summary>
        /// Gets or sets the last store reward identifier list.
        /// </summary>
        /// <value>
        /// The last store reward identifier list.
        /// </value>
        public List<string> LastStoreRewardIdList { get; set; } // List of reward ids by Store [StoreId|RewardId]
        /// <summary>
        /// Gets or sets the last store reward expiration date list.
        /// </summary>
        /// <value>
        /// The last store reward expiration date list.
        /// </value>
        public List<string> LastStoreRewardExpirationDateList { get; set; } // List of reward expiration dates by Store [StoreId|ExpirationDate]

        /// <summary>
        /// Gets or sets the last viewed store deals.
        /// </summary>
        /// <value>
        /// The last viewed store deals.
        /// </value>
        public List<object> LastViewedStoreDeals { get; set; }

        /// <summary>
        /// Gets or sets the last read store alerts.
        /// </summary>
        /// <value>
        /// The last read store alerts.
        /// </value>
        /// <remarks>List of storeId|datetime for when a message was read.</remarks>
        public List<object> LastReadStoreAlerts { get; set; }

        /// <summary>
        /// Gets or sets the last store reward ids.
        /// </summary>
        /// <value>
        /// The last store reward ids.
        /// </value>
        public List<object> LastStoreRewardIds { get; set; }

        /// <summary>
        /// Gets or sets the last store reward expiration dates.
        /// </summary>
        /// <value>
        /// The last store reward expiration dates.
        /// </value>
        public List<object> LastStoreRewardExpirationDates { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is Facebook user].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is Facebook user]; otherwise, <c>false</c>.
        /// </value>
        public bool IsFacebookUser { get; set; }

        /// <summary>
        /// Gets or sets the stores.
        /// </summary>
        /// <value>
        /// The stores.
        /// </value>
        public IList<Store> Stores { get; set; }

        /// <summary>
        /// Gets or sets the mobile phone number string.
        /// </summary>
        /// <value>
        /// The mobile phone number string.
        /// </value>
        public string MobilePhoneNumberString { get; set; }


        /// <summary>
        /// Gets or sets the home phone number string.
        /// </summary>
        /// <value>
        /// The home phone number string.
        /// </value>
        public string HomePhoneNumberString { get; set; }
    }
}
