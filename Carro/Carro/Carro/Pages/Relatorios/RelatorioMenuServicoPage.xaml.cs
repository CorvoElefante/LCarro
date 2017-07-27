using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Carro.ViewModels.Relatorios;

namespace Carro.Pages.Relatorios
{
    public partial class RelatorioMenuServicoPage : ContentPage
    {
        public RelatorioMenuServicoPage()
        {
            BindingContext = new RelatorioMenuServicoViewModel(Navigation);
            InitializeComponent();
        }
    }
}
