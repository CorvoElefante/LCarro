using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Carro.ViewModels;

namespace Carro.Pages
{
    public partial class ListaFuncionarioPage : ContentPage
    {
        public ListaFuncionarioPage()
        {
            BindingContext = new ListaFuncionarioViewModel(Navigation);
            InitializeComponent();
        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            if (e == null)
            {
                return; // has been set to null, do not 'process' tapped event 
            }

            if (((ListaFuncionarioViewModel)BindingContext).EditarFuncionarioCommand.CanExecute(null))
            {
                ((ListaFuncionarioViewModel)BindingContext).EditarFuncionarioCommand.Execute(((ListView)sender).SelectedItem);
            }
            ((ListView)sender).SelectedItem = null; // de-select the row
        }
    }
}
