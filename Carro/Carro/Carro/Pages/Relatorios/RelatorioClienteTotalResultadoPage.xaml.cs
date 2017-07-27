using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Carro.ViewModels.Relatorios;
namespace Carro.Pages.Relatorios
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
