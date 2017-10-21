using System.Collections.Generic;
using RestSharp;

namespace Parte2.Interfaces
{
    public interface IBaseServicosExternos
    {
        Parameter CriarParametro(string nome, object valor, ParameterType tipoParametro = ParameterType.QueryString);

        IRestResponse Executar(string recurso, Method metodo, List<Parameter> cabecalhos = null, List<Parameter> parametros = null, object corpo = null);
    }
}
