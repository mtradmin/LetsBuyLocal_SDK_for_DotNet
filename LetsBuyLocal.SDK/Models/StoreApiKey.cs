using System.ComponentModel.DataAnnotations;

namespace LetsBuyLocal.SDK.Models
{
    public class StoreApiKey : BaseEntity
    {
        [Required]
        public string StoreId { get; set; }
    }
}
