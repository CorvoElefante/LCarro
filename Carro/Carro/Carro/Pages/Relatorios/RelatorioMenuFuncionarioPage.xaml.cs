using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Carro.ViewModels.Relatorios;

namespace Carro.Pages.Relatorios
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
