using LearningMauiPart10.Model;
using System.Net.Http.Json;

namespace LearningMauiPart10.Service
{
    public class ZipCodeService
    {
        IConnectivity connectivity;
        HttpClient _httpClient;
        public ZipCodeService(IConnectivity connectivity)
        {
            _httpClient = new HttpClient();
            this.connectivity = connectivity;
        }

        List<Result> _resultList = new();
        Root _root = new();

        public async Task<List<Result>> GetResults()
        {
            if (_resultList?.Count > 0)
                return _resultList;

            if (connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("No Internet", "Please check your internet connection", "OK");
                return null;
            }

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
