using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Carro.ViewModels.Relatorios;

namespace Carro.Pages.Relatorios
{
    public partial class RelatorioProdutoValorTotalEstoqueResultadoPage : ContentPage
    {
        public RelatorioProdutoValorTotalEstoqueResultadoPage()
        {
            BindingContext = new RelatorioProdutoValorTotalEstoqueResultadoViewModel(Navigation);
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((RelatorioProdutoValorTotalEstoqueResultadoViewModel)BindingContext).ValorTotalEstoqueCommand.Execute(null);
        }
    }
}
