using static MagicVilla_Utility.SD;

namespace MagicVilla_VillaAPI.Models
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; }

        public string Url { get; set; }

        public object Data { get; set; }
    }
}
