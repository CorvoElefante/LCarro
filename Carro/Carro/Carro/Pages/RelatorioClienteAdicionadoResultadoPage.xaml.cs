using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Carro.ViewModels;

namespace Carro.Pages
{
    public partial class RelatorioClienteAdicionadoResultadoPage : ContentPage
    {
        public RelatorioClienteAdicionadoResultadoPage(RelatorioClienteAdicionadoSelecaoViewModel.DataCompleta data)
        {
            BindingContext = new RelatorioClienteAdicionadoResultadoViewModel(Navigation, data);
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
