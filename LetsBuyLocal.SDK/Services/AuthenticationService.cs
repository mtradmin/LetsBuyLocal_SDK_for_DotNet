using LetsBuyLocal.SDK.Models;

namespace LetsBuyLocal.SDK.Services
{
    /// <summary>
    /// Handles CRUD operations for Authentication.
    /// </summary>
    public class AuthenticationService : BaseService
    {
        /// <summary>
        /// Authenticates the user
        /// </summary>
        /// <param name="user">A User object (can be initialized with only the email and password).</param>
        /// <returns>
        /// A ResponseMessage of type User
        /// </returns>
        public ResponseMessage<User> Authenticate(User user)
        {
            var resp = Post<ResponseMessage<User>>("Authentication", user);
            return resp;
        }

        /// <summary>
        /// Requests a password reset
        /// </summary>
        /// <param name="user">A User object (can be initialized with only the email).</param>
        /// <returns>
        /// A ResponseMessage of type boolean: True, if successful; else false
        /// </returns>
        public ResponseMessage<bool> RequestPasswordReset(User user)
        {
            var isSuccessResp = Post<ResponseMessage<bool>>("Authentication/ForgotPassword", user);
            return isSuccessResp;
        }

    }
}