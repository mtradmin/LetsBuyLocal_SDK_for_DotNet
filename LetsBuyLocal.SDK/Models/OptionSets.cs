using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsBuyLocal.SDK.Models
{
    public class OptionSets : BaseEntity
    {
        public IList<string> StoreCategories { get; set; }

        public IList<string> States { get; set; }

        public IList<string> Countries { get; set; }

        public IList<string> TimeZones { get; set; }
    }
}
