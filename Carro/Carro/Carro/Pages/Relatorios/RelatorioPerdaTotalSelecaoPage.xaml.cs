using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Carro.ViewModels.Relatorios;


namespace Carro.Pages.Relatorios
{
    public partial class RelatorioPerdaTotalSelecaoPage : ContentPage
    {
        public RelatorioPerdaTotalSelecaoPage()
        {
            BindingContext = new RelatorioPerdaTotalSelecaoPageViewModel(Navigation);
            InitializeComponent();
        }
    }
}
