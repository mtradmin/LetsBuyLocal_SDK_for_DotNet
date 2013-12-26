namespace LetsBuyLocal.SDK.Models
{
    /// <summary>
    /// Represents an invoice item.
    /// </summary>
    public class InvoiceItem
    {
        /// <summary>
        /// Gets or sets the invoice identifier (PK).
        /// </summary>
        /// <value>
        /// The invoice identifier.
        /// </value>
        public string InvoiceId { get; set; }
        /// <summary>
        /// Gets or sets the dealer identifier for the dealer this invoice belongs to.
        /// </summary>
        /// <value>
        /// The dealer identifier.
        /// </value>
        public string DealerId { get; set; } 
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        /// <remarks>For parts feed, use part number, for service and bikes feeds have empty string</remarks>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the desc.
        /// </summary>
        /// <value>
        /// The desc.
        /// </value>
        /// <remarks>
        /// For parts use PartDesc, 
        /// for service use JobDesc, 
        /// for bikes use Year \u00B7 Make \u00B7 Model, (NOTE: \u00B7 is the unicode for ampersanddot; 
        /// since ampersanddot; doesn't work on iphone5 says Patrick</remarks>
        public string Desc { get; set; } 
        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public int Quantity { get; set; }
        /// <summary>
        /// Gets or sets the price per.
        /// </summary>
        /// <value>
        /// The price per.
        /// </value>
        public decimal PricePer { get; set; }
        /// <summary>
        /// Gets or sets the total price.
        /// </summary>
        /// <value>
        /// The total price.
        /// </value>
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// Gets or sets the total points.
        /// </summary>
        /// <value>
        /// The total points.
        /// </value>
        public decimal TotalPoints { get; set; }
    }
}
