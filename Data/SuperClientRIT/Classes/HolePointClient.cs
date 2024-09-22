using Data.Tables;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SuperClientRIT.Classes
{
    public class HolePointClient : ApiClient
    {
        public HolePointClient(string baseAddress) : base(baseAddress) { }

        public async Task<IEnumerable<HolePoint>> GetHolePointsAsync()
        {
            var response = await GetAsync("api/HolePoints");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<HolePoint>>();
        }

        public async Task<HolePoint> GetHolePointAsync(int id)
        {
            var response = await GetAsync($"api/HolePoints/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<HolePoint>();
        }

        public async Task<HolePoint> CreateHolePointAsync(HolePoint holePoint)
        {
            var response = await PostAsync("api/HolePoints", holePoint);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<HolePoint>();
        }

        public async Task UpdateHolePointAsync(int id, HolePoint holePoint)
        {
            var response = await PutAsync($"api/HolePoints/{id}", holePoint);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteHolePointAsync(int id)
        {
            var response = await DeleteAsync($"api/HolePoints/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
