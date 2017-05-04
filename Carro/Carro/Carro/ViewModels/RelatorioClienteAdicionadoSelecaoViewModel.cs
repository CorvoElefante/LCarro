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


        DataCompleta _data = new DataCompleta();
        public DataCompleta data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
                SetPropertyChanged(nameof(data));
            }
        }

        DateTime _dataInicial = System.DateTime.Now;
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
                data.DataInicio = dataInicial;
            }
        }

        DateTime _dataFinal = System.DateTime.Now;
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
                data.DataFim = dataFinal;
            }
        }

        public class DataCompleta
        {
            public DateTime DataInicio = DateTime.Now;
            public DateTime DataFim = DateTime.Now;
        }



        Command _RelClienteAdicionadoCommand;
        public Command RelClienteAdicionadoCommand
        {
            get { return _RelClienteAdicionadoCommand ?? (_RelClienteAdicionadoCommand = new Command<DataCompleta>(async (data) => await ExecuteRelClienteAdicionadoCommand(data))); }
        }

        async Task ExecuteRelClienteAdicionadoCommand(DataCompleta data)
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new RelatorioClienteAdicionadoResultadoPage(data));
                IsBusy = false;
            }
        }

    }
}
