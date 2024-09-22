using Data.Tables;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SuperClientRIT.Classes
{
    public class DrillBlockClient : ApiClient
    {
        public DrillBlockClient(string baseAddress) : base(baseAddress) { }

        public async Task<IEnumerable<DrillBlock>> GetDrillBlocksAsync()
        {
            var response = await GetAsync("api/DrillBlocks");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<DrillBlock>>();
        }

        public async Task<DrillBlock> GetDrillBlockAsync(int id)
        {
            var response = await GetAsync($"api/DrillBlocks/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<DrillBlock>();
        }

        public async Task<DrillBlock> CreateDrillBlockAsync(DrillBlock drillBlock)
        {
            var response = await PostAsync("api/DrillBlocks", drillBlock);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<DrillBlock>();
        }

        public async Task UpdateDrillBlockAsync(int id, DrillBlock drillBlock)
        {
            var response = await PutAsync($"api/DrillBlocks/{id}", drillBlock);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteDrillBlockAsync(int id)
        {
            var response = await DeleteAsync($"api/DrillBlocks/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
