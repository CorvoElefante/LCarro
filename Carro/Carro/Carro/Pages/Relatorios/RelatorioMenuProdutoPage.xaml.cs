using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Carro.ViewModels.Relatorios;

namespace Carro.Pages.Relatorios
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
