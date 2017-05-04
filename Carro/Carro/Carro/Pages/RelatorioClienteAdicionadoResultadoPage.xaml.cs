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
    }
}
