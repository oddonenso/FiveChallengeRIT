using Data.Tables;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SuperClientRIT.Classes
{
    public class HoleClient : ApiClient
    {
        public HoleClient(string baseAddress) : base(baseAddress) { }

        public async Task<IEnumerable<Hole>> GetHolesAsync()
        {
            var response = await GetAsync("api/Holes");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<Hole>>();
        }

        public async Task<Hole> GetHoleAsync(int id)
        {
            var response = await GetAsync($"api/Holes/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Hole>();
        }

        public async Task<Hole> CreateHoleAsync(Hole hole)
        {
            var response = await PostAsync("api/Holes", hole);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Hole>();
        }

        public async Task UpdateHoleAsync(int id, Hole hole)
        {
            var response = await PutAsync($"api/Holes/{id}", hole);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteHoleAsync(int id)
        {
            var response = await DeleteAsync($"api/Holes/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
