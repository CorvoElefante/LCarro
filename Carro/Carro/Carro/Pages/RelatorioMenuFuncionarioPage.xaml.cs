using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Carro.ViewModels;

namespace Carro.Pages
{
    public partial class RelatorioMenuFuncionarioPage : ContentPage
    {
        public RelatorioMenuFuncionarioPage()
        {
            BindingContext = new RelatorioMenuFuncionarioViewModel(Navigation);
            InitializeComponent();
        }
    }
}
