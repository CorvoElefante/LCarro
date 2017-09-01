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
    public class RelatorioMenuSaldoViewModel : BaseViewModel
    {
        public RelatorioMenuSaldoViewModel(INavigation navigation) : base(navigation)
        {
        }

        Command _RelSaldoCommand;
        public Command RelSaldoCommand
        {
            get { return _RelSaldoCommand ?? (_RelSaldoCommand = new Command(async () => await ExecuteRelSaldoCommand())); }
        }

        async Task ExecuteRelSaldoCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new RelatorioSaldoSelecaoPage());
                IsBusy = false;
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
                await Navigation.PushAsync(new RelatorioMenuSaldoHelpPage());
                IsBusy = false;
            }
        }
    }
}
