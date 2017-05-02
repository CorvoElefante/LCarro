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
    public class CadastroFuncionarioViewModel : BaseViewModel
    {
        public CadastroFuncionarioViewModel(INavigation navigation) : base(navigation)
        {
            var sqlite = DependencyService.Get<ISQLite>();
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
                if (nomeEntry == string.Empty)
                {
                    nomeEntryInvalido = true;
                }
                else
                {
                    nomeEntryInvalido = false;
                }
            }
        }

        bool _nomeEntryInvalido = true;
        public bool nomeEntryInvalido
        {
            get
            {
                return _nomeEntryInvalido;
            }
            set
            {
                _nomeEntryInvalido = value;
                SetPropertyChanged(nameof(nomeEntryInvalido));
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

        decimal _salarioEntry = 0.0m;
        public decimal salarioEntry
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
            if (nomeEntry != string.Empty)
            {
                if (!IsBusy)
                {
                    IsBusy = true;

                    var sqlite = DependencyService.Get<ISQLite>();
                    using (var scope = new TransactionScope(sqlite))
                    {
                        var service = new DataService(sqlite);
                        DateTime data = DateTime.Now;
                        var Pessoa = new Pessoa { Nome = nomeEntry, RuaN = ruaNEntry, Bairro = bairroEntry, Telefone = telefoneEntry, Email = emailEntry, Data = ndataEntry, Cpf = cpfEntry, Registro = data };
                        service.SavePessoa(Pessoa);

                        service.SaveFuncionario(new Funcionario { Salario = salarioEntry, Funcao = funcaoEntry, Pessoa = Pessoa });

                        scope.Complete();
                    }
                    await Navigation.PopAsync();
                    IsBusy = false;
                }
            }          
        }
    }
}
