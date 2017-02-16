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
    class MenuViewModel : BaseViewModel
    {
        public MenuViewModel(INavigation navigation) : base(navigation)
        {
        }

        Command _MenuVendaCommand;
        public Command MenuVendaCommand
        {
            get { return _MenuVendaCommand ?? (_MenuVendaCommand = new Command(async () => await ExecuteMenuVendaCommand())); }
        }

        async Task ExecuteMenuVendaCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new HistoricoVendaPage());
                IsBusy = false;
            }
        }

        Command _MenuServicoCommand;
        public Command MenuServicoCommand
        {
            get { return _MenuServicoCommand ?? (_MenuServicoCommand = new Command(async () => await ExecuteMenuServicoCommand())); }
        }

        async Task ExecuteMenuServicoCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new ListaServicoPage());
                IsBusy = false;
            }
        }

        Command _MenuCustosCommand;
        public Command MenuCustosCommand
        {
            get { return _MenuCustosCommand ?? (_MenuCustosCommand = new Command(async () => await ExecuteMenuCustosCommand())); }
        }

        async Task ExecuteMenuCustosCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new MenuCustosPage());
                IsBusy = false;
            }
        }

        Command _MenuRelatoriosCommand;
        public Command MenuRelatoriosCommand
        {
            get { return _MenuRelatoriosCommand ?? (_MenuRelatoriosCommand = new Command(async () => await ExecuteMenuRelatoriosCommand())); }
        }

        async Task ExecuteMenuRelatoriosCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new HistoricoVendaPage());
                IsBusy = false;
            }
        }

        Command _MenuClientesCommand;
        public Command MenuClientesCommand
        {
            get { return _MenuClientesCommand ?? (_MenuClientesCommand = new Command(async () => await ExecuteMenuClientesCommand())); }
        }

        async Task ExecuteMenuClientesCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new ListaClientePage());
                IsBusy = false;
            }
        }

        Command _MenuFuncionarioCommand;
        public Command MenuFuncionarioCommand
        {
            get { return _MenuFuncionarioCommand ?? (_MenuFuncionarioCommand = new Command(async () => await ExecuteMenuFuncionarioCommand())); }
        }

        async Task ExecuteMenuFuncionarioCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new ListaFuncionarioPage());
                IsBusy = false;
            }
        }
    }
}
