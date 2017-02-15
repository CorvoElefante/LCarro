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
    public class DespesaViewModel : BaseViewModel
    {

        public DespesaViewModel(INavigation navigation) : base(navigation)
        {

            var sqlite = DependencyService.Get<ISQLite>();
            using (var scope = new TransactionScope(sqlite))
            {
                Despesas = new ObservableCollection<Despesa>(
                    new DataService(sqlite).GetDespesas()
                );
                scope.Complete();
            }

        }
        ObservableCollection<Despesa> _Despesas;
        public ObservableCollection<Despesa> Despesas
        {
            get
            {
                return _Despesas;
            }
            set
            {
                _Despesas = value;
                SetPropertyChanged(nameof(Despesas));
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

                    service.SaveDespesa(new Despesa { Nome = nomeEntry, Valor = valorEntry, Descricao = descricaoEntry, Categoria = categoriaEntry });
                    scope.Complete();
                }

                using (var scope = new TransactionScope(sqlite))
                {
                    Despesas = new ObservableCollection<Despesa>(
                        new DataService(sqlite).GetDespesas()
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
                Despesas = new ObservableCollection<Despesa>(new DataService(sqlite).FindDespesaByNome(_Search));
            }
        }

        Command _AddDespesaCommand;
        public Command AddDespesaCommand
        {
            get { return _AddDespesaCommand ?? (_AddDespesaCommand = new Command(async () => await ExecuteAddDespesaCommand())); }
        }

        async Task ExecuteAddDespesaCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new CadastroDespesaPage());
                IsBusy = false;
            }
        }

    }
}
