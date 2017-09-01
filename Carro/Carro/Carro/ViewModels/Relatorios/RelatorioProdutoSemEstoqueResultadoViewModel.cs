using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Carro.Models;
using System.Collections.Generic;
using Carro.Repositories;
using Carro.Services;
using System.Threading.Tasks;
using Carro.Pages.Relatorios;
using Carro.Pages.Help.RelatoriosHelp;

namespace Carro.ViewModels.Relatorios
{
    public class RelatorioProdutoSemEstoqueResultadoViewModel : BaseViewModel
    {

        public RelatorioProdutoSemEstoqueResultadoViewModel(INavigation navigation) : base(navigation)
        {

            ExecuteListaProdutoSemEstoqueCommand();

        }


        ObservableCollection<Produto> _Produtos = new ObservableCollection<Produto>();
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
                Produtos = new ObservableCollection<Produto>(new DataService(sqlite).RelatorioProdutoSemEstoque(_Search));
            }
        }

        Command _ListaProdutoSemEstoqueCommand;
        public Command ListaProdutoSemEstoqueCommand
        {
            get { return _ListaProdutoSemEstoqueCommand ?? (_ListaProdutoSemEstoqueCommand = new Command(() => ExecuteListaProdutoSemEstoqueCommand())); }
        }

        void ExecuteListaProdutoSemEstoqueCommand()
        {

            var sqlite = DependencyService.Get<ISQLite>();
            using (var scope = new TransactionScope(sqlite))
            {
                Produtos = new ObservableCollection<Produto>(
                    new DataService(sqlite).RelatorioProdutoSemEstoque("")
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
                await Navigation.PushAsync(new RelatorioProdutoSemEstoqueResultadoHelpPage());
                IsBusy = false;
            }
        }

    }
}
