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
    public class CadastroServicoViewModel : BaseViewModel
    {

        public CadastroServicoViewModel(INavigation navigation) : base(navigation)
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
            }
        }

        float _precoEntry;
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

                    service.SaveServico(new Servico { Nome = nomeEntry, Preco = precoEntry, Descricao = descricaoEntry, Tempo = tempoEntry });
                    scope.Complete();
                }
                IsBusy = false;
            }
        }
    }
}