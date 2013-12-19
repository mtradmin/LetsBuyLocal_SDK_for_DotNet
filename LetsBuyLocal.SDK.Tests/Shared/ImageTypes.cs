namespace LetsBuyLocal.SDK.Tests.Shared
{
    /// <summary>
    /// Provides expected string values for image types
    /// </summary>
    public static class ImageTypes
    {
        public static string Deals { get; private set; }
        public static string Users { get; private set; }
        public static string Stores { get; private set; }

        static ImageTypes()
        {
            Deals = "Deals";
            Users = "Users";
            Stores = "Stores";
        }
    }

    
    
}
