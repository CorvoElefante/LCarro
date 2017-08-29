using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Carro.ViewModels.Relatorios;


namespace Carro.Pages.Relatorios
{
    public partial class RelatorioProdutoMaisVendidoSelecaoPage : ContentPage
    {
        public RelatorioProdutoMaisVendidoSelecaoPage()
        {
            BindingContext = new RelatorioProdutoMaisVendidoSelecaoViewModel(Navigation);
            InitializeComponent();
        }
    }
}
