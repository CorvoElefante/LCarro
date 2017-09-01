using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Carro.ViewModels.Relatorios;

namespace Carro.Pages.Relatorios
{
    public partial class RelatorioMenuFinalVendaPage : ContentPage
    {
        public RelatorioMenuFinalVendaPage()
        {
            BindingContext = new RelatorioMenuFinalVendaViewModel(Navigation);
            InitializeComponent();
        }
    }
}