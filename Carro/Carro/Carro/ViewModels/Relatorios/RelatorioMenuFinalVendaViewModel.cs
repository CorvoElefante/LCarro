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

        Command _RelValorVendido;
        public Command RelValorVendido
        {
            get { return _RelValorVendido ?? (_RelValorVendido = new Command(async () => await ExecuteRelValorVendido())); }
        }

        async Task ExecuteRelValorVendido()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new RelatorioFinalVendaValorVendidoSelecaoPage());
                IsBusy = false;
            }
        }

        Command _RelVendasAtrasadas;
        public Command RelVendasAtrasadas
        {
            get { return _RelVendasAtrasadas ?? (_RelVendasAtrasadas = new Command(async () => await ExecuteRelVendasAtrasadas())); }
        }

        async Task ExecuteRelVendasAtrasadas()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new RelatorioFinalVendaEmAtrasoResultadoPage());
                IsBusy = false;
            }
        }
    }
}
