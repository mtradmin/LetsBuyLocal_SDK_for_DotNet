namespace LetsBuyLocal.SDK.Models
{
    /// <summary>
    /// Represents a configuration option.
    /// </summary>
    public class Option : BaseEntity
    {
        /// <summary>
        /// Gets or sets the sort order of this option.
        /// </summary>
        /// <value>
        /// The sort order.
        /// </value>
        public int Sort { get; set; }
    }
}
