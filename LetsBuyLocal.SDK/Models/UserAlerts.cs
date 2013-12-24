using System.Collections.Generic;

namespace LetsBuyLocal.SDK.Models
{
    /// <summary>
    /// Represents alerts sent to user.
    /// </summary>
    public class UserAlerts : BaseEntity
    {
        /// <summary>
        /// Gets or sets the list of alerts that have been deleted.
        /// </summary>
        /// <value>
        /// The deleted alert ids.
        /// </value>
        /// <remarks>Id is UserId.</remarks>
        public List<string> DeletedAlertIds { get; set; }
    }
}
