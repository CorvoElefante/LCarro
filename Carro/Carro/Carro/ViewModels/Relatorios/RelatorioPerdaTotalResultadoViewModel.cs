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
    public class RelatorioPerdaTotalResultadoViewModel : BaseViewModel
    {

        public RelatorioPerdaTotalResultadoViewModel(INavigation navigation, RelatorioPerdaTotalSelecaoPageViewModel.DataCompleta dataCompleta) : base(navigation)
        {
            dataInicial = dataCompleta.DataInicio;
            dataFinal = dataCompleta.DataFinal;
            ExecuteListaPerdasCommand();
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

        decimal _ValorTotalPerdas = 0;
        public decimal ValorTotalPerdas
        {
            get
            {
                return _ValorTotalPerdas;
            }
            set
            {
                _ValorTotalPerdas = value;
                SetPropertyChanged(nameof(ValorTotalPerdas));
            }
        }


        Command _ListaPerdasCommand;
        public Command ListaPerdasCommand
        {
            get { return _ListaPerdasCommand ?? (_ListaPerdasCommand = new Command(() => ExecuteListaPerdasCommand())); }
        }

        void ExecuteListaPerdasCommand()
        {

            var sqlite = DependencyService.Get<ISQLite>();
            using (var scope = new TransactionScope(sqlite))
            {
                ValorTotalPerdas = new DataService(sqlite).RelatorioPerdas(dataInicial, dataFinal);
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
                await Navigation.PushAsync(new RelatorioPerdaTotalResultadoHelpPage());
                IsBusy = false;
            }
        }
    }
}
