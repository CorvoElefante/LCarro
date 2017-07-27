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
    class RelatorioMenuPerdaViewModel : BaseViewModel
    {
        public RelatorioMenuPerdaViewModel(INavigation navigation) : base(navigation)
        {
        }

        Command _RelPerdaTotalCommand;
        public Command RelPerdaTotalCommand
        {
            get { return _RelPerdaTotalCommand ?? (_RelPerdaTotalCommand = new Command(async () => await ExecuteRelPerdaTotalCommand())); }
        }

        async Task ExecuteRelPerdaTotalCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new RelatorioPerdaTotalSelecaoPage());
                IsBusy = false;
            }
        }
    }
}
