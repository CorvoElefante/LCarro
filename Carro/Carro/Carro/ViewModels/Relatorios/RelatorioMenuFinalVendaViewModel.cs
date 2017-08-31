using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Carro.Models;
using System.Collections.Generic;
using Carro.Repositories;
using Carro.Services;
using System.Threading.Tasks;
using Carro.Pages.Relatorios;

namespace Carro.ViewModels.Relatorios
{
    public class RelatorioMenuFinalVendaViewModel : BaseViewModel
    {
        public RelatorioMenuFinalVendaViewModel(INavigation navigation) : base(navigation)
        {
        }

        Command _RelClienteAddCommand;
        public Command RelClienteAddCommand
        {
            get { return _RelClienteAddCommand ?? (_RelClienteAddCommand = new Command(async () => await ExecuteRelClienteAddCommand())); }
        }

        async Task ExecuteRelClienteAddCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new RelatorioClienteAdicionadoSelecaoPage());
                IsBusy = false;
            }
        }
    }
}
