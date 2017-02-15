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
    public class ProdutoViewModel : BaseViewModel
    {

        public ProdutoViewModel(INavigation navigation) : base(navigation)
        {

            var sqlite = DependencyService.Get<ISQLite>();
            using (var scope = new TransactionScope(sqlite))
            {
                Produtos = new ObservableCollection<Produto>(
                    new DataService(sqlite).GetProdutos()
                );
                scope.Complete();
            }

        }
        ObservableCollection<Produto> _Produtos;
        public ObservableCollection<Produto> Produtos
        {
            get
            {
                return _Produtos;
            }
            set
            {
                _Produtos = value;
                SetPropertyChanged(nameof(Produtos));
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

        string _marcaEntry = string.Empty;
        public string marcaEntry
        {
            get
            {
                return _marcaEntry;
            }
            set
            {
                _marcaEntry = value;
                SetPropertyChanged(nameof(marcaEntry));
            }
        }

        string _descricaoEntry = string.Empty;
        public string descricaoEntry
        {
            get
            {
                return _descricaoEntry;
            }
            set
            {
                _descricaoEntry = value;
                SetPropertyChanged(nameof(descricaoEntry));
            }
        }

        string _localEntry = string.Empty;
        public string localEntry
        {
            get
            {
                return _localEntry;
            }
            set
            {
                _localEntry = value;
                SetPropertyChanged(nameof(localEntry));
            }
        }

        Command _SalvarProdutoCommand;
        public Command SalvarProdutoCommand
        {
            get { return _SalvarProdutoCommand ?? (_SalvarProdutoCommand = new Command(async () => await ExecuteSalvarProdutoCommand())); }
        }

        async Task ExecuteSalvarProdutoCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;

                var sqlite = DependencyService.Get<ISQLite>();
                using (var scope = new TransactionScope(sqlite))
                {
                    var service = new DataService(sqlite);

                    service.SaveProduto(new Produto { Nome = nomeEntry, Marca = marcaEntry, Descricao = descricaoEntry, Local = localEntry});
                    scope.Complete();
                }

                using (var scope = new TransactionScope(sqlite))
                {
                    Produtos = new ObservableCollection<Produto>(
                        new DataService(sqlite).GetProdutos()
                    );
                    scope.Complete();
                }
                IsBusy = false;
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
                Produtos = new ObservableCollection<Produto>(new DataService(sqlite).FindProdutoByNome(_Search));
            }
        }

        Command _AddProdutoCommand;
        public Command AddProdutoCommand
        {
            get { return _AddProdutoCommand ?? (_AddProdutoCommand = new Command(async () => await ExecuteAddProdutoCommand())); }
        }

        async Task ExecuteAddProdutoCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new CadastroClientePage());
                IsBusy = false;
            }
        }

    }
}
