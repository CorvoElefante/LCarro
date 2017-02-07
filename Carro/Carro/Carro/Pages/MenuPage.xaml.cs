using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Carro.ViewModels;

namespace Carro.Pages
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            BindingContext = new MenuViewModel(Navigation);
            InitializeComponent();
        }
    }
}
