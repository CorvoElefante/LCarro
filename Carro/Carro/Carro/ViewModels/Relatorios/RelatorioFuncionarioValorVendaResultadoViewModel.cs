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
    public class RelatorioFuncionarioValorVendaResultadoViewModel : BaseViewModel
    {
        public RelatorioFuncionarioValorVendaResultadoViewModel(INavigation navigation, RelatorioFuncionarioValorVendaSelecaoViewModel.DataCompleta dataCompleta) : base(navigation)
        {
            dataInicial = dataCompleta.DataInicio;
            dataFinal = dataCompleta.DataFinal;
            ExecuteListaFuncionariosVendaValorCommand();
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

        ObservableCollection<FuncionarioServico> _FuncionariosVendaValor = new ObservableCollection<FuncionarioServico>();
        public ObservableCollection<FuncionarioServico> FuncionariosVendaValor
        {
            get
            {
                return _FuncionariosVendaValor;
            }
            set
            {
                _FuncionariosVendaValor = value;
                SetPropertyChanged(nameof(FuncionariosVendaValor));
            }
        }

        Command _ListaFuncionariosVendaValorCommand;
        public Command ListaFuncionariosVendaValorCommand
        {
            get { return _ListaFuncionariosVendaValorCommand ?? (_ListaFuncionariosVendaValorCommand = new Command(() => ExecuteListaFuncionariosVendaValorCommand())); }
        }

        void ExecuteListaFuncionariosVendaValorCommand()
        {

            var sqlite = DependencyService.Get<ISQLite>();
            using (var scope = new TransactionScope(sqlite))
            {
                FuncionariosVendaValor = new ObservableCollection<FuncionarioServico>(
                    new DataService(sqlite).RelatorioFuncionarioVendaValor(dataInicial, dataFinal)
                );
                scope.Complete();
            }
        }

    }
}
