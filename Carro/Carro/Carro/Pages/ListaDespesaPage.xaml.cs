using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Carro.ViewModels;

namespace Carro.Pages
{
    public partial class ListaDespesaPage : ContentPage
    {
        public ListaDespesaPage()
        {
            BindingContext = new DespesaViewModel(Navigation);
            InitializeComponent();
        }
    }
}
