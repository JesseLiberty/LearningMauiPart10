using LearningMauiPart10.Model;
using System.Net.Http.Json;

namespace LearningMauiPart10.Service
{
    public class ZipCodeService
    {
        HttpClient _httpClient;
        public ZipCodeService()
        {
            _httpClient = new HttpClient();
        }

        List<Result> _resultList = new();
        Root _root = new();

        public async Task<List<Result>> GetResults()
        {
            if (_resultList?.Count > 0)
                return _resultList;

            var url = "https://www.zipwise.com/webservices/citysearch.php?key=dksr5ewwvyy7tnjk&format=json&string=Acton";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                _root = await response.Content.ReadFromJsonAsync<Root>();
                _resultList = _root.results;
            }

            return _resultList;
        }

    }
}
