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
    public class CadastroVendaViewModel : BaseViewModel
    {
        public CadastroVendaViewModel(INavigation navigation) : base(navigation)
        {
        }

        Command _cadastroVendaProdutoCommand;
        public Command cadastroVendaProdutoCommand
        {
            get { return _cadastroVendaProdutoCommand ?? (_cadastroVendaProdutoCommand = new Command(async () => await ExecutecadastroVendaProdutoCommand())); }
        }

        async Task ExecutecadastroVendaProdutoCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new CadastroVendaProdutoPage());
                IsBusy = false;
            }
        }

        Command _cadastroVendaServicoCommand;
        public Command cadastroVendaServicoCommand
        {
            get { return _cadastroVendaServicoCommand ?? (_cadastroVendaServicoCommand = new Command(async () => await ExecutecadastroVendaServicoCommand())); }
        }

        async Task ExecutecadastroVendaServicoCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new CadastroVendaServicoPage());
                IsBusy = false;
            }
        }

        Command _cadastroVendaConclucaoCommand;
        public Command cadastroVendaConclucaoCommand
        {
            get { return _cadastroVendaConclucaoCommand ?? (_cadastroVendaConclucaoCommand = new Command(async () => await ExecutecadastroVendaConclucaoCommand())); }
        }

        async Task ExecutecadastroVendaConclucaoCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new CadastroVendaConclusaoPage());
                IsBusy = false;
            }
        }

        Command _SalvarVendaCommand;
        public Command SalvarVendaCommand
        {
            get { return _SalvarVendaCommand ?? (_SalvarVendaCommand = new Command(async () => await ExecuteSalvarVendaCommand())); }
        }

        async Task ExecuteSalvarVendaCommand()
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
