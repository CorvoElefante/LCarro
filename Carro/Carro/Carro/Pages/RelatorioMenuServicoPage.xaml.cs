using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Carro.ViewModels;

namespace Carro.Pages
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
