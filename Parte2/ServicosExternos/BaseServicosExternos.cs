using System.Collections.Generic;
using Parte2.Interfaces;
using RestSharp;

namespace Parte2.ServicosExternos
{
    public abstract class BaseServicosExternos : IBaseServicosExternos
    {
        private readonly RestClient _cliente;

        protected BaseServicosExternos(string baseUrl)
        {
            _cliente = new RestClient(baseUrl);
        }

        public Parameter CriarParametro(string nome, object valor, ParameterType tipo = ParameterType.QueryString)
        {
            return new Parameter
            {
                Name = nome,
                Value = valor,
                Type = tipo
            };
        }

        public IRestResponse Executar(string recurso, Method metodo, List<Parameter> parametros = null, 
            List<Parameter> cabecalhos = null, object corpo = null)
        {
            var requisicao = new RestRequest(recurso, metodo)
            {
                RequestFormat = DataFormat.Json
            };

            requisicao.AddHeader("Accept", "application/json");

            if (cabecalhos != null)
            {
                foreach (var cabecalho in cabecalhos)
                {
                    requisicao.AddHeader(cabecalho.Name, cabecalho.Value.ToString());
                }
            }

            if (parametros != null)
            {
                foreach (var parametro in parametros)
                {
                    requisicao.AddParameter(parametro.Name, parametro.Value.ToString(), parametro.ContentType, parametro.Type);
                }
            }

            if (corpo != null) requisicao.AddParameter("application/json", corpo, ParameterType.RequestBody);

            return _cliente.Execute(requisicao);
        }
    }
}
