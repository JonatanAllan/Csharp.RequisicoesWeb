using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Recusos.ViewModels;
using RestSharp;

namespace Parte1
{
    public class Program
    {
        private const string UrlBase = "http://jsonplaceholder.typicode.com";

        private static readonly RestClient Cliente = new RestClient(UrlBase);

        public static void Main(string[] args)
        {
            Get();
            Post();
            Console.ReadKey();
        }

        public static void Get()
        {
            var requisicao = new RestRequest("/posts", Method.GET);

            var parametro = new Parameter
            {
                Name = "userId",
                Value = 1,
                Type = ParameterType.QueryString
            };

            requisicao.AddParameter(parametro);

            var resposta = Cliente.Execute(requisicao);

            var posts = JsonConvert.DeserializeObject<List<PostViewModel>>(resposta.Content);

            foreach (var post in posts)
            {
                Console.WriteLine($"Post código: {post.Codigo}");
            }
        }

        public static void Post()
        {
            var requisicao = new RestRequest("/posts", Method.POST);

            var corpo = MontarPost();

            requisicao.AddBody(corpo);

            var resposta = Cliente.Execute(requisicao);

            var post = JsonConvert.DeserializeObject<PostViewModel>(resposta.Content);

            Console.WriteLine($"Post código {post.Codigo} foi criado com sucesso!");
        }

        public static string MontarPost()
        {
            var post = new PostViewModel
            {
                CodigoUsuario = 1,
                Titulo = "Primeiro Post!",
                Corpo = "Essa é nossa primeiro requisição POST."
            };
            return JsonConvert.SerializeObject(post);
        }
    }
}
