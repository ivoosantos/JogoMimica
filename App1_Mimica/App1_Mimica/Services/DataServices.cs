using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using App1_Mimica.Armazenamento;
using App1_Mimica.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace App1_Mimica.Services
{
    public class DataServices
    {
        private static string EnderecoBase = "https://mimicapiivo.azurewebsites.net/api/v1.1/";
        static readonly HttpClient client = new HttpClient();
        public async static Task<List<ListarItens>> GetJogo()
        {
            var URL = EnderecoBase + "Palavras";
            //HttpClient requisicao = new HttpClient();
            //var resposta = await requisicao.GetAsync(URL);

            HttpResponseMessage response = await client.GetAsync(URL);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            //WebRequest requisicao = WebRequest.CreateHttp(URL);
            //requisicao.Credentials = CredentialCache.DefaultCredentials;
            //WebResponse resposta = requisicao.GetResponse();
            var lista = JsonConvert.DeserializeObject<List<ListarItens>>(responseBody);

            return lista;
            //if (resposta != null)
            //{
            //    //string conteudo = await resposta.Content.ReadAsStringAsync();
            //    //string conteudo = await (HttpWebResponse)resposta

            //    if (conteudo.Length > 0)
            //    {
            //        //JArray a = JArray.Parse(conteudo);
            //        var lista = JsonConvert.DeserializeObject<List<ListarItens>>(conteudo);
            //        return lista;
            //    }
            //    else
            //    {
            //        return null;
            //    }
            //}
            //else
            //{
            //    throw new Exception("Código de Erro HTTP: "/* + resposta.StatusCode*/);
            //}
            //return null;
        }
    }
}
