﻿using System;
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
    class ListaVendaViewModel : BaseViewModel
    {
        public ListaVendaViewModel(INavigation navigation) : base(navigation)
        {
            ExecuteListaVendaCommand();
        }


        ObservableCollection<OrdemVenda> _Vendas = new ObservableCollection<OrdemVenda>();
        public ObservableCollection<OrdemVenda> Vendas
        {
            get
            {
                return _Vendas;
            }
            set
            {
                _Vendas = value;
                SetPropertyChanged(nameof(Vendas));
            }
        }

        int _tipoBusca = 0;
        public int tipoBusca
        {
            get
            {
                return _tipoBusca;
            }
            set
            {
                _tipoBusca = value;
                SetPropertyChanged(nameof(tipoBusca));
                //0 = Data
                //1 = Vencidos
            }
        }

        string _Search = string.Empty;
        public string Search
        {
            get { return _Search; }
            set
            {
                _Search = value;
                var sqlite = DependencyService.Get<ISQLite>();
                Vendas = new ObservableCollection<OrdemVenda>(new DataService(sqlite).FindVendaByNome(_Search, tipoBusca));
            }
        }

        Command _AddVendaCommand;
        public Command AddVendaCommand
        {
            get { return _AddVendaCommand ?? (_AddVendaCommand = new Command(async () => await ExecuteAddVendaCommand())); }
        }

        async Task ExecuteAddVendaCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new CadastroVendaClienteFuncionarioPage());
                IsBusy = false;
            }
        }

        Command _ListaVendaCommand;
        public Command ListaVendaCommand
        {
            get { return _ListaVendaCommand ?? (_ListaVendaCommand = new Command(() => ExecuteListaVendaCommand())); }
        }

        void ExecuteListaVendaCommand()
        {

            var sqlite = DependencyService.Get<ISQLite>();
            using (var scope = new TransactionScope(sqlite))
            {
                Vendas = new ObservableCollection<OrdemVenda>(
                    new DataService(sqlite).FindVendaByNome("", tipoBusca)
                );
                scope.Complete();
            }
        }
    }
}
