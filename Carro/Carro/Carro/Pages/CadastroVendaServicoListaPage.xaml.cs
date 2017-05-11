using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Carro.ViewModels;

namespace Carro.Pages
{
    public partial class CadastroVendaServicoListaPage : ContentPage
    {
        public CadastroVendaServicoListaPage(CadastroVendaViewModel vendaViewModel)
        {
            BindingContext = vendaViewModel;
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            if (e == null)
            {
                return; // has been set to null, do not 'process' tapped event 
            }

            if (((CadastroVendaViewModel)BindingContext).AdicionaServicoCommand.CanExecute(null))
            {
                ((CadastroVendaViewModel)BindingContext).AdicionaServicoCommand.Execute(((ListView)sender).SelectedItem);
            }
             ((ListView)sender).SelectedItem = null; // de-select the row
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
