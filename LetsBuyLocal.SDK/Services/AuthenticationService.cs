using System;
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
        /// <exception cref="System.ApplicationException">Unable to authenticate user, using specified email and password.  + ex.Message</exception>
        public ResponseMessage<User> Authenticate(User user)
        {
            try
            {
                var resp = Post<ResponseMessage<User>>("Authentication", user);
                return resp;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to authenticate user, using specified email and password. " + ex.Message);
            }
        }

        /// <summary>
        /// Requests a password reset
        /// </summary>
        /// <param name="user">A User object (can be initialized with only the email).</param>
        /// <returns>
        /// A ResponseMessage of type boolean: True, if successful; else false
        /// </returns>
        /// <exception cref="System.ApplicationException">Unable to process password reset using the specified email. + ex.Message</exception>
        public ResponseMessage<bool> RequestPasswordReset(User user)
        {
            try
            {
                var isSuccessResp = Post<ResponseMessage<bool>>("Authentication/ForgotPassword", user);
                return isSuccessResp;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to process password reset using the specified email." + ex.Message);
            }
        }

    }
}