namespace LetsBuyLocal.SDK.Models
{
    /// <summary>
    /// Represents a set of Facebook settings.
    /// </summary>
    public class FBSettings
    {
        /// <summary>
        /// Gets or sets Facebook (account) Id.
        /// </summary>
        /// <value>
        /// The account (might be a 9-digit string).
        /// </value>
        public string Account { get; set; }
        /// <summary>
        /// Gets or sets the Facebook page.
        /// </summary>
        /// <value>
        /// The page.
        /// </value>
        public string Page { get; set; }
        /// <summary>
        /// Gets or sets the page access token.
        /// </summary>
        /// <value>
        /// The page access token.
        /// </value>
        /// <remarks>Might be alphanumeric with length = 195</remarks>
        public string PageAccessToken { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [publish alerts].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [publish alerts]; otherwise, <c>false</c>.
        /// </value>
        public bool PublishAlerts { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [publish deals].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [publish deals]; otherwise, <c>false</c>.
        /// </value>
        public bool PublishDeals { get; set; }
    }
}
