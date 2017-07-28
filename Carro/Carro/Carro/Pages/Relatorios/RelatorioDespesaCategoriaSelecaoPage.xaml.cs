using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Carro.ViewModels.Relatorios;

namespace Carro.Pages.Relatorios
{
    public partial class RelatorioDespesaCategoriaSelecaoPage : ContentPage
    {
        public RelatorioDespesaCategoriaSelecaoPage()
        {
            BindingContext = new RelatorioDespesaCategoriaSelecaoViewModel(Navigation);
            InitializeComponent();
        }
    }
}
