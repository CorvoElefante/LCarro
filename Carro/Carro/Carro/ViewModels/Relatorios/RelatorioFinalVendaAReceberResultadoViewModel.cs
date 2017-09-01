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
    public class RelatorioFinalVendaAReceberResultadoViewModel : BaseViewModel
    {
        public RelatorioFinalVendaAReceberResultadoViewModel(INavigation navigation) : base(navigation)
        {
            ExecuteValorVendasAReceberCommand();
        }

        decimal _vendasAReceber = 0;
        public decimal vendasAReceber
        {
            get
            {
                return _vendasAReceber;
            }
            set
            {
                _vendasAReceber = value;
                SetPropertyChanged(nameof(vendasAReceber));
            }
        }

        Command _ValorVendasAReceberCommand;
        public Command ValorVendasAReceberCommand
        {
            get { return _ValorVendasAReceberCommand ?? (_ValorVendasAReceberCommand = new Command(() => ExecuteValorVendasAReceberCommand())); }
        }

        void ExecuteValorVendasAReceberCommand()
        {

            var sqlite = DependencyService.Get<ISQLite>();
            using (var scope = new TransactionScope(sqlite))
            {
                vendasAReceber = new DataService(sqlite).RelatorioFinalVendaQuantidadeAReceber();
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
                await Navigation.PushAsync(new RelatorioFinalVendaAReceberResultadoHelpPage());
                IsBusy = false;
            }
        }
    }
}
