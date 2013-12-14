using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using LetsBuyLocal.SDK.Models;
using LetsBuyLocal.SDK.Services;

namespace LetsBuyLocal.SDK.Tests.Shared
{
    /// <summary>
    /// Provides values and methods commonly used for testing
    /// </summary>
    public static class TestingHelper
    {
        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="svc">The UserService</param>
        /// <returns>A new User object from the service's response</returns>
        public static User NewUser(UserService svc)
        {
            var user = CreateNewTestUserInMemory();
            var testUser = svc.CreateUser(user).Object;
            return testUser;
        }

        /// <summary>
        /// Creates the test store.
        /// </summary>
        /// <param name="category">The store category.</param>
        /// <param name="primaryColor">Primary color.</param>
        /// <param name="secondaryColor">Secondary color.</param>
        /// <returns>A  Store.</returns>
        public static Store NewStore(string category, string primaryColor, string secondaryColor)
        {
            var svc = new StoreService();

            var store = new Store
            {
                Website = "http://www." + GetRandomString(10) + ".com",       //Required
                Name = GetRandomString(30),                                                 //Required
                Phone = GetRandomPhoneNumber(10),                                               //Required, length = 10
                Description = GetRandomString(50),
                Category = category,                                                         //See: Configuration
                AddressLine1 = GetRandomString(30),                                         //Required
                AddressLine2 = GetRandomString(5),
                City = GetRandomString(15),                                                 //Required
                State = "WI",                                                               //Required, See: Configuration
                Zip = GetRandomNumeric(5),                                                  //Required
                Country = "USA",                                                            //See: Configuration
                TimeZone = TimeZoneInfo.Local.ToString(),                                         //Required, See: Configuration

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
                //public string RewardProgramType { get; set; } //null (no Rewards Program), ELECTRONIC, PHYSICAL
                //public bool Published { get; set; } //Soft delete flag
                //public bool Offline { get; set; } //Visibility flag
                //public DateTime? LastDealExpirationDate { get; set; }
                //public bool PublishAlertsToFb { get; set; }
                //public bool PublishDealsToFb{ get; set; }
                //public string FbAccount { get; set; }
                //public string FbPage { get; set; }
                //public string FbPageAccessToken { get; set; }
                //public bool HasStoreRegisteredForRewards { get; set; }
                //public string CustomUrl { get; set; }
                PrimaryColor = primaryColor,
                SecondaryColor = secondaryColor
                //public string TermsAndConditions { get; set; }
                //public bool? DealsEnabled =
                //public bool? CheckInsEnabled =

                //public List<string> OwnerIds =  //List of ids for users that have admin rights to the store

                //public bool WizardStep1Complete =
                //public bool WizardStep2Complete =
                //public bool WizardStep3Complete =

                //public int UserRating =

                //public string MoreThanRewardsUserId { get; set; }

                //public double Distance { get; set; }

                //public int Followers { get; set; }

                //public string PhoneString { get; set; }

                //public IDictionary<string, string> HoursOfOperation { get; set; }
            };


            var resp = svc.CreateStore(store);
            return resp.Object;
        }

        /// <summary>
        /// Creates a new alert.
        /// </summary>
        /// <param name="svc">The AlertService.</param>
        /// <param name="type">The alert type.</param>
        /// <param name="storeId">The store identifier.</param>
        /// <returns>
        /// A new Alert object from the service's response
        /// </returns>
        public static Alert NewAlert(AlertService svc, string type, string storeId)
        {
            var alert = CreateNewTestAlertInMemory(type, storeId);
            var createResp = svc.CreateAlert(alert);
            var newAlert = createResp.Object;
            return newAlert;
        }

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
            user.MobilePhoneNumber = GetRandomPhoneNumber(10);        //Required
            user.HomePhoneNumber = String.Empty;
            user.AddressLine1 = GetRandomNumeric(3) + GetRandomString(25);
            user.AddressLine2 = String.Empty;
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
            user.MobilePhoneNumber = GetRandomPhoneNumber(10);        //Required
            user.HomePhoneNumber = String.Empty;
            user.AddressLine1 = GetRandomNumeric(3) + GetRandomString(25);
            user.AddressLine2 = String.Empty;
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
        /// Creates a test deal in memory.
        /// </summary>
        /// <returns>A Deal object.</returns>
        public static Deal CreateTestDealInMemory()
        {
            //Create a store that will run this deal.
            string category = GetRandomStoreCategory();
            var store = NewStore(category, "green", "gold");

            var deal = new Deal
            {
                StoreId = store.Id,                                                     //Required
                Title = "This deal is " + GetRandomString(25),            //Required
                Description = GetRandomString(50),
                TotalAvailable = Convert.ToInt32(GetRandomNumeric(2)),    //Required
                //Hint = "Hint hint: " + TestingHelper.GetRandomString(10),
                //public int ExtensionDays { get; set; }
                //OnCompleteAction = "RunAgain",                              //(RunAgain/SaveForLater/Delete)
                //ExpirationDate = DateTime.Now.AddMonths(1),                 //Nullable
                //StartDate = DateTime.Now,                                   //Nullable
                Published = false
                //NormalPrice = 5.39m,                                             //Nullable
                //PercentOff = 5,
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
        /// Creates the device in memory.
        /// </summary>
        /// <returns>A new Device object.</returns>
        public static Device CreateDeviceInMemory()
        {
            var device = new Device
            {
                Id = Guid.NewGuid().ToString(),
                Platform = GetPlatform()
            };
            device.DeviceToken = GetDeviceToken(device.Platform);
            return device;
        }

        /// <summary>
        /// Creates the test alert object.
        /// </summary>
        /// <returns></returns>
        public static Alert CreateNewTestAlertInMemory(string type, string storeId)
        {
            var alert = new Alert
            {
                StoreId = storeId,
                Description = GetRandomString(30), 
                Type = type
            };

            return alert;
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
            user.MobilePhoneNumber = GetRandomPhoneNumber(10);        //Required
            user.HomePhoneNumber = GetRandomPhoneNumber(10);
            user.AddressLine1 = GetRandomNumeric(3) + GetRandomString(25);
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
        /// Updates the store.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <returns>A store object.</returns>
        public static Store UpdateStore(Store store)
        {
            store.Website = "http://www." + GetRandomString(10) + ".com";       //Required
            //store.Name = GetRandomString(30);                                                //Required
            store.Phone = GetRandomPhoneNumber(10);                                               //Required, length = 10
            store.Description = GetRandomString(50);
            //store.Category = "Retailer - Boutique/Clothing/Accessories";                      //See: Configuration
            store.AddressLine1 = GetRandomString(30);                                         //Required
            store.AddressLine2 = GetRandomString(5);
            store.City = GetRandomString(15);                                                 //Required
            //store.State = "WI";                                                              //Required, See: Configuration
            store.Zip = GetRandomNumeric(5);                                                  //Required
            //store.Country = "USA";                                                            //See: Configuration
            //store.TimeZone = "Central Standard Time";                                         //Required, See: Configuration

            store.SundayOpenTime = null;
            store.SundayCloseTime = null;
            store.MondayOpenTime = "9";
            store.MondayCloseTime = "5";
            store.TuesdayOpenTime = "9";
            store.TuesdayCloseTime = "5";
            store.WednesdayOpenTime = "9";
            store.WednesdayCloseTime = "5";
            store.ThursdayOpenTime = "9";
            store.ThursdayCloseTime = "5";
            store.FridayOpenTime = "9";
            store.FridayCloseTime = "5";
            store.SaturdayOpenTime = "9";
            store.SaturdayCloseTime = "5";

            store.PayPalEmail = null;
            //store.Latitude = null;
            //store.Longitude = null;
            store.ReceiptId = null;
            store.RewardProgramType = null;            //null (no Rewards Program), ELECTRONIC, PHYSICAL
            store.Published = true;                      //Soft delete flag
            store.Offline = false;                        //Visibility flag
            store.LastDealExpirationDate = null;
            store.PublishAlertsToFb = false;
            store.PublishDealsToFb = false;
            store.FbAccount = null;
            store.FbPage = null;
            store.FbPageAccessToken = null;
            store.HasStoreRegisteredForRewards = false;
            store.CustomUrl = null;
            store.PrimaryColor = "Blue";
            store.SecondaryColor = "Gold";
            store.TermsAndConditions = GetRandomString(100);
            store.DealsEnabled = true;
            store.CheckInsEnabled = true;

            //public List<string> OwnerIds =  //List of ids for users that have admin rights to the store

            //public bool WizardStep1Complete =
            //public bool WizardStep2Complete =
            //public bool WizardStep3Complete =

            //public int UserRating =

            store.MoreThanRewardsUserId = null;

            //public double Distance =

            //public int Followers =

            //store.PhoneString =

            //public IDictionary<string, string> HoursOfOperation =

            return store;
        }

        /// <summary>
        /// Updates the deal.
        /// </summary>
        /// <param name="deal">The deal.</param>
        /// <returns>The updated deal object.</returns>
        public static Deal UpdateDeal(Deal deal)
        {
            //******************************************************************************************************************
            //Regarding datetime values:
            // "ExceptionMessage": 
            //"The conversion could not be completed because the supplied DateTime did not have the Kind property set correctly. 
            //For example, when the Kind property is DateTimeKind.Local, 
            //the source time zone must be TimeZoneInfo.Local.\r\nParameter name: sourceTimeZone",
            //******************************************************************************************************************

            deal.TotalAvailable = Convert.ToInt32(GetRandomNumeric(2));        //Required
            deal.Hint = deal.Hint + " updated";
                //public int ExtensionDays { get; set; }
            deal.OnCompleteAction = "RunAgain";                              //(RunAgain/SaveForLater/Delete)
            deal.ExpirationDate = DateTime.Now.AddMonths(1).ToLocalTime();                 //Nullable
            deal.StartDate = DateTime.Now.ToLocalTime();                                   //Nullable
                //Published = false
            deal.NormalPrice = 7.39m;                                             //Nullable
            deal.PercentOff = 3;
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

            return deal;
        }

        /// <summary>
        /// Gets the random store category.
        /// </summary>
        /// <returns>A category string.</returns>
        public static string GetRandomStoreCategory()
        {
            var random = new Random();

            var categories = GetStoreCategories();
            int r = random.Next(0, categories.Count - 1);
            var category = categories[r];

            return category;
        }

        /// <summary>
        /// Gets the store categories.
        /// </summary>
        /// <returns>A List of StoreCategories strings.</returns>
        public static IList<string> GetStoreCategories()
        {
            var svc = new ConfigurationService();
            var resp = svc.GetListOfStandardOptions();
            var categories = resp.Object.StoreCategories;
            return categories;
        }

        /// <summary>
        /// Gets the randomly generated geo point.
        /// </summary>
        /// <returns>A GeoPoint object.</returns>
        public static GeoPoint GetGeoPoint()
        {
            decimal latitude = GetRandomLatitudeApproxWi();
            decimal longitude = GetRandomLongitudeApproxWi();

            var geoPoint = GetNewGeoPoint(latitude, longitude);
            return geoPoint;
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
        /// Gets a random device token for the specified type of device
        /// </summary>
        /// <param name="platform">A string specifying the type of device (ios or android)</param>
        /// <returns>A device token string for the specified platform</returns>
        public static string GetDeviceToken(string platform)
        {
            if (platform.ToLower() == "ios")
                return GetRandomString(32);
            if (platform.ToLower() == "android")
                return GetRandomString(16);
            return String.Empty;
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
            return "android";
        }


        #region Helper Methods

        /// <summary>
        /// Gets a random phone number with the specified number of digits
        /// </summary>
        /// <param name="len">Number of digits desired in number as an integer</param>
        /// <returns>A number of the specified length as a string</returns>
        private static string GetRandomNumeric(int len)
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
        /// Gets a random phone number string that does not use the digits 0 or 1.
        /// </summary>
        /// <param name="len">The length.</param>
        /// <returns>A phone number string</returns>
        private static string GetRandomPhoneNumber(int len)
        {
            const string chars = "23456789";
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
        private static int GetRandomInteger(int min, int max)
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
        private static string GetEmailAlias(string baseEmailName, string atEmail)
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
        /// Gets a randomly generated sex (Female/Male).
        /// </summary>
        /// <returns>Either F or M as a string</returns>
        private static string GetSex()
        {
            var rand = new Random();
            var value = rand.NextDouble();
            if (value > 0.5)
                return "Female";
            return "Male";
        }

        /// <summary>
        /// Gets the geo point.
        /// </summary>
        /// <param name="lat">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <returns>A geopoint object</returns>
        private static GeoPoint GetNewGeoPoint(decimal lat, decimal longitude)
        {
            var geoPoint = new GeoPoint {Latitude = lat, Longitude = longitude};
            return geoPoint;
        }

        /// <summary>
        /// Gets the random latitude for a location roughly somewhere in WI.
        /// </summary>
        /// <returns>A decimal representing latitude</returns>
        private static decimal GetRandomLatitudeApproxWi()
        {
            var dbl = new Random();
            const double min = 42.5;
            const double max = 47.05;

            //Get a random decimal between 42° 30'N to 47° 3'N
            var raw = dbl.NextDouble() * (max - min) + min;
            decimal latitude = Convert.ToDecimal(raw);

            return latitude;
        }

        /// <summary>
        /// Gets the random longitude for a location roughly somewhere in WI.
        /// </summary>
        /// <returns>A decimal representing longitude</returns>
        private static decimal GetRandomLongitudeApproxWi()
        {
            var dbl = new Random();
            const double min = 86.81666667;
            const double max = 92.9;

            //Get a random decimal between 86° 49'W to 92° 54'W
            var raw = dbl.NextDouble()*(max - min) + min;
            decimal longitude = Convert.ToDecimal(raw);

            return longitude;
        }

        #endregion
    }
}
