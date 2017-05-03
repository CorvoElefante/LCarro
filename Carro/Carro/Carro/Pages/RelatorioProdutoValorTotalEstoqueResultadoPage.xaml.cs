using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Carro.ViewModels;

namespace Carro.Pages
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
