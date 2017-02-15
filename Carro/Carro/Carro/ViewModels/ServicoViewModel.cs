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
    public class ServicoViewModel : BaseViewModel
    {

        public ServicoViewModel(INavigation navigation) : base(navigation)
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

        float _precoEntry = 0.0F;
        public float precoEntry
        {
            get
            {
                return _precoEntry;
            }
            set
            {
                _precoEntry = value;
                SetPropertyChanged(nameof(precoEntry));
            }
        }

        string _descricaoEntry = string.Empty;
        public string descricaoEntry
        {
            get
            {
                return _descricaoEntry;
            }
            set
            {
                _descricaoEntry = value;
                SetPropertyChanged(nameof(descricaoEntry));
            }
        }

        string _tempoEntry = string.Empty;
        public string tempoEntry
        {
            get
            {
                return _tempoEntry;
            }
            set
            {
                _tempoEntry = value;
                SetPropertyChanged(nameof(tempoEntry));
            }
        }

        Command _SalvarServicoCommand;
        public Command SalvarServicoCommand
        {
            get { return _SalvarServicoCommand ?? (_SalvarServicoCommand = new Command(async () => await ExecuteSalvarServicoCommand())); }
        }

        async Task ExecuteSalvarServicoCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;

                var sqlite = DependencyService.Get<ISQLite>();
                using (var scope = new TransactionScope(sqlite))
                {
                    var service = new DataService(sqlite);

                    service.SaveServico(new Servico { Nome = nomeEntry, Preco = precoEntry, Descricao = descricaoEntry, Tempo = tempoEntry});
                    scope.Complete();
                }

                using (var scope = new TransactionScope(sqlite))
                {
                    Servicos = new ObservableCollection<Servico>(
                        new DataService(sqlite).GetServicos()
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

    }
}