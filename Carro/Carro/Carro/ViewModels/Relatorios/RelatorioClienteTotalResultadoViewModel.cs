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
    public class RelatorioClienteTotalResultadoViewModel : BaseViewModel
    {

        public RelatorioClienteTotalResultadoViewModel(INavigation navigation) : base(navigation)
        {

            ExecuteTotalClientesCommand();

        }

        int _totalClientes = 0;
        public int totalClientes
        {
            get
            {
                return _totalClientes;
            }
            set
            {
                _totalClientes = value;
                SetPropertyChanged(nameof(totalClientes));
            }
        }

        Command _TotalClientesCommand;
        public Command TotalClientesCommand
        {
            get { return _TotalClientesCommand ?? (_TotalClientesCommand = new Command(() => ExecuteTotalClientesCommand())); }
        }

        void ExecuteTotalClientesCommand()
        {

            var sqlite = DependencyService.Get<ISQLite>();
            using (var scope = new TransactionScope(sqlite))
            {
                totalClientes = new DataService(sqlite).RelatorioTotalClientes();
                scope.Complete();
            }

        }

    }
}
