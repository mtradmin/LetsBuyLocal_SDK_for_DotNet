namespace LetsBuyLocal.SDK.Tests.Shared
{
    /// <summary>
    /// Represents the valid opitons for Deal.OnCompleteAction property.
    /// </summary>
    public static class OnCompleteAction
    {
        /// <summary>
        /// Gets the RunAgain option.
        /// </summary>
        /// <value>
        /// The run again option.
        /// </value>
        public static string RunAgain { get; private set; }
        /// <summary>
        /// Gets the SaveForLater option.
        /// </summary>
        /// <value>
        /// The SaveForLater.
        /// </value>
        public static string SaveForLater { get; private set; }
        /// <summary>
        /// Gets the Delete option.
        /// </summary>
        /// <value>
        /// The delete.
        /// </value>
        public static string Delete { get; private set; }

        /// <summary>
        /// Initializes the <see cref="OnCompleteAction"/> class.
        /// </summary>
        static OnCompleteAction()
        {
            RunAgain = "RunAgain";
            SaveForLater = "SaveForLater";
            Delete = "Delete";
        }
    }
}
