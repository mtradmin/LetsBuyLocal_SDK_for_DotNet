using System.Collections.Generic;

namespace LetsBuyLocal.SDK.Models
{
    public class ResponseMessage<T>
    {
        public T Object { get; set; }
        public IList<ErrorMessage> Errors { get; set; }
        public bool Success { get; set; }
    }
}
