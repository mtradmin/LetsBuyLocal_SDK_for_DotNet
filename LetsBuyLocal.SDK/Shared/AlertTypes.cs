namespace LetsBuyLocal.SDK.Shared
{
    /// <summary>
    /// Represents the set of valid types of alerts.
    /// </summary>
    public static class AlertTypes
    {
        /// <summary>
        /// Gets the store alert.
        /// </summary>
        /// <value>
        /// The store alert.
        /// </value>
        public static string StoreAlert
        {
            get { return "STORE"; }
        }

        /// <summary>
        /// Gets the deal alert.
        /// </summary>
        /// <value>
        /// The deal alert.
        /// </value>
        public static string DealAlert
        {
            get { return "DEAL"; }
        }

        /// <summary>
        /// Gets the coupon alert.
        /// </summary>
        /// <value>
        /// The coupon alert.
        /// </value>
        public static string CouponAlert
        {
            get { return "COUPON"; }
        }
    }
}
