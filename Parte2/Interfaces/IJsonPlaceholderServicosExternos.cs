using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recusos.ViewModels;
using RestSharp;

namespace Parte2.Interfaces
{
    public interface IJsonPlaceholderServicosExternos : IBaseServicosExternos
    {
        RespostaViewModel<PostViewModel> ObterPostagem(int codigo);

        RespostaViewModel<List<PostViewModel>> ListarPostagens(List<Parameter> parametros = null);

        RespostaViewModel<PostViewModel> RealizarPostagem(string postagemJson);

        RespostaViewModel<PostViewModel> AtualizarPostagem(int codigo, string postagemJson);

        RespostaViewModel<PostViewModel> RemoverPostagem(int codigo);
    }
}