using System;

namespace LetsBuyLocal.SDK.Tests
{
    /// <summary>
    /// Provides values and methods commonly used for testing
    /// </summary>
    public static class TestingHelper
    {
        public const string TestUserId = "caa2298a-e8d5-4d76-bce8-c98ffb102b23";
        public const string TestEmail = "margakkrumins@gmail.com";
        public const string TestPassword = "gibber1234";

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
        /// <returns>A phone number of the specified length as a string</returns>
        public static string GetRandomPhoneNo(int len)
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


    }
}
