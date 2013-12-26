namespace LetsBuyLocal.SDK.Models
{
    /// <summary>
    /// Represents summary information and an object containing a list of invoices
    /// </summary>
    /// <typeparam name="T">A List Of type Invoice</typeparam>
    public class Pagination<T>
    {
        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        /// <value>
        /// The page.
        /// </value>
        public int Page { get; set; }
        /// <summary>
        /// Gets or sets the per page.
        /// </summary>
        /// <value>
        /// The per page.
        /// </value>
        public int PerPage { get; set; }
        /// <summary>
        /// Gets or sets the pages.
        /// </summary>
        /// <value>
        /// The pages.
        /// </value>
        public int Pages { get; set; }
        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>
        /// The total.
        /// </value>
        public int Total { get; set; }
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// A List of type Invoice
        /// </value>
        public T Data { get; set; }
    }
}
