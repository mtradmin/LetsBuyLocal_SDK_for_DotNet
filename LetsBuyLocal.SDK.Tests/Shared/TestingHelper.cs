using System;
using System.Text;
using System.Configuration;
using LetsBuyLocal.SDK.Models;
using LetsBuyLocal.SDK.Services;
using LetsBuyLocal.SDK.Shared;

namespace LetsBuyLocal.SDK.Tests.Shared
{
    /// <summary>
    /// Provides values and methods commonly used for testing
    /// </summary>
    public static class TestingHelper
    {
        /// <summary>
        /// Creates a test user object.
        /// </summary>
        /// <returns>
        /// a User object.
        /// </returns>
        public static User CreateNewTestUserInMemory()
        {
            var user = new User();
            string baseEmailName = ConfigurationManager.AppSettings["BaseEmailName"];
            string atEmail = ConfigurationManager.AppSettings["AtEmail"];

            user.Password = GetRandomString(8);
            user.Email = GetEmailAlias(baseEmailName, atEmail);                 //Required & valid
            user.FirstName = GetRandomString(25);                 //Required & valid
            user.LastName = GetRandomString(25);                  //Required & valid
            user.Sex = GetSex();
            user.Image = @"C:\Users\Public\Pictures\Sample Pictures/Koala.jpg";
            user.MobilePhoneNumber = GetRandomNumeric(10);        //Required
            user.HomePhoneNumber = string.Empty;
            user.AddressLine1 = GetRandomNumeric(3) + TestingHelper.GetRandomString(25);
            user.AddressLine2 = string.Empty;
            user.City = GetRandomString(12);
            user.State = "WI";
            user.Zip = GetRandomNumeric(5);
            user.Country = "USA";                                                   //See: GetConfiguration
            user.BirthDate = DateTime.Now.AddYears(-(GetRandomInteger(14, 115)));   //Nullable
            user.TimeZone = "Central Standard Time";                                //See: GetConfiguration
            user.IsStoreOwner = false;
            user.ShowStoreAlerts = true;
            user.ShowDealAlerts = true;
            user.ShowCouponAlerts = true;
            user.FacebookUserId = null;                     //Numeric string: https://developers.facebook.com/docs/graph-api/reference/user/
            user.ReservedDeals = 0;
            user.RedeemedDeals = 0;
            user.CurrentLevel = 0;
            //user.HasFollowedStore = false;                //Is set internally
            user.AgreedToTerms = DateTime.Now;              //Nullable

            //Size Information
            user.ShoeSize = GetRandomNumeric(2);
            user.GloveSize = GetRandomNumeric(1);
            user.FavoriteBrand = GetRandomString(25);
            user.TshirtSize = GetRandomString(2);
            user.PantsWaist = GetRandomNumeric(2);
            user.FavoriteColor = "Green";
            user.Dress = GetRandomString(2);
            user.PantsInseam = GetRandomNumeric(2);
            user.ShareSizeInfo = false;

            //Marketing Information                         //All fields nullable
            user.SendOffersByEmail = null;
            user.SendOffersByText = null;
            user.SendOffersByFacebook = null;
            user.SendOffersByUsMail = null;

            return user;
        }

        /// <summary>
        /// Creates the new test store owner in memory.
        /// </summary>
        /// <returns>A User object for an owner.</returns>
        public static User CreateNewTestStoreOwnerInMemory()
        {
            var user = new User();
            string baseEmailName = ConfigurationManager.AppSettings["BaseEmailName"];
            string atEmail = ConfigurationManager.AppSettings["AtEmail"];

            user.Password = GetRandomString(8);
            user.Email = GetEmailAlias(baseEmailName, atEmail);                 //Required & valid
            user.FirstName = GetRandomString(25);                 //Required & valid
            user.LastName = GetRandomString(25);                  //Required & valid
            user.Sex = GetSex();
            user.Image = @"C:\Users\Public\Pictures\Sample Pictures/Koala.jpg";
            user.MobilePhoneNumber = GetRandomNumeric(10);        //Required
            user.HomePhoneNumber = string.Empty;
            user.AddressLine1 = GetRandomNumeric(3) + TestingHelper.GetRandomString(25);
            user.AddressLine2 = string.Empty;
            user.City = GetRandomString(12);
            user.State = "WI";
            user.Zip = GetRandomNumeric(5);
            user.Country = "USA";                                                   //See: GetConfiguration
            user.BirthDate = DateTime.Now.AddYears(-(GetRandomInteger(14, 115)));   //Nullable
            user.TimeZone = "Central Standard Time";                                //See: GetConfiguration
            user.IsStoreOwner = true;   //This is the field denoting is owner
            user.ShowStoreAlerts = true;
            user.ShowDealAlerts = true;
            user.ShowCouponAlerts = true;
            user.FacebookUserId = null;                     //Numeric string: https://developers.facebook.com/docs/graph-api/reference/user/
            user.ReservedDeals = 0;
            user.RedeemedDeals = 0;
            user.CurrentLevel = 0;
            //user.HasFollowedStore = false;                //Is set internally
            user.AgreedToTerms = DateTime.Now;              //Nullable

            //Size Information
            user.ShoeSize = GetRandomNumeric(2);
            user.GloveSize = GetRandomNumeric(1);
            user.FavoriteBrand = GetRandomString(25);
            user.TshirtSize = GetRandomString(2);
            user.PantsWaist = GetRandomNumeric(2);
            user.FavoriteColor = "Green";
            user.Dress = GetRandomString(2);
            user.PantsInseam = GetRandomNumeric(2);
            user.ShareSizeInfo = false;

            //Marketing Information                         //All fields nullable
            user.SendOffersByEmail = null;
            user.SendOffersByText = null;
            user.SendOffersByFacebook = null;
            user.SendOffersByUsMail = null;

            return user;
        }

        /// <summary>
        /// Updates user.
        /// </summary>
        /// <param name="user">A User object to update</param>
        /// <param name="isOwner">if set to <c>true</c> [is owner].</param>
        /// <returns>
        /// A user object that has been updated
        /// </returns>
        public static User UpdateUser(User user, bool isOwner = false)
        {
            string baseEmailName = ConfigurationManager.AppSettings["BaseEmailName"];
            string atEmail = ConfigurationManager.AppSettings["AtEmail"];

            user.Password = GetRandomString(8);
            user.Email = GetEmailAlias(baseEmailName, atEmail);                 //Required & valid
            user.FirstName = GetRandomString(25);                 //Required & valid
            user.LastName = GetRandomString(25);                  //Required & valid
            //user.Sex = TestingHelper.GetSex();
            user.Image = @"C:\Users\Public\Pictures\Sample Pictures/Penguins.jpg";
            //Phone number & address info can be updated regardless of whether using Facebook account
            user.MobilePhoneNumber = GetRandomNumeric(10);        //Required
            user.HomePhoneNumber = GetRandomNumeric(10);
            user.AddressLine1 = GetRandomNumeric(3) + TestingHelper.GetRandomString(25);
            user.AddressLine2 = GetRandomString(5);
            user.City = GetRandomString(12);
            user.State = "WI";
            user.Zip = GetRandomNumeric(5);
            user.Country = "USA";                                                   //See: GetConfiguration
            user.BirthDate = DateTime.Now.AddYears(-(GetRandomInteger(14, 115)));   //Nullable
            user.TimeZone = "Central Standard Time";                                //See: GetConfiguration
            user.IsStoreOwner = isOwner;
            user.ShowStoreAlerts = true;
            user.ShowDealAlerts = true;
            user.ShowCouponAlerts = true;
            user.FacebookUserId = null;                     //Numeric string: https://developers.facebook.com/docs/graph-api/reference/user/
            user.ReservedDeals = 0;
            user.RedeemedDeals = 0;
            user.CurrentLevel = 0;
            //user.HasFollowedStore = false;                //Is set internally
            user.AgreedToTerms = DateTime.Now;              //Nullable

            //Size Information
            user.ShoeSize = GetRandomNumeric(2);
            user.GloveSize = GetRandomNumeric(1);
            user.FavoriteBrand = GetRandomString(25);
            user.TshirtSize = GetRandomString(2);
            user.PantsWaist = GetRandomNumeric(2);
            user.FavoriteColor = "Green";
            user.Dress = GetRandomString(2);
            user.PantsInseam = GetRandomNumeric(2);
            user.ShareSizeInfo = false;

            //Marketing Information                         //All fields nullable
            user.SendOffersByEmail = null;
            user.SendOffersByText = null;
            user.SendOffersByFacebook = null;
            user.SendOffersByUsMail = null;

            return user;
        }

        /// <summary>
        /// Creates the test alert object.
        /// </summary>
        /// <returns></returns>
        public static Alert CreateNewTestAlertInMemory()
        {
            //Create a test store for this method.
            var store = CreateTestStore().Object;

            var alert = new Alert();
            alert.StoreId = store.Id;
            alert.Description = TestingHelper.GetRandomString(30);
            alert.Type = AlertTypes.StoreAlert;

            return alert;
        }

        /// <summary>
        /// Creates the test store.
        /// </summary>
        /// <returns>A ResponseMessage containing an object of type Store.</returns>
        public static ResponseMessage<Store> CreateTestStore()
        {
            var svc = new StoreService();

            var store = new Store
            {
                Website = "http://www." + TestingHelper.GetRandomString(10) + ".com",       //Required
                Name = GetRandomString(30),                                                 //Required
                Phone = GetRandomNumeric(10),                                               //Required, length = 10
                Description = GetRandomString(50),
                Category = "Retailer - Boutique/Clothing/Accessories",                      //See: Configuration
                AddressLine1 = GetRandomString(30),                                         //Required
                AddressLine2 = GetRandomString(5),
                City = GetRandomString(15),                                                 //Required
                State = "WI",                                                               //Required, See: Configuration
                Zip = GetRandomNumeric(5),                                                  //Required
                Country = "USA",                                                            //See: Configuration
                TimeZone = "Central Standard Time",                                         //Required, See: Configuration

                //public string SundayOpenTime { get; set; }
                //public string SundayCloseTime { get; set; }
                //public string MondayOpenTime { get; set; }
                //public string MondayCloseTime { get; set; }
                //public string TuesdayOpenTime { get; set; }
                //public string TuesdayCloseTime { get; set; }
                //public string WednesdayOpenTime { get; set; }
                //public string WednesdayCloseTime { get; set; }
                //public string ThursdayOpenTime { get; set; }
                //public string ThursdayCloseTime { get; set; }
                //public string FridayOpenTime { get; set; }
                //public string FridayCloseTime { get; set; }
                //public string SaturdayOpenTime { get; set; }
                //public string SaturdayCloseTime { get; set; }

                //public string PayPalEmail { get; set; }
                //public decimal Latitude { get; set; }
                //public decimal Longitude { get; set; }
                //public string ReceiptId { get; set; }
                //public string RewardProgramType { get; set; }             //null (no Rewards Program), ELECTRONIC, PHYSICAL
                //public bool Published { get; set; }                       //Soft delete flag
                //public bool Offline { get; set; }                         //Visibility flag
                //public DateTime? LastDealExpirationDate { get; set; }
                //public bool PublishAlertsToFb { get; set; }
                //public bool PublishDealsToFb{ get; set; }
                //public string FbAccount { get; set; }
                //public string FbPage { get; set; }
                //public string FbPageAccessToken { get; set; }
                //public bool HasStoreRegisteredForRewards { get; set; }
                //public string CustomUrl { get; set; }
                PrimaryColor = "Green",
                SecondaryColor = "Gold"
                //public string TermsAndConditions { get; set; }
                //public bool? DealsEnabled { get; set; }
                //public bool? CheckInsEnabled { get; set; }

                //public List<string> OwnerIds { get; set; }  //List of ids for users that have admin rights to the store

                //public bool WizardStep1Complete { get; set; }
                //public bool WizardStep2Complete { get; set; }
                //public bool WizardStep3Complete { get; set; }

                //public int UserRating { get; set; }

                //public string MoreThanRewardsUserId { get; set; }

                //public double Distance { get; set; }

                //public int Followers { get; set; }

                //public string PhoneString { get; set; }

                //public IDictionary<string, string> HoursOfOperation { get; set; }
            };


            var resp = svc.CreateStore(store);
            return resp;
        }

        /// <summary>
        /// Creates a test deal in memory.
        /// </summary>
        /// <returns>A Deal object</returns>
        public static Deal CreateTestDealInMemory()
        {
            //Create a store that will run this deal.
            var store = TestingHelper.CreateTestStore().Object;

            var deal = new Deal
            {
                Id = Guid.NewGuid().ToString(),
                StoreId = store.Id,
                Title = "This deal is " + TestingHelper.GetRandomString(25),
                TotalAvailable = Convert.ToInt32(TestingHelper.GetRandomNumeric(2)),
                Description = TestingHelper.GetRandomString(50),
                Hint = "Hint hint: " + TestingHelper.GetRandomString(10),

                //public int ExtensionDays { get; set; }
                //public string OnCompleteAction { get; set; }

                //ExpirationDate = DateTime.Now.AddMonths(1),               Causes failure
                StartDate = DateTime.Now,
                //Published = true                                          Causes failure

                //NormalPrice = 1
                //public int? PercentOff { get; set; }
                //public string CopiedFromId { get; set; }
                //public DateTime? PostedToFacebook { get; set; }
                //public string FbPostError { get; set; }
                //public bool PublishCompleteActionDone { get; set; }

                //public bool HasActiveReservations { get; set; }

                //public decimal? Savings { get; set; }

                //public string NormalPriceString { get; set; }

                //public string DealPriceString { get; set; }

                //public string SavingsString { get; set; }

                //public string PercentOffString { get; set; }
            };
            return deal;
        }

        /// <summary>
        /// Gets a random alphanumeric string of the specified length
        /// </summary>
        /// <param name="len">Length of desired string as an integer</param>
        /// <returns>A string of the desired length</returns>
        public static string GetRandomString(int len)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
            var stringChars = new char[len];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new string(stringChars);
            return finalString;
        }

        /// <summary>
        /// Gets a random phone number with the specified number of digits
        /// </summary>
        /// <param name="len">Number of digits desired in number as an integer</param>
        /// <returns>A number of the specified length as a string</returns>
        public static string GetRandomNumeric(int len)
        {
            const string chars = "1234567890";
            var stringChars = new char[len];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new string(stringChars);
            return finalString;
        }

        /// <summary>
        /// Gets the random integer.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns>
        /// A random integer within the specified range.
        /// </returns>
        public static int GetRandomInteger(int min, int max)
        {
            var random = new Random();
            var number = random.Next(min, max);
            return number;
        }

        /// <summary>
        /// Gets an email alias.
        /// </summary>
        /// <param name="baseEmailName">Name of the base email.</param>
        /// <param name="atEmail">At email.</param>
        /// <returns>An email alias string.</returns>
        public static string GetEmailAlias(string baseEmailName, string atEmail)
        {
            var sb = new StringBuilder();
            Guid guid = Guid.NewGuid();

            sb.Append(baseEmailName);
            sb.Append("+");
            sb.Append(guid.ToString());
            sb.Append(atEmail);
            var s = sb.ToString();
            return s;
        }

        /// <summary>
        /// Gets a random device token for the specified type of device
        /// </summary>
        /// <param name="platform">A string specifying the type of device (ios or android)</param>
        /// <returns>A device token string for the specified platform</returns>
        public static string GetDeviceToken(string platform)
        {
            if (platform.ToLower() == "ios")
                return TestingHelper.GetRandomString(32);
            else if (platform.ToLower() == "android")
                return TestingHelper.GetRandomString(16);
            else
                return string.Empty;
        }

        /// <summary>
        /// Gets a randomly generated device type (ios or android platform) 
        /// </summary>
        /// <returns>The platform (device type) string: ios or android</returns>
        public static string GetPlatform()
        {
            var rand = new Random();
            var value = rand.NextDouble();
            if (value > 0.5)
                return "ios";
            else
                return "android";
        }

        /// <summary>
        /// Gets a randomly generated sex (Female/Male).
        /// </summary>
        /// <returns>Either F or M as a string</returns>
        public static string GetSex()
        {
            var rand = new Random();
            var value = rand.NextDouble();
            if (value > 0.5)
                return "Female";
            else
                return "Male";
        }


    }
}
