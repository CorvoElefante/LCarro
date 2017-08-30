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
    public class RelatorioFuncionarioNumeroVendaResultadoViewModel : BaseViewModel
    {
        public RelatorioFuncionarioNumeroVendaResultadoViewModel(INavigation navigation, RelatorioFuncionarioNumeroVendaSelecaoViewModel.DataCompleta dataCompleta) : base(navigation)
        {
            dataInicial = dataCompleta.DataInicio;
            dataFinal = dataCompleta.DataFinal;
            ExecuteListaFuncionariosVendaQuantidadeCommand();
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

        ObservableCollection<OrdemVenda> _FuncionariosVendaQuantidade = new ObservableCollection<OrdemVenda>();
        public ObservableCollection<OrdemVenda> FuncionariosVendaQuantidade
        {
            get
            {
                return _FuncionariosVendaQuantidade;
            }
            set
            {
                _FuncionariosVendaQuantidade = value;
                SetPropertyChanged(nameof(FuncionariosVendaQuantidade));
            }
        }

        Command _ListaFuncionariosVendaQuantidadeCommand;
        public Command ListaFuncionariosVendaQuantidadeCommand
        {
            get { return _ListaFuncionariosVendaQuantidadeCommand ?? (_ListaFuncionariosVendaQuantidadeCommand = new Command(() => ExecuteListaFuncionariosVendaQuantidadeCommand())); }
        }

        void ExecuteListaFuncionariosVendaQuantidadeCommand()
        {

            var sqlite = DependencyService.Get<ISQLite>();
            using (var scope = new TransactionScope(sqlite))
            {
                FuncionariosVendaQuantidade = new ObservableCollection<OrdemVenda>(
                    new DataService(sqlite).RelatorioFuncionarioVendaQuantidade(dataInicial, dataFinal)
                );
                scope.Complete();
            }
        }
    }
}
