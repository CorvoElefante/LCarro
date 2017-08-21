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
    class LoginViewModel : BaseViewModel
    {
        public LoginViewModel(INavigation navigation) : base(navigation)
        {

        }

        Command _MenuCommand;
        public Command MenuCommand
        {
            get { return _MenuCommand ?? (_MenuCommand = new Command(async () => await ExecuteMenuCommand())); }
        }

        async Task ExecuteMenuCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new MenuPage());
                IsBusy = false;
            }
        }
    }
}
