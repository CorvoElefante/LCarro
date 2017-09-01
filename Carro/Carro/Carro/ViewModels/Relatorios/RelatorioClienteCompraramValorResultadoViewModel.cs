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
    public class RelatorioClienteCompraramValorResultadoViewModel : BaseViewModel
    {

        public RelatorioClienteCompraramValorResultadoViewModel(INavigation navigation, RelatorioClienteCompraramValorSelecaoViewModel.DataCompleta dataCompleta) : base(navigation)
        {
            dataInicial = dataCompleta.DataInicio;
            dataFinal = dataCompleta.DataFinal;
            ExecuteListaClientesCompraramValorCommand();
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

        ObservableCollection<OrdemVenda> _ClientesCompra = new ObservableCollection<OrdemVenda>();
        public ObservableCollection<OrdemVenda> ClientesCompra
        {
            get
            {
                return _ClientesCompra;
            }
            set
            {
                _ClientesCompra = value;
                SetPropertyChanged(nameof(ClientesCompra));
            }
        }

        Command _ListaClientesCompraramValorCommand;
        public Command ListaClientesCompraramValorCommand
        {
            get { return _ListaClientesCompraramValorCommand ?? (_ListaClientesCompraramValorCommand = new Command(() => ExecuteListaClientesCompraramValorCommand())); }
        }

        void ExecuteListaClientesCompraramValorCommand()
        {

            var sqlite = DependencyService.Get<ISQLite>();
            using (var scope = new TransactionScope(sqlite))
            {
                ClientesCompra = new ObservableCollection<OrdemVenda>(
                    new DataService(sqlite).RelatorioClientesCompraramValor(dataInicial, dataFinal)
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
                await Navigation.PushAsync(new RelatorioClienteCompraramValorResultadoHelpPage());
                IsBusy = false;
            }
        }
    }
}
