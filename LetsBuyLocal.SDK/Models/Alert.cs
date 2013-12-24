using System;
using System.ComponentModel.DataAnnotations;

namespace LetsBuyLocal.SDK.Models
{
    /// <summary>
    /// Represents an alert notifying the user of an occurrence.
    /// </summary>
    public class Alert : BaseEntity
    {
        /// <summary>
        /// Gets or sets the store identifier.
        /// </summary>
        /// <value>
        /// The store identifier.
        /// </value>
        [Required]
        public string StoreId { get; set; }
        /// <summary>
        /// Gets or sets the entity identifier.
        /// </summary>
        /// <value>
        /// The entity identifier.
        /// </value>
        public string EntityId { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [Required]
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the type of alert.
        /// </summary>
        /// <value>
        /// The type (STORE/DEAL/COUPON).
        /// </value>
        [Required]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the schedule for.
        /// </summary>
        /// <value>
        /// The schedule for.
        /// </value>
        public DateTime? ScheduleFor { get; set; }

        /// <summary>
        /// Gets or sets the date sent.
        /// </summary>
        /// <value>
        /// The date sent.
        /// </value>
        public DateTime? DateSent { get; set; }

        /// <summary>
        /// Gets or sets the posted to facebook.
        /// </summary>
        /// <value>
        /// The posted to facebook.
        /// </value>
        public DateTime? PostedToFacebook { get; set; }

        /// <summary>
        /// Gets or sets the fb post error.
        /// </summary>
        /// <value>
        /// The fb post error.
        /// </value>
        public string FbPostError { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [read].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [read]; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>Used internally to know if the Alert has been read.</remarks>
        public bool Read { get; set; } 
    }
}
