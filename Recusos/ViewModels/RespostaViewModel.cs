using System;
using System.Net.Http;
using Newtonsoft.Json;
using RestSharp;
using System.Net.Http.Formatting;

namespace Recusos.ViewModels
{
    public class RespostaViewModel<TEntidade> : HttpResponseMessage where TEntidade : class
    {
        private readonly MediaTypeFormatter _formatter = new JsonMediaTypeFormatter();

        [JsonIgnore]
        public TEntidade Conteudo { get; set; }

        [JsonIgnore]
        public string Corpo { get; set; }

        public RespostaViewModel(IRestResponse response)
        {
            StatusCode = response.StatusCode;

            try
            {
                Corpo = response.Content;
                Conteudo = JsonConvert.DeserializeObject<TEntidade>(response.Content);
                Content = new ObjectContent<TEntidade>(Conteudo, _formatter);

            }
            catch (Exception ex)
            {
                Content = new ObjectContent<Exception>(ex, _formatter);
            }
        }
    }
}
