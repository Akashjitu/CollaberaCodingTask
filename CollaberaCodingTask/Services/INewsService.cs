
using CollaberaCodingTask.Models;
using CollaberaCodingTask.Models.RpgModels;

namespace CollaberaCodingTask.Services
{
    /// <summary>
    /// This is Service Class, which provide connect with Stories
    /// </summary>
    public interface INewsService
    {
        /// <summary>
        /// Get all best stories
        /// </summary>
        /// <param name="cancellationToken">if case user want to cancle taks</param>
        /// <returns>ServiceResponse with array int</returns>
        Task<ServiceResponse<int[]?>> GetStoriesAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Get the Select Story Info
        /// </summary>
        /// <param name="storyid">story id</param>
        /// <param name="cancellationToken">if case user want to cancle taks</param>
        /// <returns>erviceResponse with stroy Details</returns>
        Task<ServiceResponse<Details>> GetStoryAsync(int storyid, CancellationToken cancellationToken);
    }
}