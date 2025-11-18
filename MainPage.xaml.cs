using ApiPostagens.Models;
using Newtonsoft.Json;

namespace ApiPostagens
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        async private void BuscarBtn_Clicked(object sender, EventArgs e)
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
                TitleLbl.Text = postagens[0].Title;
                UserIdLbl.Text = Convert.ToString(postagens[0].UserId);
                IdLbl.Text = Convert.ToString(postagens[0].Id);
                BodyLbl.Text = postagens[0].Body;

            }
        }
    }

}
