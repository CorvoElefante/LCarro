using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Carro.ViewModels.Relatorios;

namespace Carro.Pages.Relatorios
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
