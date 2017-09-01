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
    public class RelatorioProdutoMaisVendidoResultadoViewModel : BaseViewModel
    {
        public RelatorioProdutoMaisVendidoResultadoViewModel(INavigation navigation, RelatorioProdutoMaisVendidoSelecaoViewModel.DataCompleta dataCompleta) : base(navigation)
        {
            dataInicial = dataCompleta.DataInicio;
            dataFinal = dataCompleta.DataFinal;
            ExecuteListaProdutosMaisVendidosCommand();
        }

        DateTime _dataInicial = System.DateTime.Today;
        public DateTime dataInicial
        {
            get
            {
                return _dataInicial;
            }
            set
            {
                _dataInicial = value;
                SetPropertyChanged(nameof(dataInicial));
            }
        }

        DateTime _dataFinal = System.DateTime.Now;
        public DateTime dataFinal
        {
            get
            {
                return _dataFinal;
            }
            set
            {
                _dataFinal = value;
                SetPropertyChanged(nameof(dataFinal));
            }
        }

        ObservableCollection<OrdemVendaProduto> _Produtos = new ObservableCollection<OrdemVendaProduto>();
        public ObservableCollection<OrdemVendaProduto> Produtos
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

        Command _ListaProdutosMaisVendidosCommand;
        public Command ListaProdutosMaisVendidosCommand
        {
            get { return _ListaProdutosMaisVendidosCommand ?? (_ListaProdutosMaisVendidosCommand = new Command(() => ExecuteListaProdutosMaisVendidosCommand())); }
        }

        void ExecuteListaProdutosMaisVendidosCommand()
        {

            var sqlite = DependencyService.Get<ISQLite>();
            using (var scope = new TransactionScope(sqlite))
            {
                Produtos = new ObservableCollection<OrdemVendaProduto>(
                    new DataService(sqlite).RelatorioProdutosMaisVendidos(dataInicial, dataFinal)
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
                await Navigation.PushAsync(new RelatorioProdutoMaisVendidoResultadoHelpPage());
                IsBusy = false;
            }
        }
    }
}
