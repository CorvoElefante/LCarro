using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Carro.ViewModels;

namespace Carro.Pages
{
    public partial class ListaProdutoPerdaPage : ContentPage
    {
        public ListaProdutoPerdaPage()
        {
            BindingContext = new ListaProdutoPerdaViewModel(Navigation);
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            if (e == null)
            {
                return; // has been set to null, do not 'process' tapped event 
            }

            if (((ListaProdutoPerdaViewModel)BindingContext).EnviaProdutoPerdaCommand.CanExecute(null))
            {
                ((ListaProdutoPerdaViewModel)BindingContext).EnviaProdutoPerdaCommand.Execute(((ListView)sender).SelectedItem);
            }
            ((ListView)sender).SelectedItem = null; // de-select the row
        }
    }
}
