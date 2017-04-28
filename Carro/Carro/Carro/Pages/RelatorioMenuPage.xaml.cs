using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Carro.ViewModels;

namespace Carro.Pages
{
    public partial class RelatorioMenuPage : ContentPage
    {
        public RelatorioMenuPage()
        {
            BindingContext = new RelatorioMenuViewModel(Navigation);
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
