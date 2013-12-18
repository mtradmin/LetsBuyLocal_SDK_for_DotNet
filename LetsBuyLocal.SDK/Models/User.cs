
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LetsBuyLocal.SDK.Models
{

    /// <summary>
    /// Represents a user entity.  
    /// A user who is an owner of a Store is identified based on the user that creates the store.
    /// </summary>
    public class User : BaseEntity
    {
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is a required field.")]
        [EmailAddress(ErrorMessage = "Email address is not valid.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "First Name is a required field.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is a required field.")]
        public string LastName { get; set; }
        public string Image { get; set; }
        public string Sex { get; set; }
        [Required(ErrorMessage = "Mobile Phone is a required field.")]
        public string MobilePhoneNumber { get; set; }
        public string HomePhoneNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public DateTime? BirthDate { get; set; }
        public string TimeZone { get; set; }
        public bool IsStoreOwner { get; set; }
        public bool ShowStoreAlerts { get; set; }
        public bool ShowDealAlerts { get; set; }
        public bool ShowCouponAlerts { get; set; }
        public string FacebookUserId { get; set; }
        public int ReservedDeals { get; set; }
        public int RedeemedDeals { get; set; }
        public int CurrentLevel { get; set; }
        //Is set internally
        public bool HasFollowedStore { get; set; }

        public DateTime? AgreedToTerms { get; set; }

        #region Size Information
        public string ShoeSize { get; set; }
        public string GloveSize { get; set; }
        public string FavoriteBrand { get; set; }
        public string TshirtSize { get; set; }
        public string PantsWaist { get; set; }
        public string FavoriteColor { get; set; }
        public string Dress { get; set; }
        public string PantsInseam { get; set; }
        public bool? ShareSizeInfo { get; set; }
        #endregion

        #region Marketing Information
        public bool? SendOffersByEmail { get; set; }
        public bool? SendOffersByText { get; set; }
        public bool? SendOffersByFacebook { get; set; }
        public bool? SendOffersByUsMail { get; set; }
        #endregion

        public List<string> StoreIds { get; set; } //List of Ids for stores that the user wants to track

        public List<string> StoreRatings { get; set; } //List of concatenated StoreIds and their rating [ StoreId|Rating ]

        public List<string> DeviceIds { get; set; } //List of Ids for devices that the user uses

        public List<string> KeysToTheCity { get; set; } //List of Key To The City that the user uses

        public List<string> Reservations { get; set; } //List of reservation that the user has

        public List<string> StoreRewardIndex { get; set; } //List of StoreIds-rewardIndex

        public List<string> LastViewedStoreDealsList { get; set; } //Date of last viewed deal by Store [StoreId|DateTime]

        public List<string> LastReadStoreAlertsList { get; set; } //Date of last read alert by Store [StoreId|DateTime]

        public List<string> DeletedAlertIds { get; set; } //List of Alert Ids that have been deleted

        public List<string> LastStoreRewardIdList { get; set; } // List of reward ids by Store [StoreId|RewardId]
        public List<string> LastStoreRewardExpirationDateList { get; set; } // List of reward expiration dates by Store [StoreId|ExpirationDate]

        public List<object> LastViewedStoreDeals { get; set; }

        public List<object> LastReadStoreAlerts { get; set; } // List of storeId|datetime for when a message was read

        public List<object> LastStoreRewardIds { get; set; }

        public List<object> LastStoreRewardExpirationDates { get; set; }

        public bool IsFacebookUser { get; set; }

        public IList<Store> Stores { get; set; }

        public string MobilePhoneNumberString { get; set; }


        public string HomePhoneNumberString { get; set; }
    }
}
