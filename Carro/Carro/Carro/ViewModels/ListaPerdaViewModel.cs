using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Carro.Models;
using System.Collections.Generic;
using Carro.Repositories;
using Carro.Services;
using System.Threading.Tasks;
using Carro.Pages;

namespace Carro.ViewModels
{
    public class ListaPerdaViewModel : BaseViewModel
    {

        public ListaPerdaViewModel(INavigation navigation) : base(navigation)
        {

            var sqlite = DependencyService.Get<ISQLite>();

        }

        public class ListaProduto
        {
            public long? Id { get; set; }

            public string Nome { get; set; }

            public float Preco { get; set; }

            public int Quantidade { get; set; }

            public string Marca { get; set; }

            public string Descricao { get; set; }

            public string Local { get; set; }

            public int QuantidadePerdida { get; set; }
        }

        public class ListaProdutoPerda
        {
            public long? Id { get; set; }

            public string Nome { get; set; }

            public string Justificativa { get; set; }

            public ObservableCollection<ListaProduto> ListaProduto = new ObservableCollection<ListaProduto>();
        }

        ObservableCollection<ListaProdutoPerda> _ListaProdutoPerdas;
        public ObservableCollection<ListaProdutoPerda> ListaProdutoPerdas
        {
            get
            {
                return _ListaProdutoPerdas;
            }
            set
            {
                _ListaProdutoPerdas = value;
                SetPropertyChanged(nameof(ListaProdutoPerdas));
            }
        }

        string _Search = string.Empty;
        public string Search
        {
            get { return _Search; }
            set
            {
                _Search = value;
                var sqlite = DependencyService.Get<ISQLite>();
                //ListaProdutoPerdas = new ObservableCollection<ListaProdutoPerda>(new DataService(sqlite).FindPerdaByNome(_Search));
            }
        }

        Command _AddPerdaCommand;
        public Command AddPerdaCommand
        {
            get { return _AddPerdaCommand ?? (_AddPerdaCommand = new Command(async () => await ExecuteAddPerdaCommand())); }
        }

        async Task ExecuteAddPerdaCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new CadastroPerdaPage());
                IsBusy = false;
            }
        }

    }
}
