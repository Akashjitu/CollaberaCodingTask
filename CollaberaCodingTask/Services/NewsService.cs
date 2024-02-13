using CollaberaCodingTask.Models;
using CollaberaCodingTask.Models.RpgModels;
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
                using (var reponse = await _client.GetAsync(StoriesUrl, cancellationToken).ConfigureAwait(false))
                {
                    reponse.EnsureSuccessStatusCode();
                    var content = await reponse.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                    var result = JsonSerializer.Deserialize<int[]>(content);
                    serviceResponse.Data = result;
                }
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
                using (var reponse = await _client.GetAsync(string.Format(StoryIdUrl, storyid), cancellationToken).ConfigureAwait(false))
                {
                    reponse.EnsureSuccessStatusCode();

                    var content = await reponse.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                    var result = JsonSerializer.Deserialize<Details>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    serviceResponse.Data = result;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}
