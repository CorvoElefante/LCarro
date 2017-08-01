using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Carro.Models;
using System.Collections.Generic;
using Carro.Repositories;
using Carro.Services;
using System.Threading.Tasks;
using Carro.Pages;
using Carro.Pages.Help;

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

        string _Search = string.Empty;
        public string Search
        {
            get { return _Search; }
            set
            {
                _Search = value;
                var sqlite = DependencyService.Get<ISQLite>();
                Vendas = new ObservableCollection<OrdemVenda>(new DataService(sqlite).FindVendaByNome(_Search));
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
                    new DataService(sqlite).FindVendaByNome("")
                );
                scope.Complete();
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
                await Navigation.PushAsync(new ListaVendaHelpPage());
                IsBusy = false;
            }
        }
    }
}
