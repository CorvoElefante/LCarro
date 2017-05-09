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
    class RelatorioMenuViewModel : BaseViewModel
    {
        public RelatorioMenuViewModel(INavigation navigation) : base(navigation)
        {
        }

        Command _RelatorioMenuVendaCommand;
        public Command MRelatorioenuVendaCommand
        {
            get { return _RelatorioMenuVendaCommand ?? (_RelatorioMenuVendaCommand = new Command(async () => await ExecuteRelatorioMenuVendaCommand())); }
        }

        async Task ExecuteRelatorioMenuVendaCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                //await Navigation.PushAsync(new MenuPage());
                IsBusy = false;
            }
        }

        Command _RelatorioMenuServicoCommand;
        public Command RelatorioMenuServicoCommand
        {
            get { return _RelatorioMenuServicoCommand ?? (_RelatorioMenuServicoCommand = new Command(async () => await ExecuteRelatorioMenuServicoCommand())); }
        }

        async Task ExecuteRelatorioMenuServicoCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new RelatorioMenuServicoPage());
                IsBusy = false;
            }
        }

        Command _RelatorioMenuClienteCommand;
        public Command RelatorioMenuClienteCommand
        {
            get { return _RelatorioMenuClienteCommand ?? (_RelatorioMenuClienteCommand = new Command(async () => await ExecuteRelatorioMenuClienteCommand())); }
        }

        async Task ExecuteRelatorioMenuClienteCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new RelatorioMenuClientePage());
                IsBusy = false;
            }
        }

        Command _RelatorioMenuFuncionarioCommand;
        public Command RelatorioMenuFuncionarioCommand
        {
            get { return _RelatorioMenuFuncionarioCommand ?? (_RelatorioMenuFuncionarioCommand = new Command(async () => await ExecuteRelatorioMenuFuncionarioCommand())); }
        }

        async Task ExecuteRelatorioMenuFuncionarioCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new RelatorioMenuFuncionarioPage());
                IsBusy = false;
            }
        }

        Command _RelatorioMenuPerdaCommand;
        public Command RelatorioMenuPerdaCommand
        {
            get { return _RelatorioMenuPerdaCommand ?? (_RelatorioMenuPerdaCommand = new Command(async () => await ExecuteRelatorioMenuPerdaCommand())); }
        }

        async Task ExecuteRelatorioMenuPerdaCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new RelatorioMenuPerdaPage());
                IsBusy = false;
            }
        }

        Command _RelatorioMenuDespesaCommand;
        public Command RelatorioMenuDespesaCommand
        {
            get { return _RelatorioMenuDespesaCommand ?? (_RelatorioMenuDespesaCommand = new Command(async () => await ExecuteRelatorioMenuDespesaCommand())); }
        }

        async Task ExecuteRelatorioMenuDespesaCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new RelatorioMenuDespesaPage());
                IsBusy = false;
            }
        }

        Command _RelatorioMenuProdutoCommand;
        public Command RelatorioMenuProdutoCommand
        {
            get { return _RelatorioMenuProdutoCommand ?? (_RelatorioMenuProdutoCommand = new Command(async () => await ExecuteRelatorioMenuProdutoCommand())); }
        }

        async Task ExecuteRelatorioMenuProdutoCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new RelatorioMenuProdutoPage());
                IsBusy = false;
            }
        }
    }
}
