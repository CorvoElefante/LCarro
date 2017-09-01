using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Carro.ViewModels.Relatorios;


namespace Carro.Pages.Relatorios
{
    public partial class RelatorioFinalVendaValorVendidoResultadoPage : ContentPage
    {
        public RelatorioFinalVendaValorVendidoResultadoPage(RelatorioFinalVendaValorVendidoSelecaoViewModel.DataCompleta data)
        {
            BindingContext = new RelatorioFinalVendaValorVendidoResultadoViewModel(Navigation, data);
            InitializeComponent();
        }
    }
}