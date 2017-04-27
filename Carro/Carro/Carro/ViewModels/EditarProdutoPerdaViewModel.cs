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
        public EditarProdutoPerdaViewModel(INavigation navigation, int estoqueProduto, string nomeProduto) : base(navigation)
        {
            var sqlite = DependencyService.Get<ISQLite>();

            produto = nomeProduto;
            quantidadeEstoque = estoqueProduto;

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
    }
}
