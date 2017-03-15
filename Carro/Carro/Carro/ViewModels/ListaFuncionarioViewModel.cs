using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Carro.Models;
using System.Collections.Generic;
using Carro.Repositories;
using Carro.Services;
using System.Threading.Tasks;
using Carro.Pages;
using SQLiteNetExtensions;

namespace Carro.ViewModels
{
    public class ListaFuncionarioViewModel : BaseViewModel
    {
        public ListaFuncionarioViewModel(INavigation navigation) : base(navigation)
        {
            ExecuteAtualizaFuncionarioCommand();
        }

        ObservableCollection<Funcionario> _Funcionarios;
        public ObservableCollection<Funcionario> Funcionarios
        {
            get
            {
                return _Funcionarios;
            }
            set
            {
                _Funcionarios = value;
                SetPropertyChanged(nameof(Funcionarios));
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
                Funcionarios = new ObservableCollection<Funcionario>(new DataService(sqlite).FindFuncionarioByNome(_Search));
            }
        }

        Command _AddFuncionarioCommand;
        public Command AddFuncionarioCommand
        {
            get { return _AddFuncionarioCommand ?? (_AddFuncionarioCommand = new Command(async () => await ExecuteAddFuncionarioCommand())); }
        }

        async Task ExecuteAddFuncionarioCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new CadastroFuncionarioPage());
                IsBusy = false;
            }
        }

        Command _EditarFuncionarioCommand;
        public Command EditarFuncionarioCommand
        {
            get { return _EditarFuncionarioCommand ?? (_EditarFuncionarioCommand = new Command<Funcionario>(async (qq) => await ExecuteEditarFuncionarioCommand(qq))); }
        }

        async Task ExecuteEditarFuncionarioCommand(Funcionario value)
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new EditarFuncionarioPage(value));
                IsBusy = false;
            }
        }

        Command _AtualizaFuncionarioCommand;
        public Command AtualizaFuncionarioCommand
        {
            get { return _AtualizaFuncionarioCommand ?? (_AtualizaFuncionarioCommand = new Command(() => ExecuteAtualizaFuncionarioCommand())); }
        }

        void ExecuteAtualizaFuncionarioCommand()
        {

            var sqlite = DependencyService.Get<ISQLite>();
            using (var scope = new TransactionScope(sqlite))
            {
                Funcionarios = new ObservableCollection<Funcionario>(
                    new DataService(sqlite).FindFuncionarioByNome("")
                );
                scope.Complete();
            }

        }
    }
}
