using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LetsBuyLocal.SDK.Models
{
    public class StoreApiKey : BaseEntity
    {
        [Required]
        public string StoreId { get; set; }
    }
}
