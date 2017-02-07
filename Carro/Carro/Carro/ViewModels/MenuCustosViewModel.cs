using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Carro.Models;
using System.Collections.Generic;
using Carro.Repositories;
using Carro.Services;
using System.Threading.Tasks;
using Carro.Pages;


namespace Carro.ViewModels
{
    class MenuCustosViewModel : BaseViewModel
    {
            public MenuCustosViewModel(INavigation navigation) : base(navigation)
            {
            }

            Command _MenuCustosPerdaCommand;
            public Command MenuVendaCommand
            {
                get { return _MenuCustosPerdaCommand ?? (_MenuCustosPerdaCommand = new Command(async () => await ExecuteMenuCustosPerdaCommand())); }
            }

            async Task ExecuteMenuCustosPerdaCommand()
            {
                if (!IsBusy)
                {
                    IsBusy = true;
                    await Navigation.PushAsync(new ListaPerdaPage());
                    IsBusy = false;
                }
            }

            Command _MenuCustosDespesaCommand;
            public Command MenuCustosDespesaCommand
            {
                get { return _MenuCustosDespesaCommand ?? (_MenuCustosDespesaCommand = new Command(async () => await ExecuteMenuOrdemCommand())); }
            }

            async Task ExecuteMenuOrdemCommand()
            {
                if (!IsBusy)
                {
                    IsBusy = true;
                    await Navigation.PushAsync(new ListaDespesaPage());
                    IsBusy = false;
                }
            }
    }
}
