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
    public class EditarServicoViewModel : BaseViewModel
    {

        public EditarServicoViewModel(INavigation navigation, Servico value) : base(navigation)
        {
            var sqlite = DependencyService.Get<ISQLite>();
            idEntry = value.Id;
            nomeEntry = value.Nome;
            precoEntry = value.Preco;
            descricaoEntry = value.Descricao;
            tempoEntry = value.Tempo;
            servicoEntry = value;

        }

        Servico _servicoEntry;
        public Servico servicoEntry
        {
            get
            {
                return _servicoEntry;
            }
            set
            {
                _servicoEntry = value;
                SetPropertyChanged(nameof(servicoEntry));
            }
        }

        long? _idEntry = 0;
        public long? idEntry
        {
            get
            {
                return _idEntry;
            }
            set
            {
                _idEntry = value;
                SetPropertyChanged(nameof(idEntry));
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
                if (precoEntry <= 0)
                {
                    precoEntryInvalido = true;
                }
                else
                {
                    precoEntryInvalido = false;
                }
            }
        }

        bool _precoEntryInvalido = true;
        public bool precoEntryInvalido
        {
            get
            {
                return _precoEntryInvalido;
            }
            set
            {
                _precoEntryInvalido = value;
                SetPropertyChanged(nameof(precoEntryInvalido));
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

                    service.SaveServico(new Servico { Id = idEntry, Nome = nomeEntry, Preco = precoEntry, Descricao = descricaoEntry, Tempo = tempoEntry });
                    scope.Complete();
                }
                IsBusy = false;
            }
        }

        Command _DeletarServicoCommand;
        public Command DeletarServicoCommand
        {
            get { return _DeletarServicoCommand ?? (_DeletarServicoCommand = new Command(async () => await ExecuteDeletarServicoCommand())); }
        }

        async Task ExecuteDeletarServicoCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;

                var sqlite = DependencyService.Get<ISQLite>();
                using (var scope = new TransactionScope(sqlite))
                {
                    var service = new DataService(sqlite);

                    service.DeleteServico(servicoEntry);
                    scope.Complete();
                }

                IsBusy = false;
            }
        }

    }
}