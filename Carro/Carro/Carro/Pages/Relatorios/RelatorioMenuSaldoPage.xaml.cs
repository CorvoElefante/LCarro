using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Carro.ViewModels.Relatorios;


namespace Carro.Pages.Relatorios
{
    public partial class RelatorioMenuSaldoPage : ContentPage
    {
        public RelatorioMenuSaldoPage()
        {
            BindingContext = new RelatorioMenuSaldoViewModel(Navigation);
            InitializeComponent();
        }
    }
}