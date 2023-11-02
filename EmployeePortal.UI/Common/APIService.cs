﻿using Newtonsoft.Json;
using System.Text;

namespace EmployeePortal.UI.Common
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<T>> GetAllAsync<T>(string requestUri)
        {
            var response = await _httpClient.GetAsync(requestUri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<T>>(content);
            }
            return Enumerable.Empty<T>(); 
            // Handle error scenarios or throw exceptions as needed
        }
        public async Task<T> GetAsync<T>(string requestUri)
        {
            var response = await _httpClient.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }
            return default(T);
            // Handle error scenarios or throw exceptions as needed
            // For example: return default(T), throw custom exceptions, etc.
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string requestUri, TRequest data)
        {
            try
            {
                var jsonContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(requestUri, jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(content);
                    return JsonConvert.DeserializeObject<TResponse>(content);
                }
                return default(TResponse);
            }
            catch (Exception ex) { throw ex; }
            // Handle error scenarios or throw exceptions as needed
            // For example: return default(TResponse), throw custom exceptions, etc.
        }
        public async Task<string> PostAsync<TRequest>(string requestUri, TRequest data)
        {
            var jsonContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(requestUri, jsonContent);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            // Handle error scenarios or throw exceptions as needed
            // For example: throw custom exceptions, log the error, etc.
            return null; // Or return a default value
        }

    }

}
