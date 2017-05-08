using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Carro.Models;
using System.Collections.Generic;
using Carro.Repositories;
using Carro.Services;
using System.Threading.Tasks;
using Carro.Pages;

namespace Carro.ViewModels
{
    public class RelatorioClienteAdicionadoSelecaoViewModel : BaseViewModel
    {

        public RelatorioClienteAdicionadoSelecaoViewModel(INavigation navigation) : base(navigation)
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

        DateTime _dataFinal = DateTime.Now;
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

        

        Command _RelClienteAdicionadoCommand3;
        public Command RelClienteAdicionadoCommand3
        {
            get { return _RelClienteAdicionadoCommand3 ?? (_RelClienteAdicionadoCommand3 = new Command(async () => await ExecuteRelClienteAdicionadoCommand3())); }
        }

        async Task ExecuteRelClienteAdicionadoCommand3()
        {
            if (!IsBusy)
            {
                DataCompleta data = new DataCompleta();
                data.DataInicio = dataInicial;
                data.DataFinal = dataFinal;
                IsBusy = true;
                await Navigation.PushAsync(new RelatorioClienteAdicionadoResultadoPage(data));
                IsBusy = false;
            }
        }

    }
}
