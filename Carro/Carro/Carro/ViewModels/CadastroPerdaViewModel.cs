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
    public class CadastroPerdaViewModel : BaseViewModel
    {

        public CadastroPerdaViewModel(INavigation navigation) : base(navigation)
        {

            var sqlite = DependencyService.Get<ISQLite>();

        }

        public class ListaProdutoPerda
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

        string _nomeEntry = string.Empty;
        public string nomeEntry
        {
            get
            {
                return _nomeEntry;
            }
            set
            {
                _nomeEntry = value;
                SetPropertyChanged(nameof(nomeEntry));
            }
        }

        bool _nomeEntryInvalido = true;
        public bool nomeEntryInvalido
        {
            get
            {
                return _nomeEntryInvalido;
            }
            set
            {
                _nomeEntryInvalido = value;
                SetPropertyChanged(nameof(nomeEntryInvalido));
            }
        }

        string _justificativaEntry = string.Empty;
        public string justificativaEntry
        {
            get
            {
                return _justificativaEntry;
            }
            set
            {
                _justificativaEntry = value;
                SetPropertyChanged(nameof(justificativaEntry));
            }
        }

        Command _ListaProdutoCommand;
        public Command ListaProdutoCommand
        {
            get { return _ListaProdutoCommand ?? (_ListaProdutoCommand = new Command(async () => await ExecuteListaProdutoCommand())); }
        }

        async Task ExecuteListaProdutoCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new ListaProdutoPerdaPage());
                IsBusy = false;
            }
        }

        Command _SalvarPerdaCommand;
        public Command SalvarPerdaCommand
        {
            get { return _SalvarPerdaCommand ?? (_SalvarPerdaCommand = new Command(async () => await ExecuteSalvarPerdaCommand())); }
        }

        async Task ExecuteSalvarPerdaCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;

                var sqlite = DependencyService.Get<ISQLite>();
                using (var scope = new TransactionScope(sqlite))
                {
                    var service = new DataService(sqlite);

                    service.SavePerda(new Perda { Nome = nomeEntry, Justificativa = justificativaEntry });
                    scope.Complete();
                }

                IsBusy = false;
            }
        }
    }
}
