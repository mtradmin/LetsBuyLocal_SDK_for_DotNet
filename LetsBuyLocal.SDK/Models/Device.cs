using System.ComponentModel.DataAnnotations;

namespace LetsBuyLocal.SDK.Models
{
    public class Device : BaseEntity
    {
        [Required]
        public string DeviceToken { get; set; }
        public string Platform { get; set; }
    }
}
