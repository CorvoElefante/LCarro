﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Carro.ViewModels;

namespace Carro.Pages
{
    public partial class EditarVendaFuncionarioListaPage : ContentPage
    {
        public EditarVendaFuncionarioListaPage(EditarVendaViewModel vendaViewModel)
        {
            BindingContext = vendaViewModel;
            InitializeComponent();
        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            if (e == null)
            {
                return; // has been set to null, do not 'process' tapped event 
            }

            if (((EditarVendaViewModel)BindingContext).AdicionaFuncionarioCommand.CanExecute(null))
            {
                ((EditarVendaViewModel)BindingContext).AdicionaFuncionarioCommand.Execute(((ListView)sender).SelectedItem);
            }
             ((ListView)sender).SelectedItem = null; // de-select the row
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
