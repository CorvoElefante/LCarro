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
    class RelatorioMenuFuncionarioViewModel : BaseViewModel
    {
        public RelatorioMenuFuncionarioViewModel(INavigation navigation) : base(navigation)
        {
        }

        Command _RelFuncionarioVendaCommand;
        public Command RelFuncionarioVendaCommand
        {
            get { return _RelFuncionarioVendaCommand ?? (_RelFuncionarioVendaCommand = new Command(async () => await ExecuteRelFuncionarioVendaCommand())); }
        }

        async Task ExecuteRelFuncionarioVendaCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new RelatorioFuncionarioNumeroVendaSelecaoPage());
                IsBusy = false;
            }
        }

        Command _RelFucionarioRendeCommand;
        public Command RelFucionarioRendeCommand
        {
            get { return _RelFucionarioRendeCommand ?? (_RelFucionarioRendeCommand = new Command(async () => await ExecuteRelFucionarioRendeCommand())); }
        }

        async Task ExecuteRelFucionarioRendeCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new RelatorioFuncionarioValorVendaSelecaoPage());
                IsBusy = false;
            }
        }
    }
}
