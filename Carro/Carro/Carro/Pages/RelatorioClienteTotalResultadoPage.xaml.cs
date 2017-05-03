using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Carro.ViewModels;

namespace Carro.Pages
{
    public partial class RelatorioClienteTotalResultadoPage : ContentPage
    {
        public RelatorioClienteTotalResultadoPage()
        {
            BindingContext = new RelatorioClienteTotalResultadoViewModel(Navigation);
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((RelatorioClienteTotalResultadoViewModel)BindingContext).TotalClientesCommand.Execute(null);
        }
    }
}
