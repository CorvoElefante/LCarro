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
    class RelatorioMenuProdutoViewModel : BaseViewModel
    {
        public RelatorioMenuProdutoViewModel(INavigation navigation) : base(navigation)
        {
        }

        Command _RelProdutoVendidoCommand;
        public Command RelProdutoVendidoCommand
        {
            get { return _RelProdutoVendidoCommand ?? (_RelProdutoVendidoCommand = new Command(async () => await ExecuteRelProdutoVendidoCommand())); }
        }

        async Task ExecuteRelProdutoVendidoCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new RelatorioProdutoMaisVendidoSelecaoPage());
                IsBusy = false;
            }
        }

        Command _RelProdutoSemEstoqueCommand;
        public Command RelProdutoSemEstoqueCommand
        {
            get { return _RelProdutoSemEstoqueCommand ?? (_RelProdutoSemEstoqueCommand = new Command(async () => await ExecuteRelProdutoSemEstoqueCommand())); }
        }

        async Task ExecuteRelProdutoSemEstoqueCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new RelatorioProdutoSemEstoqueResultadoPage());
                IsBusy = false;
            }
        }

        Command _RelProdutoValorTotalCommand;
        public Command RelProdutoValorTotalCommand
        {
            get { return _RelProdutoValorTotalCommand ?? (_RelProdutoValorTotalCommand = new Command(async () => await ExecuteRelProdutoValorTotalCommand())); }
        }

        async Task ExecuteRelProdutoValorTotalCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new RelatorioProdutoValorTotalEstoqueResultadoPage());
                IsBusy = false;
            }
        }
    }
}
