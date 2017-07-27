using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Carro.Models;
using System.Collections.Generic;
using Carro.Repositories;
using Carro.Services;
using System.Threading.Tasks;
using Carro.Pages;
using Carro.Pages.Help;

namespace Carro.ViewModels
{
    class ListaProdutoPerdaViewModel : BaseViewModel
    {

        public ListaProdutoPerdaViewModel(INavigation navigation) : base(navigation)
        {

        }

        ObservableCollection<Produto> _Produtos = new ObservableCollection<Produto>();
        public ObservableCollection<Produto> Produtos
        {
            get
            {
                return _Produtos;
            }
            set
            {
                _Produtos = value;
                SetPropertyChanged(nameof(Produtos));
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
                Produtos = new ObservableCollection<Produto>(new DataService(sqlite).FindProdutoByNome(_Search));
            }
        }

        Command _EnviaProdutoPerdaCommand;
        public Command EnviaProdutoPerdaCommand
        {
            get { return _EnviaProdutoPerdaCommand ?? (_EnviaProdutoPerdaCommand = new Command<Produto>(async (qq) => await ExecuteEnviaProdutoPerdaCommand(qq))); }
        }

        async Task ExecuteEnviaProdutoPerdaCommand(Produto value)
        {
            if (!IsBusy)
            {
                IsBusy = true;
                Navigation.PopAsync();
                await Navigation.PushAsync(new EditarProdutoPerdaPage(value));
                IsBusy = false;
            }
        }

        Command _HelpCommand;
        public Command HelpCommand
        {
            get { return _HelpCommand ?? (_HelpCommand = new Command(async () => await ExecuteHelpCommand())); }
        }

        async Task ExecuteHelpCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new ListaProdutoPerdaHelpPage());
                IsBusy = false;
            }
        }
    }
}
