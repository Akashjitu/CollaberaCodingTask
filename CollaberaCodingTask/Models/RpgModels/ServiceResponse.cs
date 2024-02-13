namespace CollaberaCodingTask.Models.RpgModels
{
    /// <summary>
    /// This class is a kind of payload with the checks and erro message.
    /// </summary>
    /// <typeparam name="T">Data Type</typeparam>
    public class ServiceResponse<T>
    {
        /// <summary>
        /// Payload Data
        /// </summary>
        public T? Data { get; set; }

        /// <summary>
        /// Is Request Success
        /// </summary>
        public bool Success { get; set; } = true;


        /// <summary>
        /// Get the error message 
        /// </summary>
        public string Message { get; set; } = string.Empty;

    }
}
