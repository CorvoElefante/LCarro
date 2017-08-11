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
    public class EditarFinalVendaPagarParcelasViewModel : BaseViewModel
    {

        public EditarFinalVendaPagarParcelasViewModel(INavigation navigation, OrdemVendaParcela value) : base(navigation){

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
                await Navigation.PushAsync(new EditarFinalVendaPagarParcelasHelpPage());
                IsBusy = false;
            }
        }
    }
}
