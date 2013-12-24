using System.ComponentModel.DataAnnotations;

namespace LetsBuyLocal.SDK.Models
{
    /// <summary>
    /// Maintains relationship between store's and their assigned API Key.
    /// </summary>
    /// <remarks>
    /// The API Key is assigned to a store behind the scenes when a store is created.
    /// </remarks>
    public class StoreApiKey : BaseEntity
    {
        /// <summary>
        /// Gets or sets the store identifier.
        /// </summary>
        /// <value>
        /// The store identifier.
        /// </value>
        [Required]
        public string StoreId { get; set; }
    }
}
