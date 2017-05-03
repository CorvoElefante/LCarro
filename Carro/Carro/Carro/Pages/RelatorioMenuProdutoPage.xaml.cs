using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Carro.ViewModels;

namespace Carro.Pages
{
    public partial class RelatorioMenuProdutoPage : ContentPage
    {
        public RelatorioMenuProdutoPage()
        {
            BindingContext = new RelatorioMenuProdutoViewModel(Navigation);
            InitializeComponent();
        }
    }
}
