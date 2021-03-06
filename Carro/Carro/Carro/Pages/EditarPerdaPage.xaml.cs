﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Carro.ViewModels;
using Carro.Models;

namespace Carro.Pages
{
    public partial class EditarPerdaPage : ContentPage
    {
        public EditarPerdaPage(Perda value)
        {
            BindingContext = new EditarPerdaViewModel(Navigation, value);
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
