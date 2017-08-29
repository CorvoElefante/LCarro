using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Carro.ViewModels.Relatorios;


namespace Carro.Pages.Relatorios
{
    public partial class RelatorioPerdaTotalResultadoPage : ContentPage
    {
        public RelatorioPerdaTotalResultadoPage(RelatorioPerdaTotalSelecaoPageViewModel.DataCompleta data)
        {
            BindingContext = new RelatorioPerdaTotalResultadoViewModel(Navigation, data);
            InitializeComponent();
        }
    }
}
