using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsBuyLocal.SDK.Models
{
    public class FBSettings
    {
        public string Account { get; set; }
        public string Page { get; set; }
        public string PageAccessToken { get; set; }
        public bool PublishAlerts { get; set; }
        public bool PublishDeals { get; set; }
    }
}
