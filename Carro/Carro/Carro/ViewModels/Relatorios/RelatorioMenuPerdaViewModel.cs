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
    class RelatorioMenuPerdaViewModel : BaseViewModel
    {
        public RelatorioMenuPerdaViewModel(INavigation navigation) : base(navigation)
        {
        }

        Command _RelPerdaTotalCommand;
        public Command RelPerdaTotalCommand
        {
            get { return _RelPerdaTotalCommand ?? (_RelPerdaTotalCommand = new Command(async () => await ExecuteRelPerdaTotalCommand())); }
        }

        async Task ExecuteRelPerdaTotalCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new RelatorioPerdaTotalSelecaoPage());
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
                await Navigation.PushAsync(new RelatorioMenuPerdaHelpPage());
                IsBusy = false;
            }
        }
    }
}
