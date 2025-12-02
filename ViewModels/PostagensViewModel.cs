using ApiPostagens.Models;
using ApiPostagens.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ApiPostagens.ViewModels
{
    public partial class PostagensViewModel : ObservableObject
    {
        [ObservableProperty]
        public int userId;
        [ObservableProperty]
        public int id;
        [ObservableProperty]
        public string title;
        [ObservableProperty]
        public string body;
        public ICommand CarregarPostagensCommand => new Command(async () => CarregarPostagens());

        public async void CarregarPostagens()
        {
            List<Postagem> postagens = new List<Postagem>();

            postagens = await new PostagensService().GetPostagens();
            id = postagens[0].id;
            title = postagens[0].title;
            body = postagens[0].body;
        }
    }
}
