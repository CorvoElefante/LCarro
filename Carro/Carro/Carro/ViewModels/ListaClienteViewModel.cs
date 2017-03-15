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
    public class ListaClienteViewModel : BaseViewModel
    {

        public ListaClienteViewModel(INavigation navigation) : base(navigation)
        {

            var sqlite = DependencyService.Get<ISQLite>();

            ExecuteAtualizaPessoaCommand();

            using (var scope = new TransactionScope(sqlite))
            {
                Pessoas = new ObservableCollection<Pessoa>(
                    new DataService(sqlite).GetPessoas()
                );
                scope.Complete();
            }

        }
        ObservableCollection<Pessoa> _Pessoas;
        public ObservableCollection<Pessoa> Pessoas
        {
            get
            {
                return _Pessoas;
            }
            set
            {
                _Pessoas = value;
                SetPropertyChanged(nameof(Pessoas));
            }
        }

        ObservableCollection<Pessoa> _PessoasNull;
        public ObservableCollection<Pessoa> PessoasNull
        {
            get
            {
                return _PessoasNull;
            }
            set
            {
                _PessoasNull = value;
                SetPropertyChanged(nameof(PessoasNull));
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
                Pessoas = new ObservableCollection<Pessoa>(new DataService(sqlite).FindPessoaByNome(_Search));
            }
        }

        Command _AddPessoaCommand;
        public Command AddPessoaCommand
        {
            get { return _AddPessoaCommand ?? (_AddPessoaCommand = new Command(async () => await ExecuteAddPessoaCommand())); }
        }

        async Task ExecuteAddPessoaCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new CadastroClientePage());
                IsBusy = false;
            }
        }

        Command _EditarPessoaCommand;
        public Command EditarPessoaCommand
        {
            get { return _EditarPessoaCommand ?? (_EditarPessoaCommand = new Command<Pessoa>(async (qq) => await ExecuteEditarPessoaCommand(qq))); }
        }

        async Task ExecuteEditarPessoaCommand(Pessoa value)
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new EditarClientePage(value));
                IsBusy = false;
            }
        }

        Command _AtualizaPessoaCommand;
        public Command AtualizaPessoaCommand
        {
            get { return _AtualizaPessoaCommand ?? (_AtualizaPessoaCommand = new Command(() => ExecuteAtualizaPessoaCommand())); }
        }

        void ExecuteAtualizaPessoaCommand()
        {

            var sqlite = DependencyService.Get<ISQLite>();
            using (var scope = new TransactionScope(sqlite))
            {
                Pessoas = new ObservableCollection<Pessoa>(
                    new DataService(sqlite).GetPessoas()
                );
                scope.Complete();
            }

        }
    }
}
