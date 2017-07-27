using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Carro.ViewModels.Relatorios;


namespace Carro.Pages.Relatorios
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
