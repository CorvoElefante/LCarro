using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Carro.ViewModels;


namespace Carro.Pages
{
    public partial class CadastroVendaClienteListaPage : ContentPage
    {
        public CadastroVendaClienteListaPage()
        {
            BindingContext = new CadastroVendaViewModel(Navigation);
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            if (e == null)
            {
                return; // has been set to null, do not 'process' tapped event 
            }

            if (((CadastroVendaViewModel)BindingContext).AdicionaClienteCommand.CanExecute(null))
            {
                ((CadastroVendaViewModel)BindingContext).AdicionaClienteCommand.Execute(((ListView)sender).SelectedItem);
            }
             ((ListView)sender).SelectedItem = null; // de-select the row
        }
    }
}
