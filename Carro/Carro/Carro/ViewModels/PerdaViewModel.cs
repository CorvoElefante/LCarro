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
    public class PerdaViewModel : BaseViewModel
    {

        public PerdaViewModel(INavigation navigation) : base(navigation)
        {

            var sqlite = DependencyService.Get<ISQLite>();
            using (var scope = new TransactionScope(sqlite))
            {
                Perdas = new ObservableCollection<Perda>(
                    new DataService(sqlite).GetPerdas()
                );
                scope.Complete();
            }

        }
        ObservableCollection<Perda> _Perdas;
        public ObservableCollection<Perda> Perdas
        {
            get
            {
                return _Perdas;
            }
            set
            {
                _Perdas = value;
                SetPropertyChanged(nameof(Perdas));
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

        int _quantidadeEntry = 0;
        public int quantidadeEntry
        {
            get
            {
                return _quantidadeEntry;
            }
            set
            {
                _quantidadeEntry = value;
                SetPropertyChanged(nameof(quantidadeEntry));
            }
        }

        string _justificativaEntry = string.Empty;
        public string justificativaEntry
        {
            get
            {
                return _justificativaEntry;
            }
            set
            {
                _justificativaEntry = value;
                SetPropertyChanged(nameof(justificativaEntry));
            }
        }
        
        Command _SalvarPerdaCommand;
        public Command SalvarPerdaCommand
        {
            get { return _SalvarPerdaCommand ?? (_SalvarPerdaCommand = new Command(async () => await ExecuteSalvarPerdaCommand())); }
        }

        async Task ExecuteSalvarPerdaCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;

                var sqlite = DependencyService.Get<ISQLite>();
                using (var scope = new TransactionScope(sqlite))
                {
                    var service = new DataService(sqlite);

                    service.SavePerda(new Perda { Nome = nomeEntry, Quantidade = quantidadeEntry, Justificativa = justificativaEntry});
                    scope.Complete();
                }

                using (var scope = new TransactionScope(sqlite))
                {
                    Perdas = new ObservableCollection<Perda>(
                        new DataService(sqlite).GetPerdas()
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
                Perdas = new ObservableCollection<Perda>(new DataService(sqlite).FindPerdaByNome(_Search));
            }
        }

        Command _AddPerdaCommand;
        public Command AddPerdaCommand
        {
            get { return _AddPerdaCommand ?? (_AddPerdaCommand = new Command(async () => await ExecuteAddPerdaCommand())); }
        }

        async Task ExecuteAddPerdaCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new CadastroClientePage());
                IsBusy = false;
            }
        }

    }
}
