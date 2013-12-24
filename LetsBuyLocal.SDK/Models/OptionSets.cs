using System.Collections.Generic;

namespace LetsBuyLocal.SDK.Models
{
    /// <summary>
    /// Represents the different sets of configuration options.
    /// </summary>
    public class OptionSets : BaseEntity
    {
        /// <summary>
        /// Gets or sets the store categories.
        /// </summary>
        /// <value>
        /// The store categories.
        /// </value>
        public IList<string> StoreCategories { get; set; }

        /// <summary>
        /// Gets or sets the states.
        /// </summary>
        /// <value>
        /// The states.
        /// </value>
        public IList<string> States { get; set; }

        /// <summary>
        /// Gets or sets the countries.
        /// </summary>
        /// <value>
        /// The countries.
        /// </value>
        public IList<string> Countries { get; set; }

        /// <summary>
        /// Gets or sets the time zones.
        /// </summary>
        /// <value>
        /// The time zones.
        /// </value>
        public IList<string> TimeZones { get; set; }
    }
}
