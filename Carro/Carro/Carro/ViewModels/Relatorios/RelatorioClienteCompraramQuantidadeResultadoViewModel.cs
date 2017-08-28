using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Carro.Models;
using System.Collections.Generic;
using Carro.Repositories;
using Carro.Services;
using System.Threading.Tasks;
using Carro.Pages.Relatorios;


namespace Carro.ViewModels.Relatorios
{
    public class RelatorioClienteCompraramQuantidadeResultadoViewModel : BaseViewModel
    {
        public RelatorioClienteCompraramQuantidadeResultadoViewModel(INavigation navigation, RelatorioClienteCompraramQuantidadeSelecaoViewModel.DataCompleta dataCompleta) : base(navigation)
        {
            dataInicial = dataCompleta.DataInicio;
            dataFinal = dataCompleta.DataFinal;
            ExecuteListaClientesCompraramQuantidadeCommand();
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

        Command _ListaClientesCompraramQuantidadeCommand;
        public Command ListaClientesCompraramQuantidadeCommand
        {
            get { return _ListaClientesCompraramQuantidadeCommand ?? (_ListaClientesCompraramQuantidadeCommand = new Command(() => ExecuteListaClientesCompraramQuantidadeCommand())); }
        }

        void ExecuteListaClientesCompraramQuantidadeCommand()
        {

            var sqlite = DependencyService.Get<ISQLite>();
            using (var scope = new TransactionScope(sqlite))
            {
                ClientesCompra = new ObservableCollection<OrdemVenda>(
                    new DataService(sqlite).RelatorioClientesCompraramQuantidade(dataInicial, dataFinal)
                );
                scope.Complete();
            }
        }
    } 
}
