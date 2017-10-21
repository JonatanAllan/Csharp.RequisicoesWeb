using System.Collections.Generic;
using Parte2.Interfaces;
using Recusos.ViewModels;
using RestSharp;

namespace Parte2.ServicosExternos
{
    public class JsonPlaceholderServicosExternos : BaseServicosExternos, IJsonPlaceholderServicosExternos
    {
        public JsonPlaceholderServicosExternos(string baseUrl) : base(baseUrl)
        {
            
        }
        public RespostaViewModel<PostViewModel> ObterPostagem(int codigo)
        {
            var recurso = $"/posts/{codigo}";
            var resposta = Executar(recurso, Method.GET);

            return new RespostaViewModel<PostViewModel>(resposta);
        }

        public RespostaViewModel<List<PostViewModel>> ListarPostagens(List<Parameter> parametros = null)
        {
            const string recurso = "/posts";
            var resposta = Executar(recurso, Method.GET);

            return new RespostaViewModel<List<PostViewModel>>(resposta);
        }

        public RespostaViewModel<PostViewModel> RealizarPostagem(string postagemJson)
        {
            const string recurso = "/posts";
            var resposta = Executar(recurso, Method.POST, null, null, postagemJson);

            return new RespostaViewModel<PostViewModel>(resposta);
        }

        public RespostaViewModel<PostViewModel> AtualizarPostagem(int codigo, string postagemJson)
        {
            var recurso = $"/posts/{codigo}";
            var resposta = Executar(recurso, Method.PUT, null, null, postagemJson);

            return new RespostaViewModel<PostViewModel>(resposta);
        }

        public RespostaViewModel<PostViewModel> RemoverPostagem(int codigo)
        {
            var recurso = $"/posts/{codigo}";
            var resposta = Executar(recurso, Method.DELETE);

            return new RespostaViewModel<PostViewModel>(resposta);
        }
    }
}
