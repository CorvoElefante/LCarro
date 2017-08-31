using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Carro.ViewModels.Relatorios;


namespace Carro.Pages.Relatorios
{
    public partial class RelatorioFuncionarioValorVendaResultadoPage : ContentPage
    {
        public RelatorioFuncionarioValorVendaResultadoPage(RelatorioFuncionarioValorVendaSelecaoViewModel.DataCompleta data)
        {
            BindingContext = new RelatorioFuncionarioValorVendaResultadoViewModel(Navigation, data);
            InitializeComponent();
        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            if (e == null)
            {
                return; // has been set to null, do not 'process' tapped event 
            }
            ((ListView)sender).SelectedItem = null; // de-select the row
        }
    }
}
