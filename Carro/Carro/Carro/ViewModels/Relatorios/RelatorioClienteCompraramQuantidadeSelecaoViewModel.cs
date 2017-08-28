using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Carro.Models;
using System.Collections.Generic;
using Carro.Repositories;
using Carro.Services;
using System.Threading.Tasks;
using Carro.Pages.Relatorios;


namespace Carro.ViewModels.Relatorios
{
    public class RelatorioClienteCompraramQuantidadeSelecaoViewModel : BaseViewModel
    {
        public RelatorioClienteCompraramQuantidadeSelecaoViewModel(INavigation navigation) : base(navigation)
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



        Command _RelClienteCompraramQuantidadeCommand;
        public Command RelClienteCompraramQuantidadeCommand
        {
            get { return _RelClienteCompraramQuantidadeCommand ?? (_RelClienteCompraramQuantidadeCommand = new Command(async () => await ExecuteRelClienteCompraramQuantidadeCommand())); }
        }

        async Task ExecuteRelClienteCompraramQuantidadeCommand()
        {
            if (!IsBusy)
            {
                DataCompleta data = new DataCompleta();
                data.DataInicio = dataInicial;
                data.DataFinal = dataFinal;
                IsBusy = true;
                await Navigation.PushAsync(new RelatorioClienteCompraramQuantidadeResultadoPage(data));
                IsBusy = false;
            }
        }

    }
}
