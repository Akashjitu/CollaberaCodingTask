using CollaberaCodingTask.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace CollaberaCodingTask.Controllers
{
    /// <summary>
    /// This Class, which provide connect with Stories
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }


        /// <summary>
        /// Get First Story 
        /// </summary>
        /// <returns> ActionResult </returns>
        [HttpGet("GetFirstBestStory")]
        public async Task<ActionResult> GetFirstStoryAsync(CancellationToken cancellationToken)
        {
            var stories = await _newsService.GetStoriesAsync(cancellationToken);

            if (stories.Data == null || stories.Data.Count() == 0)
                NotFound(stories);
            var story = await _newsService.GetStoryAsync(stories.Data[0], cancellationToken);
            if (story.Data == null)
                NotFound(story);


            return Ok(story);
        }

        /// <summary>
        /// Get all Best Stories 
        /// </summary>
        /// <returns>ActionResult</returns>
        [HttpGet("GetBestStories")]
        public async Task<ActionResult> GetBestStoriesAsync(CancellationToken cancellationToken)
        {
            var stories = await _newsService.GetStoriesAsync(cancellationToken);

            if (stories.Data == null)
                NotFound(stories);

            return Ok(stories);
        }

        /// <summary>
        /// Get Story 
        /// </summary>
        /// <returns>ActionResult</returns>
        [HttpGet("GetStory")]
        public async Task<ActionResult> GetStoryAsync(int storyid, CancellationToken cancellationToken)
        {
            var story = await _newsService.GetStoryAsync(storyid, cancellationToken);
            if (story.Data == null)
                NotFound(story);
            return Ok(story);
        }

    }
}
