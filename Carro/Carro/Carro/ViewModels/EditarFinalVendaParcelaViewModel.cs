using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Carro.Models;
using System.Collections.Generic;
using Carro.Repositories;
using Carro.Services;
using System.Threading.Tasks;
using Carro.Pages;
using Carro.Pages.Help;

namespace Carro.ViewModels
{
    public class EditarFinalVendaParcelaViewModel : BaseViewModel
    {

        public EditarFinalVendaParcelaViewModel(INavigation navigation) : base(navigation){

        }

        Command _PagarParcelasCommand;
        public Command PagarParcelasCommand
        {
            get { return _PagarParcelasCommand ?? (_PagarParcelasCommand = new Command(async () => await ExecutePagarParcelasCommand())); }
        }

        async Task ExecutePagarParcelasCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new EditarFinalVendaPagarParcelasPage());
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
                await Navigation.PushAsync(new EditarFinalVendaParcelaHelpPage());
                IsBusy = false;
            }
        }
    }
}
