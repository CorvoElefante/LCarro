﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Carro.ViewModels;

namespace Carro.Pages
{
    public partial class RelatorioMenuPerdaPage : ContentPage
    {
        public RelatorioMenuPerdaPage()
        {
            BindingContext = new RelatorioMenuPerdaViewModel(Navigation);
            InitializeComponent();
        }
    }
}
