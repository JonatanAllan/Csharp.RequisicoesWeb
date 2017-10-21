using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using Parte2.ServicosExternos;
using Recusos.Constants;
using Recusos.ViewModels;
using RestSharp;

namespace Parte2
{
    public class Program
    {
        private static readonly JsonPlaceholderServicosExternos ExemploServico = 
            new JsonPlaceholderServicosExternos(Urls.JsonPlaceholder);
        public static void Main(string[] args)
        {
            Get();

            GetMultiplo();

            Post();

            Put();

            Delete();

            Console.ReadKey();
        }

        public static void Get()
        {
            //Obtem uma única postagem
            var resposta = ExemploServico.ObterPostagem(1);

            if (resposta.StatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine("Falha na requisição");
                return;
            }
            RequisicaoCompleta(resposta.Conteudo);
        }

        public static void GetMultiplo()
        {
            //Obtem diversas postagem baseadas em parâmetros
            var parametros = new List<Parameter>
            {
                //Parâmetro ficara concatenado a url exemplo: /posts?userId=1
                ExemploServico.CriarParametro("userId",1)
            };
            var resposta = ExemploServico.ListarPostagens(parametros);

            if (resposta.StatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine("Falha na requisição");
                return;
            }

            foreach (var postagem in resposta.Conteudo)
            {
                Console.WriteLine($"Codigo: {postagem.Codigo}");
                Console.WriteLine($"CodigoUsuario: {postagem.CodigoUsuario}");
                Console.WriteLine($"Titulo: {postagem.Titulo}");
                Console.WriteLine($"Corpo: {postagem.Corpo}");
                Console.WriteLine("");
                Console.WriteLine("================================================");
                Console.WriteLine("");
            }
        }

        public static void Post()
        {
            var postagem = GerarPostagem();

            //Converte a postagem para formato Json.
            var postagemJson = JsonConvert.SerializeObject(postagem);

            //Retorna o mesmo objeto postado.
            var resposta = ExemploServico.RealizarPostagem(postagemJson);

            if (resposta.StatusCode != HttpStatusCode.Created)
            {
                Console.WriteLine("Falha na requisição");
                return;
            }

            RequisicaoCompleta(resposta.Conteudo);
        }

        public static void Put()
        {
            var postagem = GerarAtualizarPostagem();

            //Converte a postagem para formato Json.
            var postagemJson = JsonConvert.SerializeObject(postagem);

            var resposta = ExemploServico.AtualizarPostagem(1, postagemJson);

            if (resposta.StatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine("Falha na requisição");
                return;
            }

            RequisicaoCompleta(resposta.Conteudo);
        }

        public static void Delete()
        {
            //Remover Postagem
            var resposta = ExemploServico.RemoverPostagem(1);

            if (resposta.StatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine("Falha na requisição");
                return;
            }
            Console.WriteLine("Postagem removida com sucesso!");
        }

        private static PostViewModel GerarPostagem()
        {
            return new PostViewModel
            {
                Codigo = 1,
                CodigoUsuario = 1,
                Titulo = "Pensador Profundo",
                Corpo = "42 é a resposta para a vida o universo e tudo mais."
            };
        }

        private static PostViewModel GerarAtualizarPostagem()
        {
            return new PostViewModel
            {
                Codigo = 1,
                CodigoUsuario = 1,
                Titulo = "Zaphod Beeblebrox",
                Corpo = "O efeito de beber uma Dinamite Pangaláctica é como ter seu cérebro " +
                        "esmagado por uma fatia de limão colocada em volta de uma grande barra de ouro."
            };
        }

        private static void RequisicaoCompleta(PostViewModel postagem)
        {
            Console.WriteLine("Requisiçao feita com sucesso!");
            Console.WriteLine("=======================>RESPOSTA<======================");
            Console.WriteLine($"Codigo: {postagem.Codigo}");
            Console.WriteLine($"CodigoUsuario: {postagem.CodigoUsuario}");
            Console.WriteLine($"Titulo: {postagem.Titulo}");
            Console.WriteLine($"Corpo: {postagem.Corpo}");
            Console.WriteLine("=============================================");
        }
    }
}
