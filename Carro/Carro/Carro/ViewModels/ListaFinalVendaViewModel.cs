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
    class ListaFinalVendaViewModel : BaseViewModel
    {
        public ListaFinalVendaViewModel(INavigation navigation) : base(navigation)
        {
            ExecuteListaFinalVendaCommand();
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
                Vendas = new ObservableCollection<OrdemVenda>(new DataService(sqlite).FindFinalVendaByNome(_Search));
            }
        }

        Command _AddFinalVendaCommand;
        public Command AddFinalVendaCommand
        {
            get { return _AddFinalVendaCommand ?? (_AddFinalVendaCommand = new Command(async () => await ExecuteAddFinalVendaCommand())); }
        }

        async Task ExecuteAddFinalVendaCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new CadastroFinalVendaClienteFuncionarioPage());
                IsBusy = false;
            }
        }

        Command _ListaFinalVendaCommand;
        public Command ListaFinalVendaCommand
        {
            get { return _ListaFinalVendaCommand ?? (_ListaFinalVendaCommand = new Command(() => ExecuteListaFinalVendaCommand())); }
        }

        void ExecuteListaFinalVendaCommand()
        {

            var sqlite = DependencyService.Get<ISQLite>();
            using (var scope = new TransactionScope(sqlite))
            {
                Vendas = new ObservableCollection<OrdemVenda>(
                    new DataService(sqlite).FindFinalVendaByNome("")
                );
                scope.Complete();
            }
        }

        Command _EditarFinalVendaCommand;
        public Command EditarFinalVendaCommand
        {
            get { return _EditarFinalVendaCommand ?? (_EditarFinalVendaCommand = new Command<OrdemVenda>(async (qq) => await ExecuteEditarFinalVendaCommand(qq))); }
        }

        async Task ExecuteEditarFinalVendaCommand(OrdemVenda value)
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new EditarFinalVendaPage(value));
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
                await Navigation.PushAsync(new ListaFinalVendaHelpPage());
                IsBusy = false;
            }
        }
    }
}
