using ApiPostagens.Models;
using Newtonsoft.Json;

namespace ApiPostagens.Services
{
    internal static class PostagensServiceHelpers
    {
        public static async Task<List<Postagem>?> GetPostagems(object sender, EventArgs e)
        {
            Postagem minhaPostagem = new Postagem();

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
                return null;
        }
    }
}