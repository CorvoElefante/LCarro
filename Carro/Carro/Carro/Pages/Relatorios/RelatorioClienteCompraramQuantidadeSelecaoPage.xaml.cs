﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Carro.ViewModels.Relatorios;

namespace Carro.Pages.Relatorios
{
    public partial class RelatorioClienteCompraramQuantidadeSelecaoPage : ContentPage
    {
        public RelatorioClienteCompraramQuantidadeSelecaoPage()
        {
            BindingContext = new RelatorioClienteCompraramQuantidadeSelecaoViewModel(Navigation);
            InitializeComponent();
        }
    }
}
