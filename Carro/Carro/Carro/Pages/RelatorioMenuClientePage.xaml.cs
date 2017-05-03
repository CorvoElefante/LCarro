using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Carro.ViewModels;

namespace Carro.Pages
{
    public partial class RelatorioMenuClientePage : ContentPage
    {
        public RelatorioMenuClientePage()
        {
            BindingContext = new RelatorioMenuClienteViewModel(Navigation);
            InitializeComponent();
        }
    }
}
