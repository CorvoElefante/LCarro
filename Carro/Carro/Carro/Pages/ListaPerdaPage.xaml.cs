﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Carro.ViewModels;

namespace Carro.Pages
{
    public partial class ListaPerdaPage : ContentPage
    {
        public ListaPerdaPage()
        {
            BindingContext = new ListaPerdaViewModel(Navigation);
            InitializeComponent();
        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            if (e == null)
            {
                return; // has been set to null, do not 'process' tapped event 
            }

            if (((ListaPerdaViewModel)BindingContext).EditarPerdaCommand.CanExecute(null))
            {
                ((ListaPerdaViewModel)BindingContext).EditarPerdaCommand.Execute(((ListView)sender).SelectedItem);
            }
              ((ListView)sender).SelectedItem = null; // de-select the row
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((ListaPerdaViewModel)BindingContext).AtualizaPerdaCommand.Execute(null);
        }
    }
}
