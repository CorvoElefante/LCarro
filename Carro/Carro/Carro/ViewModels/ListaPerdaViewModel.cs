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
    public class ListaPerdaViewModel : BaseViewModel
    {

        public ListaPerdaViewModel(INavigation navigation) : base(navigation)
        {

            var sqlite = DependencyService.Get<ISQLite>();

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
                await Navigation.PushAsync(new CadastroPerdaPage());
                IsBusy = false;
            }
        }

    }
}
