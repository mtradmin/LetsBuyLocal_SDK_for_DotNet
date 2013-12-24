using System.Collections.Generic;

namespace LetsBuyLocal.SDK.Models
{
    /// <summary>
    /// A response message deserialized from LetsBuyLocal.API
    /// </summary>
    /// <typeparam name="T">Object Type contained.</typeparam>
    public class ResponseMessage<T>
    {
        /// <summary>
        /// Gets or sets the object.
        /// </summary>
        /// <value>
        /// The object.
        /// </value>
        public T Object { get; set; }
        /// <summary>
        /// Gets or sets the errors returned by the API.
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        public IList<ErrorMessage> Errors { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the API's method executed correctly [success].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [success]; otherwise, <c>false</c>.
        /// </value>
        public bool Success { get; set; }
    }
}
