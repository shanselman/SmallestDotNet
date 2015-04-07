namespace SmallestDotNetLib
{
    /// <summary>
    /// Encapsulates the results from the parsing of user agent / version
    /// </summary>
    public class UpdateInformationResponse
    {
        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether the current OS can run the checker application.
        /// </summary>
        public bool CanRunCheckApp { get; set; }

        /// <summary>
        /// Gets or sets the text to be displayed to the user.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the CLR version was able to be detected.
        /// </summary>
        public bool VersionCanBeDetermined { get; set; }

        #endregion Properties
    }
}