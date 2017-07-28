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
    public class EditarPerdaViewModel : BaseViewModel
    {

        public EditarPerdaViewModel(INavigation navigation, Perda value) : base(navigation)
        {

            var sqlite = DependencyService.Get<ISQLite>();
            nomeEntry = value.Nome;
            justificativaEntry = value.Justificativa;

            ProdutosPerdidos = value.PerdaProdutos;

        }

        List<PerdaProduto> _ProdutosPerdidos = new List<PerdaProduto>();
        public List<PerdaProduto> ProdutosPerdidos
        {
            get
            {
                return _ProdutosPerdidos;
            }
            set
            {
                _ProdutosPerdidos = value;
                SetPropertyChanged(nameof(ProdutosPerdidos));
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
                await Navigation.PushAsync(new EditarPerdaHelpPage());
                IsBusy = false;
            }
        }
    }
}
