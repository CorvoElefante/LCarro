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
    public class RelatorioClienteAdicionadoResultadoViewModel : BaseViewModel
    {

        public RelatorioClienteAdicionadoResultadoViewModel(INavigation navigation, RelatorioClienteAdicionadoSelecaoViewModel.DataCompleta dataCompleta) : base(navigation)
        {
            dataInicial = dataCompleta.DataInicio;
            dataFinal = dataCompleta.DataFinal;
            ExecuteListaClientesAdicionadosCommand();
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

        ObservableCollection<Pessoa> _Pessoas = new ObservableCollection<Pessoa>();
        public ObservableCollection<Pessoa> Pessoas
        {
            get
            {
                return _Pessoas;
            }
            set
            {
                _Pessoas = value;
                SetPropertyChanged(nameof(Pessoas));
            }
        }

        Command _ListaClientesAdicionadosCommand;
        public Command ListaClientesAdicionadosCommand
        {
            get { return _ListaClientesAdicionadosCommand ?? (_ListaClientesAdicionadosCommand = new Command(() => ExecuteListaClientesAdicionadosCommand())); }
        }

        void ExecuteListaClientesAdicionadosCommand()
        {

            var sqlite = DependencyService.Get<ISQLite>();
            using (var scope = new TransactionScope(sqlite))
            {
                Pessoas = new ObservableCollection<Pessoa>(
                    new DataService(sqlite).RelatorioClientesAdicionados(dataInicial, dataFinal)
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
                await Navigation.PushAsync(new RelatorioClienteAdicionadoResultadoHelpPage());
                IsBusy = false;
            }
        }

    }
}
