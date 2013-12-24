using System;
using System.ComponentModel.DataAnnotations;

namespace LetsBuyLocal.SDK.Models
{
    /// <summary>
    /// Represents a deal.
    /// </summary>
    public class Deal : BaseEntity
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
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the total available.
        /// </summary>
        /// <value>
        /// The total available.
        /// </value>
        [Required]
        public int TotalAvailable { get; set; }

        /// <summary>
        /// Short hint about deal.
        /// </summary>
        /// <value>
        /// The hint.
        /// </value>
        /// <remarks>
        /// Required, if Deal is to be Published.
        /// </remarks>
        public string Hint { get; set; }

        /// <summary>
        /// Gets or sets the extension days.
        /// </summary>
        /// <value>
        /// The extension days.
        /// </value>
        public int ExtensionDays { get; set; }

        /// <summary>
        /// Identifies action to be taken when deal completes (RunAgain/SaveForLater/Delete)
        /// </summary>
        /// <value>
        /// The on complete action.
        /// </value>
        public string OnCompleteAction { get; set; }
        /// <summary>
        /// Gets or sets the expiration date.
        /// </summary>
        /// <value>
        /// The expiration date.
        /// </value>
        public DateTime? ExpirationDate { get; set; }

        /// <summary>
        /// Date deal starts
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        /// <remarks>
        /// Cannot start until previous deal has expired.
        /// </remarks>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [published] (Active).
        /// </summary>
        /// <value>
        ///   <c>true</c> if [published]; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// 1. Cannot modify a deal while this value is true.
        /// 2. Cannot set this value to false if this deal has any reservations made.
        /// </remarks>
        public bool Published { get; set; }

        /// <summary>
        /// Gets or sets the normal price.
        /// </summary>
        /// <value>
        /// The normal price.
        /// </value>
        public decimal? NormalPrice { get; set; }
        /// <summary>
        /// Gets or sets the percent off.
        /// </summary>
        /// <value>
        /// The percent off.
        /// </value>
        public int? PercentOff { get; set; }

        /// <summary>
        /// Gets or sets the copied from identifier.
        /// </summary>
        /// <value>
        /// The copied from identifier.
        /// </value>
        public string CopiedFromId { get; set; }
        /// <summary>
        /// Gets or sets the date and time posted to Facebook.
        /// </summary>
        /// <value>
        /// The datetime when posted to Facebook.
        /// </value>
        public DateTime? PostedToFacebook { get; set; }
        /// <summary>
        /// Gets or sets the Facebook post error.
        /// </summary>
        /// <value>
        /// The fb post error.
        /// </value>
        public string FbPostError { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [publish complete action done].
        /// </summary>
        /// <value>
        /// <c>true</c> if [publish complete action done]; otherwise, <c>false</c>.
        /// </value>
        public bool PublishCompleteActionDone { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [has active reservations].
        /// </summary>
        /// <value>
        /// <c>true</c> if [has active reservations]; otherwise, <c>false</c>.
        /// </value>
        public bool HasActiveReservations { get; set; }

        /// <summary>
        /// Gets or sets the savings.
        /// </summary>
        /// <value>
        /// The savings.
        /// </value>
        public decimal? Savings { get; set; }

        /// <summary>
        /// Gets or sets the normal price string.
        /// </summary>
        /// <value>
        /// The normal price string.
        /// </value>
        public string NormalPriceString { get; set; }

        /// <summary>
        /// Gets or sets the deal price string.
        /// </summary>
        /// <value>
        /// The deal price string.
        /// </value>
        public string DealPriceString { get; set; }

        /// <summary>
        /// Gets or sets the savings string.
        /// </summary>
        /// <value>
        /// The savings string.
        /// </value>
        public string SavingsString { get; set; }

        /// <summary>
        /// Gets or sets the percent off string.
        /// </summary>
        /// <value>
        /// The percent off string.
        /// </value>
        public string PercentOffString { get; set; }

        /// <summary>
        /// Gets or sets the user purchase (DealReservation).
        /// </summary>
        /// <value>
        /// The user purchase.
        /// </value>
        public DealReservation UserPurchase { get; set; }

        /// <summary>
        /// Gets or sets the store.
        /// </summary>
        /// <value>
        /// The store.
        /// </value>
        public Store Store { get; set; }
    }
}
