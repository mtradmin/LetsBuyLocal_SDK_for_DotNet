using System.Collections.Generic;

namespace LetsBuyLocal.SDK.Models
{
    /// <summary>
    /// A response message deserialized from LetsBuyLocal.API
    /// </summary>
    /// <typeparam name="T">Object Type</typeparam>
    public class ResponseMessage<T>
    {
        public T Object { get; set; }
        public IList<ErrorMessage> Errors { get; set; }
        public bool Success { get; set; }
    }
}
