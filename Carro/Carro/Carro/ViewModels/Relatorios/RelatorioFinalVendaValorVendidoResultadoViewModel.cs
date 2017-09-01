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
    public class RelatorioFinalVendaValorVendidoResultadoViewModel : BaseViewModel
    {
        public RelatorioFinalVendaValorVendidoResultadoViewModel(INavigation navigation, RelatorioFinalVendaValorVendidoSelecaoViewModel.DataCompleta dataCompleta) : base(navigation)
        {
            dataInicial = dataCompleta.DataInicio;
            dataFinal = dataCompleta.DataFinal;
            ExecuteValorVendidoCommand();
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

        decimal _valorVendido = 0;
        public decimal valorVendido
        {
            get
            {
                return _valorVendido;
            }
            set
            {
                _valorVendido = value;
                SetPropertyChanged(nameof(valorVendido));
            }
        }

        int _quantidadeVendas= 0;
        public int quantidadeVendas
        {
            get
            {
                return _quantidadeVendas;
            }
            set
            {
                _quantidadeVendas = value;
                SetPropertyChanged(nameof(quantidadeVendas));
            }
        }

        Command _ValorVendidoCommand;
        public Command ValorVendidoCommand
        {
            get { return _ValorVendidoCommand ?? (_ValorVendidoCommand = new Command(() => ExecuteValorVendidoCommand())); }
        }

        void ExecuteValorVendidoCommand()
        {

            var sqlite = DependencyService.Get<ISQLite>();
            using (var scope = new TransactionScope(sqlite))
            {
                valorVendido = new DataService(sqlite).RelatorioFinalVendaValorVendido(dataInicial, dataFinal);
                scope.Complete();
            }

            using (var scope = new TransactionScope(sqlite))
            {
                quantidadeVendas = new DataService(sqlite).RelatorioFinalVendaQuantidadeVendida(dataInicial, dataFinal);
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
                await Navigation.PushAsync(new RelatorioFinalVendaValorVendidoResultadoHelpPage());
                IsBusy = false;
            }
        }
    }
}
