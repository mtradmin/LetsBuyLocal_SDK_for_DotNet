namespace LetsBuyLocal.SDK.Tests.Shared
{

    /// <summary>
    /// Provides hex values for colors.
    /// </summary>
    /// <remarks>Uses named web colors</remarks>
    public static class Colors
    {
        public static string Blue { get; private set; }
        public static string Brown { get; private set; }
        public static string BurlyWood { get; private set; }
        public static string CornflowerBlue { get; private set; }
        public static string DarkOrange { get; private set; }
        public static string Green { get; private set; }
        public static string DarkMagenta { get; private set; }
        public static string DarkRed { get; private set; }
        public static string Gray { get; private set; }

        static Colors()
        {
            Blue = "#0000FF";
            Brown = "#A52A2A";
            BurlyWood = "#DEB887";
            CornflowerBlue = "#6495ED";
            DarkOrange = "#FF8C00";
            Green = "#008000";
            DarkMagenta = "#8B008B";
            DarkRed = "#8B0000";
            Gray = "#808080";


        }
    }
}