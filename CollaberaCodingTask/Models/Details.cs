namespace CollaberaCodingTask.Models
{
    /// <summary>
    /// Get Details about story
    /// </summary>
    public class Details
    {
        /// <summary>
        /// Get Id
        /// </summary>
        public string By { get; set; }

        /// <summary>
        /// Get Descendants
        /// </summary>
        public int Descendants { get; set; }

        /// <summary>
        /// get ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Get Kids
        /// </summary>
        public List<int> Kids { get; set; }

        /// <summary>
        /// Get Score
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Get Time
        /// </summary>
        public int Time { get; set; }

        /// <summary>
        /// Get Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Get Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Get URL
        /// </summary>
        public string Url { get; set; }
    }
}
