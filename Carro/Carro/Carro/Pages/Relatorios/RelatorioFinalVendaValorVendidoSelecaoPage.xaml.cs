using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Carro.ViewModels.Relatorios;

namespace Carro.Pages.Relatorios
{
    public partial class RelatorioFinalVendaValorVendidoSelecaoPage : ContentPage
    {
        public RelatorioFinalVendaValorVendidoSelecaoPage()
        {
            BindingContext = new RelatorioFinalVendaValorVendidoSelecaoViewModel(Navigation);
            InitializeComponent();
        }
    }
}