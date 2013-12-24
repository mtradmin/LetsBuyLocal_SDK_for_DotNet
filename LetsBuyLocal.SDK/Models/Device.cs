using System.ComponentModel.DataAnnotations;

namespace LetsBuyLocal.SDK.Models
{
    /// <summary>
    /// Represents a user's device.
    /// </summary>
    public class Device : BaseEntity
    {
        /// <summary>
        /// Gets or sets the device token.
        /// </summary>
        /// <value>
        /// The device token.
        /// </value>
        [Required]
        public string DeviceToken { get; set; }
        /// <summary>
        /// Gets or sets the platform.
        /// </summary>
        /// <value>
        /// The platform  (ios or Android).
        /// </value>
        public string Platform { get; set; }
    }
}
