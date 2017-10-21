using Newtonsoft.Json;

namespace Recusos.ViewModels
{
    public class PostViewModel
    {
        [JsonProperty("id")]
        public int Codigo { get; set; }

        [JsonProperty("userId")]
        public int CodigoUsuario { get; set; }

        [JsonProperty("title")]
        public string Titulo { get; set; }

        [JsonProperty("body")]
        public string Corpo { get; set; }
    }
}
