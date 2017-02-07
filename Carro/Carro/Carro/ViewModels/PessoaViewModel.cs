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
    public class PessoaViewModel : BaseViewModel
    {

        public PessoaViewModel(INavigation navigation) : base(navigation)
        {

            var sqlite = DependencyService.Get<ISQLite>();
            using (var scope = new TransactionScope(sqlite))
            {
                var service = new DataService(sqlite);
                if (service.GetPessoas().Count == 0)
                {
                    service.SavePessoa(new Pessoa { Nome = "João" });
                    service.SavePessoa(new Pessoa { Nome = "Maria"});
                    service.SavePessoa(new Pessoa { Nome = "Pedro"});
                    service.SavePessoa(new Pessoa { Nome = "Carlos"});
                }
                scope.Complete();
            }

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

        Command _SalvarPessoaCommand;
        public Command SalvarPessoaCommand
        {
            get { return _AddPessoaCommand ?? (_AddPessoaCommand = new Command(async () => await ExecuteSalvarPessoaCommand())); }
        }

        async Task ExecuteSalvarPessoaCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;

                    var sqlite = DependencyService.Get<ISQLite>();
                    using (var scope = new TransactionScope(sqlite))
                    {
                        var service = new DataService(sqlite);

                        service.SavePessoa(new Pessoa { Nome = nomeEntry });
                        scope.Complete();
                    }

                    using (var scope = new TransactionScope(sqlite))
                    {
                        Pessoas = new ObservableCollection<Pessoa>(
                            new DataService(sqlite).GetPessoas()
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
                await Navigation.PushAsync(new CadastroPessoaPage());
                IsBusy = false;
            }
        }
 
            //var pessoa = new Pessoa()
            //{
            //    Nome = Carro.Pages.CadastroPessoaPage.nomeEntry.Text,
            //    RuaN = Carro.Pages.CadastroPessoaPage.ruaNEntry.Text,
            //    Bairro = Carro.Pages.CadastroPessoaPage.bairroEntry.Text,
            //    Cpf = Carro.Pages.CadastroPessoaPage.cpfEntry.Text,
            //    Telefone = Carro.Pages.CadastroPessoaPage.telefoneEntry.Text,
            //    Data = Carro.Pages.CadastroPessoaPage.ndataEntry.Text,
            //    Email = Carro.Pages.CadastroPessoaPage.emailEntry.Text
            //};
    }
}
