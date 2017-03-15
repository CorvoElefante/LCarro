using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Carro.ViewModels;

namespace Carro.Pages
{
    public partial class ListaClientePage : ContentPage
    {
        public ListaClientePage()
        {
            BindingContext = new ListaClienteViewModel(Navigation);
            InitializeComponent();
        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            if (e == null)
            {
                return; // has been set to null, do not 'process' tapped event 
            }
            
            if (((ListaClienteViewModel)BindingContext).EditarPessoaCommand.CanExecute(null))
            {
                ((ListaClienteViewModel)BindingContext).EditarPessoaCommand.Execute(((ListView)sender).SelectedItem);
            }
            ((ListView)sender).SelectedItem = null; // de-select the row
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((ListaClienteViewModel)BindingContext).AtualizaPessoaCommand.Execute(null);
        }
    }
}
