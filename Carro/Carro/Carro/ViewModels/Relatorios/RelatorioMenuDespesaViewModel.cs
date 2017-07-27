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
    class RelatorioMenuDespesaViewModel : BaseViewModel
    {
        public RelatorioMenuDespesaViewModel(INavigation navigation) : base(navigation)
        {
        }

        Command _RelDespesaCategoriaCommand;
        public Command RelDespesaCategoriaCommand
        {
            get { return _RelDespesaCategoriaCommand ?? (_RelDespesaCategoriaCommand = new Command(async () => await ExecuteRelDespesaCategoriaCommand())); }
        }

        async Task ExecuteRelDespesaCategoriaCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new RelatorioDespesaCategoriaSelecaoPage());
                IsBusy = false;
            }
        }
    }
}
