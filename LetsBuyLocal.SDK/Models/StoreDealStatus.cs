namespace LetsBuyLocal.SDK.Models
{
    /// <summary>
    /// Represents the status of this store's deals.
    /// </summary>
    public class StoreDealStatus
    {
        /// <summary>
        /// Gets or sets a value indicating whether [has deals].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [has deals]; otherwise, <c>false</c>.
        /// </value>
        public bool HasDeals { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [has inactive deals].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [has inactive deals]; otherwise, <c>false</c>.
        /// </value>
        public bool HasInactiveDeals { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [has rewards].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [has rewards]; otherwise, <c>false</c>.
        /// </value>
        public bool HasRewards { get; set; }
    }
}
