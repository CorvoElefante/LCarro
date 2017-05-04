using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Carro.ViewModels;

namespace Carro.Pages
{
    public partial class RelatorioClienteAdicionadoSelecaoPage : ContentPage
    {
        public RelatorioClienteAdicionadoSelecaoPage()
        {
            BindingContext = new RelatorioClienteAdicionadoSelecaoViewModel(Navigation);
            InitializeComponent();
        }
    }
}
