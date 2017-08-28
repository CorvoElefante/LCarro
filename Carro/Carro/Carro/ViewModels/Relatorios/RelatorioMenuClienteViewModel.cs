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
    class RelatorioMenuClienteViewModel : BaseViewModel
    {
        public RelatorioMenuClienteViewModel(INavigation navigation) : base(navigation)
        {
        }

        Command _RelClienteAniversarianteCommand;
        public Command RelClienteAniversarianteCommand
        {
            get { return _RelClienteAniversarianteCommand ?? (_RelClienteAniversarianteCommand = new Command(async () => await ExecuteRelClienteAniversarianteCommand())); }
        }

        async Task ExecuteRelClienteAniversarianteCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new RelatorioClienteAniversarianteDiaResultadoPage());
                IsBusy = false;
            }
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

        Command _RelClienteFrequenteCommand;
        public Command RelClienteFrequenteCommand
        {
            get { return _RelClienteFrequenteCommand ?? (_RelClienteFrequenteCommand = new Command(async () => await ExecuteRelClienteFrequenteCommand())); }
        }

        async Task ExecuteRelClienteFrequenteCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new RelatorioClienteCompraramQuantidadeSelecaoPage());
                IsBusy = false;
            }
        }

        Command _RelClienteValorCommand;
        public Command RelClienteValorCommand
        {
            get { return _RelClienteValorCommand ?? (_RelClienteValorCommand = new Command(async () => await ExecuteRelClienteValorCommand())); }
        }

        async Task ExecuteRelClienteValorCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new RelatorioClienteCompraramValorSelecaoPage());
                IsBusy = false;
            }
        }

        Command _RelTotalClienteCommand;
        public Command RelTotalClienteCommand
        {
            get { return _RelTotalClienteCommand ?? (_RelTotalClienteCommand = new Command(async () => await ExecuteRelTotalClienteCommand())); }
        }

        async Task ExecuteRelTotalClienteCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new RelatorioClienteTotalResultadoPage());
                IsBusy = false;
            }
        }
    }
}
