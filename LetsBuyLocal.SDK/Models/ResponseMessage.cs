using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsBuyLocal.SDK.Models
{
    public class ResponseMessage<T>
    {
        public T Object { get; set; }
        public IList<ErrorMessage> Errors { get; set; }
        public bool Success { get; set; }
    }
}
