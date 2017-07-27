using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Carro.ViewModels.Relatorios;

namespace Carro.Pages.Relatorios
{
    public partial class RelatorioMenuPerdaPage : ContentPage
    {
        public RelatorioMenuPerdaPage()
        {
            BindingContext = new RelatorioMenuPerdaViewModel(Navigation);
            InitializeComponent();
        }
    }
}
