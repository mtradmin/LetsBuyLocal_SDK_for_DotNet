namespace LetsBuyLocal.SDK.Models
{
    /// <summary>
    /// Represents the set of information authenticating a user. 
    /// </summary>
    public class Authentication : BaseEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public override string Id { get; set; }

        /// <summary>
        /// Gets or sets the email (or FacebookUserId).
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the facebook user identifier.
        /// </summary>
        /// <value>
        /// The facebook user identifier.
        /// </value>
        public string FacebookUserId { get; set; }
    }
}
