using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Carro.Models;
using System.Collections.Generic;
using Carro.Repositories;
using Carro.Services;
using System.Threading.Tasks;
using Carro.Pages;
using Carro.Pages.Help;

namespace Carro.ViewModels
{
    public class ListaProdutoViewModel : BaseViewModel
    {

        public ListaProdutoViewModel(INavigation navigation) : base(navigation)
        {

            ExecuteAtualizaProdutoCommand();

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
                await Navigation.PushAsync(new CadastroProdutoPage());
                IsBusy = false;
            }
        }

        Command _EditarProdutoCommand;
        public Command EditarProdutoCommand
        {
            get { return _EditarProdutoCommand ?? (_EditarProdutoCommand = new Command<Produto>(async (qq) => await ExecuteEditarProdutoCommand(qq))); }
        }

        async Task ExecuteEditarProdutoCommand(Produto value)
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new EditarProdutoPage(value));
                IsBusy = false;
            }
        }

        Command _AtualizaProdutoCommand;
        public Command AtualizaProdutoCommand
        {
            get { return _AtualizaProdutoCommand ?? (_AtualizaProdutoCommand = new Command(() => ExecuteAtualizaProdutoCommand())); }
        }

        void ExecuteAtualizaProdutoCommand()
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

        Command _HelpCommand;
        public Command HelpCommand
        {
            get { return _HelpCommand ?? (_HelpCommand = new Command(async () => await ExecuteHelpCommand())); }
        }

        async Task ExecuteHelpCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new ListaProdutoHelpPage());
                IsBusy = false;
            }
        }
    }
}
