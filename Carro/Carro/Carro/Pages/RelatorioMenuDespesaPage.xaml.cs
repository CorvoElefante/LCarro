using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Carro.ViewModels;


namespace Carro.Pages
{
    public partial class RelatorioMenuDespesaPage : ContentPage
    {
        public RelatorioMenuDespesaPage()
        {
            BindingContext = new RelatorioMenuDespesaViewModel(Navigation);
            InitializeComponent();
        }
    }
}
