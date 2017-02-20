using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Carro.ViewModels;

namespace Carro.Pages
{
    public partial class ListaDespesaPage : ContentPage
    {
        public ListaDespesaPage()
        {
            BindingContext = new DespesaViewModel(Navigation);
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
