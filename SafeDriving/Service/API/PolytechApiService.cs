using Newtonsoft.Json;
using SafeDriving.Models;
using System.Text;

namespace SafeDriving.Service.API
{
    public class PolytechApiService : IApi
    {
        private HttpClient _httpClient;
        private string _authToken;


        public PolytechApiService(string baseUrl)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseUrl);
        }

        public void SetAuthToken(string authToken)
        {
            _authToken = authToken;
        }

        public async Task<Schedule> GetSchedule(string groupName)
        {
            var queryParams = new Dictionary<string, object>
            {
                { "group", groupName },
                { "getSchedule", "" },
                { "token", _authToken ?? "" }
            };

            var response = await GetAsync("old/lk_api.php/", queryParams: queryParams);

            if(response.IsSuccessStatusCode)
            {
                try
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Schedule>(result);
                }
                catch(Exception ex)
                {
                    string e = ex.Message;
                }
            }

            return new Schedule();
        }

        private async Task<HttpResponseMessage> GetAsync(string endpoint, Dictionary<string, object> queryParams = null)
        {
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"/{endpoint}"
            };

            if (queryParams != null && queryParams.Any())
            {
                var query = string.Join("&", queryParams.Select(kvp => $"{kvp.Key}={kvp.Value}"));
                uriBuilder.Query = query;
            }

            return await _httpClient.GetAsync(uriBuilder.Uri);
        }
    }
}
