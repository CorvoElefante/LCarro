using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Carro.ViewModels;

namespace Carro.Pages
{
    public partial class OpcaoPage : ContentPage
    {
        public OpcaoPage()
        {
            BindingContext = new OpcaoViewModel(Navigation);
            InitializeComponent();
        }
    }
}
