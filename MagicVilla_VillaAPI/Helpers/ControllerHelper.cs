using MagicVilla_VillaAPI.Models;

namespace MagicVilla_VillaAPI.Helpers
{
    public static class ControllerHelper
    {
        public static void AddDataToErrorResponse(
            ApiResponse apiResponse,
            params string[] errorList)
        {
            apiResponse.IsSuccess = false;
            apiResponse.ErrorMessages = new List<string>(errorList);
        }
    }
}
