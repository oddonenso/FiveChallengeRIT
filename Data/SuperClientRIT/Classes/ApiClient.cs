using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SuperClientRIT.Classes
{
    public abstract class ApiClient
    {
        protected readonly HttpClient _httpClient;

        protected ApiClient(string baseAddress)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(baseAddress) };
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        protected async Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            return await _httpClient.GetAsync(requestUri);
        }

        protected async Task<HttpResponseMessage> PostAsync<T>(string requestUri, T content)
        {
            return await _httpClient.PostAsJsonAsync(requestUri, content);
        }

        protected async Task<HttpResponseMessage> PutAsync<T>(string requestUri, T content)
        {
            return await _httpClient.PutAsJsonAsync(requestUri, content);
        }

        protected async Task<HttpResponseMessage> DeleteAsync(string requestUri)
        {
            return await _httpClient.DeleteAsync(requestUri);
        }
    }
}
