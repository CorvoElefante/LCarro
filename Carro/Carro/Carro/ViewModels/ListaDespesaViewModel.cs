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
    public class ListaDespesaViewModel : BaseViewModel
    {

        public ListaDespesaViewModel(INavigation navigation) : base(navigation)
        {

            ExecuteAtualizaDespesaCommand();

        }

        ObservableCollection<Despesa> _Despesas;
        public ObservableCollection<Despesa> Despesas
        {
            get
            {
                return _Despesas;
            }
            set
            {
                _Despesas = value;
                SetPropertyChanged(nameof(Despesas));
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
                Despesas = new ObservableCollection<Despesa>(new DataService(sqlite).FindDespesaByNome(_Search));
            }
        }

        Command _AddDespesaCommand;
        public Command AddDespesaCommand
        {
            get { return _AddDespesaCommand ?? (_AddDespesaCommand = new Command(async () => await ExecuteAddDespesaCommand())); }
        }

        async Task ExecuteAddDespesaCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new CadastroDespesaPage());
                IsBusy = false;
            }
        }

        Command _EditarDespesaCommand;
        public Command EditarDespesaCommand
        {
            get { return _EditarDespesaCommand ?? (_EditarDespesaCommand = new Command<Despesa>(async (qq) => await ExecuteEditarDespesaCommand(qq))); }
        }

        async Task ExecuteEditarDespesaCommand(Despesa value)
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new EditarDespesaPage(value));
                IsBusy = false;
            }
        }

        Command _AtualizaDespesaCommand;
        public Command AtualizaDespesaCommand
        {
            get { return _AtualizaDespesaCommand ?? (_AtualizaDespesaCommand = new Command(() => ExecuteAtualizaDespesaCommand())); }
        }

        void ExecuteAtualizaDespesaCommand()
        {

            var sqlite = DependencyService.Get<ISQLite>();
            using (var scope = new TransactionScope(sqlite))
            {
                Despesas = new ObservableCollection<Despesa>(
                    new DataService(sqlite).GetDespesas()
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
                await Navigation.PushAsync(new ListaDespesaHelpPage());
                IsBusy = false;
            }
        }
    }
}
