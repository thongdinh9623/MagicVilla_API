using MagicVilla_VillaAPI.Models;

namespace MagicVilla_Web.Services.IServices
{
    public interface IBaseService
    {
        public ApiResponse ResponseModel { get; set; }

        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
