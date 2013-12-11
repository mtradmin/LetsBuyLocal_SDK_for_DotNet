using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsBuyLocal.SDK.Models;

namespace LetsBuyLocal.SDK.Shared
{
    public class Utilities
    {
        /// <summary>
        /// Returns the list of ErrorMessage items.
        /// </summary>
        /// <param name="errors">The list of ErrorMessage items.</param>
        /// <returns>A list of ErrorMessage items.</returns>
        public static string ResponseErrors(IList<ErrorMessage> errors)
        {
            var sb = new StringBuilder();
            foreach (var error in errors)
            {
                sb.Append(error.Description);
                sb.Append(" ");
            }

            var s = sb.ToString();
            return s;
        }
    }
}
