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
    public class RelatorioSaldoResultadoViewModel : BaseViewModel
    {
        public RelatorioSaldoResultadoViewModel(INavigation navigation, RelatorioSaldoSelecaoViewModel.DataCompleta dataCompleta) : base(navigation)
        {
            dataInicial = dataCompleta.DataInicio;
            dataFinal = dataCompleta.DataFinal;
            ExecuteSaldoCommand();
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

        decimal _vendasRecebidas = 0;
        public decimal vendasRecebidas
        {
            get
            {
                return _vendasRecebidas;
            }
            set
            {
                _vendasRecebidas = value;
                SetPropertyChanged(nameof(vendasRecebidas));
            }
        }

        decimal _despesas = 0;
        public decimal despesas
        {
            get
            {
                return _despesas;
            }
            set
            {
                _despesas = value;
                SetPropertyChanged(nameof(despesas));
            }
        }

        decimal _perdas = 0;
        public decimal perdas
        {
            get
            {
                return _perdas;
            }
            set
            {
                _perdas = value;
                SetPropertyChanged(nameof(perdas));
            }
        }

        decimal _saldo = 0;
        public decimal saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                _saldo = value;
                SetPropertyChanged(nameof(saldo));
            }
        }

        Command _SaldoCommand;
        public Command SaldoCommand
        {
            get { return _SaldoCommand ?? (_SaldoCommand = new Command(() => ExecuteSaldoCommand())); }
        }

        void ExecuteSaldoCommand()
        {

            var sqlite = DependencyService.Get<ISQLite>();
            using (var scope = new TransactionScope(sqlite))
            {
                vendasRecebidas = new DataService(sqlite).RelatorioSaldoVendasRecebidas(dataInicial, dataFinal);
                scope.Complete();
            }

            using (var scope = new TransactionScope(sqlite))
            {
                despesas = new DataService(sqlite).RelatorioSaldoDespesas(dataInicial, dataFinal);
                scope.Complete();
            }

            using (var scope = new TransactionScope(sqlite))
            {
                perdas = new DataService(sqlite).RelatorioSaldoPerdas(dataInicial, dataFinal);
                scope.Complete();
            }

            saldo = vendasRecebidas - despesas - perdas;

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
                await Navigation.PushAsync(new RelatorioSaldoResultadoHelpPage());
                IsBusy = false;
            }
        }
    }
}
