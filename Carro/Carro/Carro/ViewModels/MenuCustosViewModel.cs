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

            Command _MenuPerdaCommand;
            public Command MenuPerdaCommand
            {
                get { return _MenuPerdaCommand ?? (_MenuPerdaCommand = new Command(async () => await ExecuteMenuPerdaCommand())); }
            }

            Command _MenuDespesaCommand;
            public Command MenuDespesaCommand
            {
                get { return _MenuDespesaCommand ?? (_MenuDespesaCommand = new Command(async () => await ExecuteMenuDespesaCommand())); }
            }

            async Task ExecuteMenuPerdaCommand()
            {
                if (!IsBusy)
                {
                    IsBusy = true;
                    await Navigation.PushAsync(new ListaPerdaPage());
                    IsBusy = false;
                }
            }

            async Task ExecuteMenuDespesaCommand()
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
