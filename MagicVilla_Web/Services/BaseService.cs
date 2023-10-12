using MagicVilla_Utility;
using MagicVilla_Web.Models;
using MagicVilla_Web.Services.IServices;
using Newtonsoft.Json;
using System.Text;

namespace MagicVilla_Web.Services
{
    public class BaseService : IBaseService
    {
        public required ApiResponse ResponseModel { get; set; }

        public IHttpClientFactory HttpClient { get; set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            ResponseModel = new();
            HttpClient = httpClient;
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                HttpClient client = HttpClient.CreateClient("MagicAPI");
                HttpRequestMessage message = new();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url ?? "");
                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(
                        JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8,
                        "application/json");
                }
                message.Method = apiRequest.ApiType switch
                {
                    SD.ApiType.POST => HttpMethod.Post,
                    SD.ApiType.PUT => HttpMethod.Put,
                    SD.ApiType.DELETE => HttpMethod.Delete,
                    _ => HttpMethod.Get,
                };
                HttpResponseMessage apiResponse
                    = await client.SendAsync(message);
                string apiContent
                    = await apiResponse.Content.ReadAsStringAsync();
                T? apiContentModel
                    = JsonConvert.DeserializeObject<T>(apiContent);
                return apiContentModel == null
                    ? throw new Exception("apiContentModel null") : apiContentModel;
            }
            catch (Exception ex)
            {
                ApiResponse apiResponse = new()
                {
                    ErrorMessages
                    = new List<string> { Convert.ToString(ex.Message) },
                    IsSuccess = false,
                };
                string apiResponseJson
                    = JsonConvert.SerializeObject(apiResponse);
                T? apiResponseModel
                    = JsonConvert.DeserializeObject<T>(apiResponseJson);
                return apiResponseModel == null
                    ? throw new Exception("abc") : apiResponseModel;
            }
        }
    }
}
