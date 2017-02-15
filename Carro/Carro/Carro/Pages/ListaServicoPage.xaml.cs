using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Carro.ViewModels;

namespace Carro.Pages
{
    public partial class ListaServicoPage : ContentPage
    {
        public ListaServicoPage()
        {
            BindingContext = new ServicoViewModel(Navigation);
            InitializeComponent();
        }
    }
}
