﻿using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Carro.Models;
using System.Collections.Generic;
using Carro.Repositories;
using Carro.Services;
using System.Threading.Tasks;
using Carro.Pages.Relatorios;
using Carro.Pages.Help.RelatoriosHelp;


namespace Carro.ViewModels.Relatorios
{
    public class RelatorioFuncionarioNumeroVendaSelecaoViewModel : BaseViewModel
    {
        public RelatorioFuncionarioNumeroVendaSelecaoViewModel(INavigation navigation) : base(navigation)
        {


        }

        public class DataCompleta
        {
            public DateTime DataInicio;
            public DateTime DataFinal;
        }

        DateTime _dataInicial = System.DateTime.Today;
        public DateTime dataInicial
        {
            get
            {
                return _dataInicial;
            }
            set
            {
                _dataInicial = value;
                SetPropertyChanged(nameof(dataInicial));
            }
        }

        DateTime _dataFinal = DateTime.UtcNow;
        public DateTime dataFinal
        {
            get
            {
                return _dataFinal;
            }
            set
            {
                _dataFinal = value;
                SetPropertyChanged(nameof(dataFinal));
            }
        }



        Command _RelFuncionarioVendaQuantidadeCommand;
        public Command RelFuncionarioVendaQuantidadeCommand
        {
            get { return _RelFuncionarioVendaQuantidadeCommand ?? (_RelFuncionarioVendaQuantidadeCommand = new Command(async () => await ExecuteRelFuncionarioVendaQuantidadeCommand())); }
        }

        async Task ExecuteRelFuncionarioVendaQuantidadeCommand()
        {
            if (!IsBusy)
            {
                DataCompleta data = new DataCompleta();
                data.DataInicio = dataInicial;
                data.DataFinal = dataFinal;
                IsBusy = true;
                await Navigation.PushAsync(new RelatorioFuncionarioNumeroVendaResultadoPage(data));
                IsBusy = false;
            }
        }

        Command _HelpCommand;
        public Command HelpCommand
        {
            get { return _HelpCommand ?? (_HelpCommand = new Command(async () => await ExecuteHelpCommand())); }
        }

        async Task ExecuteHelpCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new RelatorioFuncionarioNumeroVendaSelecaoHelpPage());
                IsBusy = false;
            }
        }
    }
}
