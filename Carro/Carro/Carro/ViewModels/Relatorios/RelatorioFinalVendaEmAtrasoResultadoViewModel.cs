﻿using System;
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
    public class RelatorioFinalVendaEmAtrasoResultadoViewModel : BaseViewModel
    {
        public RelatorioFinalVendaEmAtrasoResultadoViewModel(INavigation navigation) : base(navigation)
        {
            ExecuteListaVendasAtrasadasCommand();
        }

        ObservableCollection<OrdemVenda> _VendasAtrasadas = new ObservableCollection<OrdemVenda>();
        public ObservableCollection<OrdemVenda> VendasAtrasadas
        {
            get
            {
                return _VendasAtrasadas;
            }
            set
            {
                _VendasAtrasadas = value;
                SetPropertyChanged(nameof(VendasAtrasadas));
            }
        }

        Command _ListaVendasAtrasadasCommand;
        public Command ListaVendasAtrasadasCommand
        {
            get { return _ListaVendasAtrasadasCommand ?? (_ListaVendasAtrasadasCommand = new Command(() => ExecuteListaVendasAtrasadasCommand())); }
        }

        void ExecuteListaVendasAtrasadasCommand()
        {

            var sqlite = DependencyService.Get<ISQLite>();
            using (var scope = new TransactionScope(sqlite))
            {
                VendasAtrasadas = new ObservableCollection<OrdemVenda>(
                    new DataService(sqlite).RelatorioFinalVendaAtradas()
                );
                scope.Complete();
            }

        }
    }
}
