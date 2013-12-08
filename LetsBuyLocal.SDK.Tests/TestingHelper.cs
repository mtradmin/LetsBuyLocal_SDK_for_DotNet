using System;

namespace LetsBuyLocal.SDK.Tests
{
    public static class TestingHelper
    {
        public const string TestUserId = "caa2298a-e8d5-4d76-bce8-c98ffb102b23";
        public const string TestEmail = "margakkrumins@gmail.com";
        public const string TestPassword = "gibber1234";

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

    }
}
