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
    class RelatorioMenuServicoViewModel : BaseViewModel
    {
        public RelatorioMenuServicoViewModel(INavigation navigation) : base(navigation)
        {
        }

        Command _RelServicoUtilizadoCommand;
        public Command RelServicoUtilizadoCommand
        {
            get { return _RelServicoUtilizadoCommand ?? (_RelServicoUtilizadoCommand = new Command(async () => await ExecuteRelServicoUtilizadoCommand())); }
        }

        async Task ExecuteRelServicoUtilizadoCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new RelatorioServicoUtilizadoSelecaoPage());
                IsBusy = false;
            }
        }
    }
}
