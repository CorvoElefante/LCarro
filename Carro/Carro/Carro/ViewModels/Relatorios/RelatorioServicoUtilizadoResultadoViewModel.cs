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
    public class RelatorioServicoUtilizadoResultadoViewModel : BaseViewModel
    {

        public RelatorioServicoUtilizadoResultadoViewModel(INavigation navigation, RelatorioServicoUtilizadoSelecaoViewModel.DataCompleta dataCompleta) : base(navigation)
        {
            dataInicial = dataCompleta.DataInicio;
            dataFinal = dataCompleta.DataFinal;
            ExecuteListaServicosMaisVendidosCommand();
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

        ObservableCollection<OrdemVendaServico> _Servicos = new ObservableCollection<OrdemVendaServico>();
        public ObservableCollection<OrdemVendaServico> Servicos
        {
            get
            {
                return _Servicos;
            }
            set
            {
                _Servicos = value;
                SetPropertyChanged(nameof(Servicos));
            }
        }

        Command _ListaServicosMaisVendidosCommand;
        public Command ListaServicosMaisVendidosCommand
        {
            get { return _ListaServicosMaisVendidosCommand ?? (_ListaServicosMaisVendidosCommand = new Command(() => ExecuteListaServicosMaisVendidosCommand())); }
        }

        void ExecuteListaServicosMaisVendidosCommand()
        {

            var sqlite = DependencyService.Get<ISQLite>();
            using (var scope = new TransactionScope(sqlite))
            {
                Servicos = new ObservableCollection<OrdemVendaServico>(
                    new DataService(sqlite).RelatorioServicosMaisVendidos(dataInicial, dataFinal)
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
                await Navigation.PushAsync(new RelatorioServicoUtilizadoResultadoHelpPage());
                IsBusy = false;
            }
        }
    }
}
