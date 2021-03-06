﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Carro.ViewModels;

namespace Carro.Pages
{
    public partial class ListaVendaPage : ContentPage
    {
        public ListaVendaPage()
        {
            BindingContext = new ListaVendaViewModel(Navigation);
            InitializeComponent();
        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            if (e == null)
            {
                return; // has been set to null, do not 'process' tapped event 
            }

            if (((ListaVendaViewModel)BindingContext).EditarVendaCommand.CanExecute(null))
            {
                ((ListaVendaViewModel)BindingContext).EditarVendaCommand.Execute(((ListView)sender).SelectedItem);
            }
            ((ListView)sender).SelectedItem = null; // de-select the row
        }
    }
}
