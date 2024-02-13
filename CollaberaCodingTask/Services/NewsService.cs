using CollaberaCodingTask.Models;
using CollaberaCodingTask.Models.RpgModels;
using Polly;
using System.Net;
using System.Text.Json;

namespace CollaberaCodingTask.Services
{
    ///<inheritdoc/>
    public class NewsService : INewsService
    {
        private const string StoriesUrl = "beststories.json";
        private const string StoryIdUrl = "item/{0}.json";

        private readonly HttpClient _client;

        public NewsService(HttpClient client)
        {
            _client = client;
        }


        ///<inheritdoc/>
        public async Task<ServiceResponse<int[]?>> GetStoriesAsync(CancellationToken cancellationToken)
        {
            var serviceResponse = new ServiceResponse<int[]?>();
            try
            {
                var content = await CreatePollyRequest(StoriesUrl, cancellationToken).ConfigureAwait(false);
                var result = JsonSerializer.Deserialize<int[]>(content);
                serviceResponse.Data = result;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        ///<inheritdoc/>
        public async Task<ServiceResponse<Details?>> GetStoryAsync(int storyid, CancellationToken cancellationToken)
        {
            var serviceResponse = new ServiceResponse<Details?>();
            try
            {
                var content = await CreatePollyRequest(string.Format(StoryIdUrl, storyid), cancellationToken).ConfigureAwait(false);
                var result = JsonSerializer.Deserialize<Details>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                serviceResponse.Data = result;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }


        /// <summary>
        /// This will help try the for 3 attempts, in case of service is down.
        /// </summary>
        /// <param name="url">URL</param>
        /// <param name="cancellationToken">cancel taks any time</param>
        /// <returns></returns>
        private async Task<string> CreatePollyRequest(string url, CancellationToken cancellationToken)
        {
            var policyWithDelay = Policy.HandleResult<HttpResponseMessage>(r => r.StatusCode == HttpStatusCode.TooManyRequests) // retry on 429 errors
                                         .WaitAndRetryAsync(3,// up to 3 attempts
                                           retryAttempt => TimeSpan.FromSeconds(Math.Pow(5, retryAttempt)) // 5-second-based backoff exponential waiting logic
                                         );

            var response = await policyWithDelay.ExecuteAsync(() => _client.GetAsync(url, cancellationToken));

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
