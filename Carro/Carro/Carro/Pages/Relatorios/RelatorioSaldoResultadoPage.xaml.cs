using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Carro.ViewModels.Relatorios;

namespace Carro.Pages.Relatorios
{

    public partial class RelatorioSaldoResultadoPage : ContentPage
    {
        public RelatorioSaldoResultadoPage(RelatorioSaldoSelecaoViewModel.DataCompleta data)
        {
            BindingContext = new RelatorioSaldoResultadoViewModel(Navigation, data);
            InitializeComponent();
        }
    }
}