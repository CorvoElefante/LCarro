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
    public class RelatorioProdutoMaisVendidoSelecaoViewModel : BaseViewModel
    {
        public RelatorioProdutoMaisVendidoSelecaoViewModel(INavigation navigation) : base(navigation)
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



        Command _RelProdutosMaisVendidosCommand;
        public Command RelProdutosMaisVendidosCommand
        {
            get { return _RelProdutosMaisVendidosCommand ?? (_RelProdutosMaisVendidosCommand = new Command(async () => await ExecuteRelProdutosMaisVendidosCommand())); }
        }

        async Task ExecuteRelProdutosMaisVendidosCommand()
        {
            if (!IsBusy)
            {
                DataCompleta data = new DataCompleta();
                data.DataInicio = dataInicial;
                data.DataFinal = dataFinal;
                IsBusy = true;
                await Navigation.PushAsync(new RelatorioProdutoMaisVendidoResultadoPage(data));
                IsBusy = false;
            }
        }
    }
}
