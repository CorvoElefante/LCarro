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

        Command _MenuPreVendaCommand;
        public Command MenuPreVendaCommand
        {
            get { return _MenuPreVendaCommand ?? (_MenuPreVendaCommand = new Command(async () => await ExecuteMenuPreVendaCommand())); }
        }

        async Task ExecuteMenuPreVendaCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new ListaVendaPage());
                IsBusy = false;
            }
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
                await Navigation.PushAsync(new ListaFinalVendaPage());
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

        Command _MenuProdutoCommand;
        public Command MenuProdutoCommand
        {
            get { return _MenuProdutoCommand ?? (_MenuProdutoCommand = new Command(async () => await ExecuteMenuProdutoCommand())); }
        }

        async Task ExecuteMenuProdutoCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new ListaProdutoPage());
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

        Command _MenuDespesaCommand;
        public Command MenuDespesaCommand
        {
            get { return _MenuDespesaCommand ?? (_MenuDespesaCommand = new Command(async () => await ExecuteMenuDespesaCommand())); }
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

        Command _MenuPerdaCommand;
        public Command MenuPerdaCommand
        {
            get { return _MenuPerdaCommand ?? (_MenuPerdaCommand = new Command(async () => await ExecuteMenuPerdaCommand())); }
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
                await Navigation.PushAsync(new RelatorioMenuPage());
                IsBusy = false;
            }
        }

        Command _MenuSobreCommand;
        public Command MenuSobreCommand
        {
            get { return _MenuSobreCommand ?? (_MenuSobreCommand = new Command(async () => await ExecuteMenuSobreCommand())); }
        }

        async Task ExecuteMenuSobreCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new SobrePage());
                IsBusy = false;
            }
        }
    }
}
