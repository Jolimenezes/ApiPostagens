using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Platform;
using Newtonsoft.Json;
using ApiPostagens.ViewModels;
using ApiPostagens.Models;

namespace ApiPostagens.Services
{
    public class PostagensService
    {
        public async Task<List<Postagem>> GetPostagens()
        {
            string URI = "https://jsonplaceholder.typicode.com/posts";

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage responseMessage = await httpClient.GetAsync(URI);

            List<Postagem> postagens = new List<Postagem>();

            if (responseMessage.IsSuccessStatusCode)
            {
                string conteudo = await responseMessage.Content.ReadAsStringAsync();
                postagens = JsonConvert.DeserializeObject<List<Postagem>>(conteudo);

                return postagens;
            }
            else 
            {
                return null;
            }
        }
    }
}
