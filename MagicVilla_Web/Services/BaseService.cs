using MagicVilla_VillaAPI.Models;
using MagicVilla_Web.Services.IServices;

namespace MagicVilla_Web.Services
{
    public class BaseService : IBaseService
    {
        public required APIResponse ResponseModel { get; set; }

        public IHttpClientFactory HttpClient { get; set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            ResponseModel = new();
            HttpClient = httpClient;
        }

        public Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
