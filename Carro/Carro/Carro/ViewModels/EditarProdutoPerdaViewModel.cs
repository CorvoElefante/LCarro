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
    class EditarProdutoPerdaViewModel : BaseViewModel
    {
        public EditarProdutoPerdaViewModel(INavigation navigation, Produto value) : base(navigation)
        {
            var sqlite = DependencyService.Get<ISQLite>();

            produto = value.Nome;
            quantidadeEstoque = value.Quantidade;
            PerdaProdutos.IdProduto = value.Id;
            PerdaProdutos.Local = value.Local;
            PerdaProdutos.Marca = value.Marca;
            PerdaProdutos.Nome = value.Nome;
            PerdaProdutos.Descricao = value.Descricao;
            PerdaProdutos.Quantidade = value.Quantidade;

        }

        PerdaProduto _PerdaProdutos = new PerdaProduto();
        public PerdaProduto PerdaProdutos
        {
            get
            {
                return _PerdaProdutos;
            }
            set
            {
                _PerdaProdutos = value;
                SetPropertyChanged(nameof(PerdaProdutos));
            }
        }

        int _quantidadeEstoque = 0;
        public int quantidadeEstoque
        {
            get
            {
                return _quantidadeEstoque;
            }
            set
            {
                _quantidadeEstoque = value;
                SetPropertyChanged(nameof(quantidadeEstoque));
            }
        }

        int _quantidadePerdidaEntry = 0;
        public int quantidadePerdidaEntry
        {
            get
            {
                return _quantidadePerdidaEntry;
            }
            set
            {
                _quantidadePerdidaEntry = value;
                SetPropertyChanged(nameof(quantidadePerdidaEntry));
                PerdaProdutos.QuantidadePerdida = quantidadePerdidaEntry;
            }
        }

        string _produto = string.Empty;
        public string produto
        {
            get
            {
                return _produto;
            }
            set
            {
                _produto = value;
                SetPropertyChanged(nameof(produto));
            }
        }

        Command _SalvarProdutoPerdaCommand;
        public Command SalvarProdutoPerdaCommand
        {
            get { return _SalvarProdutoPerdaCommand ?? (_SalvarProdutoPerdaCommand = new Command(async () => await ExecuteSalvarProdutoPerdaCommand())); }
        }

        async Task ExecuteSalvarProdutoPerdaCommand()
        {

            if (!IsBusy)
            {
                IsBusy = true;
                MessagingCenter.Send<BaseViewModel, PerdaProduto>(this, "PerdaProdutos", PerdaProdutos);
                await Navigation.PopAsync();
                IsBusy = false;
            }
        }
    }
}
