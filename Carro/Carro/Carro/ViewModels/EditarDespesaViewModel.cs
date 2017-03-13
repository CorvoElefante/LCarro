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
    public class EditarDespesaViewModel : BaseViewModel
    {

        public EditarDespesaViewModel(INavigation navigation, Despesa value) : base(navigation)
        {

            var sqlite = DependencyService.Get<ISQLite>();

            idEntry = value.Id;
            nomeEntry = value.Nome;
            valorEntry = value.Valor;
            descricaoEntry = value.Descricao;
            categoriaEntry = value.Categoria;
            despesaEntry = value;

        }

        Despesa _despesaEntry;
        public Despesa despesaEntry
        {
            get
            {
                return _despesaEntry;
            }
            set
            {
                _despesaEntry = value;
                SetPropertyChanged(nameof(despesaEntry));
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
            }
        }

        float _valorEntry = 0.0F;
        public float valorEntry
        {
            get
            {
                return _valorEntry;
            }
            set
            {
                _valorEntry = value;
                SetPropertyChanged(nameof(valorEntry));
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

        int _categoriaEntry = 0;
        public int categoriaEntry
        {
            get
            {
                return _categoriaEntry;
            }
            set
            {
                _categoriaEntry = value;
                SetPropertyChanged(nameof(categoriaEntry));
            }
        }

        Command _SalvarDespesaCommand;
        public Command SalvarDespesaCommand
        {
            get { return _SalvarDespesaCommand ?? (_SalvarDespesaCommand = new Command(async () => await ExecuteSalvarDespesaCommand())); }
        }

        async Task ExecuteSalvarDespesaCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;

                var sqlite = DependencyService.Get<ISQLite>();
                using (var scope = new TransactionScope(sqlite))
                {
                    var service = new DataService(sqlite);

                    service.SaveDespesa(new Despesa { Id = idEntry, Nome = nomeEntry, Valor = valorEntry, Descricao = descricaoEntry, Categoria = categoriaEntry });
                    scope.Complete();
                }

                IsBusy = false;
            }
        }

        Command _DeletarDespesaCommand;
        public Command DeletarDespesaCommand
        {
            get { return _DeletarDespesaCommand ?? (_DeletarDespesaCommand = new Command(async () => await ExecuteDeletarDespesaCommand())); }
        }

        async Task ExecuteDeletarDespesaCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;

                var sqlite = DependencyService.Get<ISQLite>();
                using (var scope = new TransactionScope(sqlite))
                {
                    var service = new DataService(sqlite);

                    service.DeleteDespesa(despesaEntry);
                    scope.Complete();
                }

                IsBusy = false;
            }
        }
    }
}
