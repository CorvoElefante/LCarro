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
    public class ListaServicoViewModel : BaseViewModel
    {

        public ListaServicoViewModel(INavigation navigation) : base(navigation)
        {

            ExecuteAtualizaServicoCommand();

        }
        ObservableCollection<Servico> _Servicos;
        public ObservableCollection<Servico> Servicos
        {
            get
            {
                return _Servicos;
            }
            set
            {
                _Servicos = value;
                SetPropertyChanged(nameof(Servicos));
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
                Servicos = new ObservableCollection<Servico>(new DataService(sqlite).FindServicoByNome(_Search));
            }
        }

        Command _AddServicoCommand;
        public Command AddServicoCommand
        {
            get { return _AddServicoCommand ?? (_AddServicoCommand = new Command(async () => await ExecuteAddServicoCommand())); }
        }

        async Task ExecuteAddServicoCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new CadastroServicoPage());
                IsBusy = false;
            }
        }

        Command _EditarServicoCommand;
        public Command EditarServicoCommand
        {
            get { return _EditarServicoCommand ?? (_EditarServicoCommand = new Command<Servico>(async (qq) => await ExecuteEditarServicoCommand(qq))); }
        }

        async Task ExecuteEditarServicoCommand(Servico value)
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new EditarServicoPage(value));
                IsBusy = false;
            }
        }

        Command _AtualizaServicoCommand;
        public Command AtualizaServicoCommand
        {
            get { return _AtualizaServicoCommand ?? (_AtualizaServicoCommand = new Command(() =>ExecuteAtualizaServicoCommand())); }
        }

        void ExecuteAtualizaServicoCommand()
        {

            var sqlite = DependencyService.Get<ISQLite>();
            using (var scope = new TransactionScope(sqlite))
            {
                Servicos = new ObservableCollection<Servico>(
                    new DataService(sqlite).GetServicos()
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
                await Navigation.PushAsync(new ListaServicoHelpPage());
                IsBusy = false;
            }
        }
    }
}