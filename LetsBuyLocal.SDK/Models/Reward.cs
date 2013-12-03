using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LetsBuyLocal.SDK.Models
{
    public class Reward : BaseEntity
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Hint { get; set; }

        public int SortOrder { get; set; }

        [Required]
        public string StoreId { get; set; }

        public Store Store { get; set; }

        public DateTime ExpireDate { get; set; }
    }
}
