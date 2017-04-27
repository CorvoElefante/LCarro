using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Carro.Models;
using System.Collections.Generic;
using Carro.Repositories;
using Carro.Services;
using System.Threading.Tasks;
using Carro.Pages;
using System.Linq;

namespace Carro.ViewModels
{
    public class CadastroPerdaViewModel : BaseViewModel
    {

        public CadastroPerdaViewModel(INavigation navigation) : base(navigation)
        {

            var sqlite = DependencyService.Get<ISQLite>();
            MessagingCenter.Subscribe<BaseViewModel, PerdaProduto>(this, "PerdaProdutos", (sender, value) =>
            {
                var lista = new PerdaProduto();
                lista.QuantidadePerdida = value.QuantidadePerdida;
                lista.IdProduto = value.Id;
                lista.Local = value.Local;
                lista.Marca = value.Marca;
                lista.Nome = value.Nome;
                lista.Preco = value.Preco;

                if (lista.QuantidadePerdida > 0)
                {
                    PerdaProdutos.Add(lista);
                }
            });
        }

        ObservableCollection<PerdaProduto> _PerdaProdutos = new ObservableCollection<PerdaProduto>();
        public ObservableCollection<PerdaProduto> PerdaProdutos
        {
            get
            {
                return _PerdaProdutos;
            }
            set
            {
                _PerdaProdutos = value;
                SetPropertyChanged(nameof(PerdaProdutos));
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
                if (nomeEntry != string.Empty)
                {
                    nomeEntryInvalido = false;
                }
                else
                {
                    nomeEntryInvalido = true;
                }
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

        Command _RemoveProdutoCommand;
        public Command RemoveProdutoCommand
        {
            get { return _RemoveProdutoCommand ?? (_RemoveProdutoCommand = new Command<PerdaProduto>(async (qq) => await ExecuteRemoveProdutoCommand(qq))); }
        }

        async Task ExecuteRemoveProdutoCommand(PerdaProduto qq)
        {
            if (!IsBusy)
            {
                IsBusy = true;
                PerdaProdutos.Remove(qq);
                IsBusy = false;
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
            if (nomeEntry != string.Empty)
            {
                if (!IsBusy)
                {
                    IsBusy = true;

                    var sqlite = DependencyService.Get<ISQLite>();
                    using (var scope = new TransactionScope(sqlite))
                    {
                        var service = new DataService(sqlite);
                        service.SavePerda(new Models.Perda { Nome = nomeEntry, Justificativa = justificativaEntry, PerdaProdutos = PerdaProdutos.ToList<PerdaProduto>() });
                        scope.Complete();
                    }
                    await Navigation.PopAsync();
                    IsBusy = false;
                }
            }
        }
    }
}
