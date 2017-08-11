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
    public class EditarFinalVendaParcelaViewModel : BaseViewModel
    {

        public EditarFinalVendaParcelaViewModel(INavigation navigation) : base(navigation){

        }

        ObservableCollection<OrdemVendaParcela> _OrdemVendaParcelas = new ObservableCollection<OrdemVendaParcela>();
        public ObservableCollection<OrdemVendaParcela> OrdemVendaParcelas
        {
            get
            {
                return _OrdemVendaParcelas;
            }
            set
            {
                _OrdemVendaParcelas = value;
                SetPropertyChanged(nameof(OrdemVendaParcelas));
            }
        }

        Command _PagarParcelasCommand;
        public Command PagarParcelasCommand
        {
            get { return _PagarParcelasCommand ?? (_PagarParcelasCommand = new Command<OrdemVendaParcela>(async (qq) => await ExecutePagarParcelasCommand(qq))); }
        }

        async Task ExecutePagarParcelasCommand(OrdemVendaParcela qq)
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new EditarFinalVendaPagarParcelasPage(qq));
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
                await Navigation.PushAsync(new EditarFinalVendaParcelaHelpPage());
                IsBusy = false;
            }
        }
    }
}
