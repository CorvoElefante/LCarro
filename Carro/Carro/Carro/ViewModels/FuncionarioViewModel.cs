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
    public class FuncionarioViewModel : BaseViewModel
    {
        public FuncionarioViewModel(INavigation navigation) : base(navigation)
        {
            var sqlite = DependencyService.Get<ISQLite>();
            using (var scope = new TransactionScope(sqlite))
            {
                Funcionarios = new ObservableCollection<Funcionario>(
                    new DataService(sqlite).GetFuncionarios()
                );
                scope.Complete();
            }
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

        string _nomeEntry = string.Empty;
        public string nomeEntry
        {
            get
            {
                return _nomeEntry;
            }
            set
            {
                _nomeEntry = value;
                SetPropertyChanged(nameof(nomeEntry));
            }
        }

        string _ruaNEntry = string.Empty;
        public string ruaNEntry
        {
            get
            {
                return _ruaNEntry;
            }
            set
            {
                _ruaNEntry = value;
                SetPropertyChanged(nameof(ruaNEntry));
            }
        }

        string _bairroEntry = string.Empty;
        public string bairroEntry
        {
            get
            {
                return _bairroEntry;
            }
            set
            {
                _bairroEntry = value;
                SetPropertyChanged(nameof(bairroEntry));
            }
        }

        string _telefoneEntry = string.Empty;
        public string telefoneEntry
        {
            get
            {
                return _telefoneEntry;
            }
            set
            {
                _telefoneEntry = value;
                SetPropertyChanged(nameof(telefoneEntry));
            }
        }

        string _emailEntry = string.Empty;
        public string emailEntry
        {
            get
            {
                return _emailEntry;
            }
            set
            {
                _emailEntry = value;
                SetPropertyChanged(nameof(emailEntry));
            }
        }

        string _ndataEntry = string.Empty;
        public string ndataEntry
        {
            get
            {
                return _ndataEntry;
            }
            set
            {
                _ndataEntry = value;
                SetPropertyChanged(nameof(ndataEntry));
            }
        }

        string _cpfEntry = string.Empty;
        public string cpfEntry
        {
            get
            {
                return _cpfEntry;
            }
            set
            {
                _cpfEntry = value;
                SetPropertyChanged(nameof(cpfEntry));
            }
        }

        float _salarioEntry = 0.0F;
        public float salarioEntry
        {
            get
            {
                return _salarioEntry;
            }
            set
            {
                _salarioEntry = value;
                SetPropertyChanged(nameof(salarioEntry));
            }
        }

        string _funcaoEntry = string.Empty;
        public string funcaoEntry
        {
            get
            {
                return _funcaoEntry;
            }
            set
            {
                _funcaoEntry = value;
                SetPropertyChanged(nameof(funcaoEntry));
            }
        }

        Command _SalvarFuncionarioCommand;
        public Command SalvarFuncionarioCommand
        {
            get { return _SalvarFuncionarioCommand ?? (_SalvarFuncionarioCommand = new Command(async () => await ExecuteSalvarFuncionarioCommand())); }
        }

        async Task ExecuteSalvarFuncionarioCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;

                var sqlite = DependencyService.Get<ISQLite>();
                using (var scope = new TransactionScope(sqlite))
                {
                    var service = new DataService(sqlite);
                    var Pessoa = new Pessoa{ Nome = nomeEntry, RuaN = ruaNEntry, Bairro = bairroEntry, Telefone = telefoneEntry, Email = emailEntry, Data = ndataEntry, Cpf = cpfEntry };
                    service.SavePessoa(Pessoa);

                    service.SaveFuncionario(new Funcionario { Salario = salarioEntry, Funcao = funcaoEntry, Pessoa = Pessoa});
                    
                    scope.Complete();
                }

                using (var scope = new TransactionScope(sqlite))
                {
                    Funcionarios = new ObservableCollection<Funcionario>(
                        new DataService(sqlite).GetFuncionarios()
                    );
                    scope.Complete();
                }
                IsBusy = false;
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

    }
}
