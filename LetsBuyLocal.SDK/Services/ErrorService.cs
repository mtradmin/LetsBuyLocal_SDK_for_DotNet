using LetsBuyLocal.SDK.Models;

namespace LetsBuyLocal.SDK.Services
{
    /// <summary>
    /// Handles CRUD operations for Error objects.
    /// </summary>
    public class ErrorService : BaseService
    {

        /// <summary>
        /// Creates the error.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <returns>A ResponseMessage containing an object of type Error.</returns>
        public ResponseMessage<bool> CreateError(Error error)
        {
            var resp = Post<ResponseMessage<bool>>("Error", error);
            return resp;
        }
    }
}
