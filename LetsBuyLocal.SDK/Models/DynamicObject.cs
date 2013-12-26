namespace LetsBuyLocal.SDK.Models
{
    /// <summary>
    /// Represents an untyped object returned in a ResponseMessage containing an object of type <typeparam name="T">T</typeparam>
    /// </summary>
    public class DynamicObject<T>
    {
        /// <summary>
        /// Gets or sets a value indicating whether [is successful].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is successful]; otherwise, <c>false</c>.
        /// </value>
        public bool IsSuccessful { get; set; }

        /// <summary>
        /// Gets or sets the status message.
        /// </summary>
        /// <value>
        /// The status message.
        /// </value>
        public string StatusMessage { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets data.
        /// </summary>
        /// <value>
        /// The data object.
        /// </value>
        public T Data { get; set; }
    }
}
