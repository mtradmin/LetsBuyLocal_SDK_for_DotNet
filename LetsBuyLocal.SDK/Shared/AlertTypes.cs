using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsBuyLocal.SDK.Shared
{
    public static class AlertTypes
    {
        public static string StoreAlert
        {
            get { return "STORE"; }
        }
        
        public static string DealAlert
        {
            get { return "DEAL"; }
        }

        public static string CouponAlert
        {
            get { return "COUPON"; }
        }
    }
}
