using Data.Tables;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SuperClientRIT.Classes
{
    public class DrillBlockPointClient : ApiClient
    {
        public DrillBlockPointClient(string baseAddress) : base(baseAddress) { }

        public async Task<IEnumerable<DrillBlockPoint>> GetDrillBlockPointsAsync()
        {
            var response = await GetAsync("api/DrillBlockPoints");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<DrillBlockPoint>>();
        }

        public async Task<DrillBlockPoint> GetDrillBlockPointAsync(int id)
        {
            var response = await GetAsync($"api/DrillBlockPoints/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<DrillBlockPoint>();
        }

        public async Task<DrillBlockPoint> CreateDrillBlockPointAsync(DrillBlockPoint drillBlockPoint)
        {
            var response = await PostAsync("api/DrillBlockPoints", drillBlockPoint);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<DrillBlockPoint>();
        }

        public async Task UpdateDrillBlockPointAsync(int id, DrillBlockPoint drillBlockPoint)
        {
            var response = await PutAsync($"api/DrillBlockPoints/{id}", drillBlockPoint);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteDrillBlockPointAsync(int id)
        {
            var response = await DeleteAsync($"api/DrillBlockPoints/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
