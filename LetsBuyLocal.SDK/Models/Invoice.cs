using System;
using System.Collections.Generic;

namespace LetsBuyLocal.SDK.Models
{
    /// <summary>
    /// Represents an invoice
    /// </summary>
    public class Invoice
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the dealer identifier.
        /// </summary>
        /// <value>
        /// The dealer identifier.
        /// </value>
        public string DealerId { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public string UserId { get; set; }
        /// <summary>
        /// Gets or sets the invoice date.
        /// </summary>
        /// <value>
        /// The invoice date.
        /// </value>
        public DateTime InvoiceDate { get; set; }
        /// <summary>
        /// Gets or sets the invoice time.
        /// </summary>
        /// <value>
        /// The invoice time.
        /// </value>
        /// <remarks>//Empty for gateway feeds, but populated for new cashier buddy methods.</remarks>
        public string InvoiceTime { get; set; } 
        /// <summary>
        /// Gets or sets the order total.
        /// </summary>
        /// <value>
        /// The order total.
        /// </value>
        public decimal OrderTotal { get; set; }
        /// <summary>
        /// Gets or sets the points total.
        /// </summary>
        /// <value>
        /// The points total.
        /// </value>
        public decimal PointsTotal { get; set; }
        /// <summary>
        /// Gets or sets the items in an invoice.
        /// </summary>
        /// <value>
        /// The items in an invoice.
        /// </value>
        public List<InvoiceItem> Items { get; set; } 
    }
}
