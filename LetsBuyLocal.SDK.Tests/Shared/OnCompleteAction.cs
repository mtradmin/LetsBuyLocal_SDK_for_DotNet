using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsBuyLocal.SDK.Tests.Shared
{
    /// <summary>
    /// Provides the valid values for Deal.OnCompleteAction property.
    /// </summary>
    public static class OnCompleteAction
    {
        public static string RunAgain { get; private set; }
        public static string SaveForLater { get; private set; }
        public static string Delete { get; private set; }

        static OnCompleteAction()
        {
            RunAgain = "RunAgain";
            SaveForLater = "SaveForLater";
            Delete = "Delete";
        }
    }
}
