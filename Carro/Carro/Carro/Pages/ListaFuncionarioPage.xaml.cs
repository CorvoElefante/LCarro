using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Carro.ViewModels;

using Xamarin.Forms;

namespace Carro.Pages
{
    public partial class ListaFuncionarioPage : ContentPage
    {
        public ListaFuncionarioPage()
        {
            //BindingContext = new FuncionarioViewModel(Navigation);
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
