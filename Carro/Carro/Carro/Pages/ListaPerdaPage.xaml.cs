using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Carro.ViewModels;

namespace Carro.Pages
{
    public partial class ListaPerdaPage : ContentPage
    {
        public ListaPerdaPage()
        {
            BindingContext = new PerdaViewModel(Navigation);
            InitializeComponent();
        }
    }
}
