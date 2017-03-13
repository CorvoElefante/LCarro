using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Carro.ViewModels;

namespace Carro.Pages
{
    public partial class ListaProdutoPage : ContentPage
    {
        public ListaProdutoPage()
        {
            BindingContext = new ListaProdutoViewModel(Navigation);
            InitializeComponent();
        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            if (e == null)
            {
                return; // has been set to null, do not 'process' tapped event 
            }

            if (((ListaProdutoViewModel)BindingContext).EditarProdutoCommand.CanExecute(null))
            {
                ((ListaProdutoViewModel)BindingContext).EditarProdutoCommand.Execute(((ListView)sender).SelectedItem);
            }
            ((ListView)sender).SelectedItem = null; // de-select the row
        }
    }
}
