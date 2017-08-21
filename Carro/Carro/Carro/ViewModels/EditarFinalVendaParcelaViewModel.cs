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

        public EditarFinalVendaParcelaViewModel(INavigation navigation, long? value) : base(navigation)
        {
            IdOrdemVenda = value;
            ExecuteBuscaParcelasCommand();
        }

        long? _IdOrdemVenda = 0;
        public long? IdOrdemVenda
        {
            get
            {
                return _IdOrdemVenda;
            }
            set
            {
                _IdOrdemVenda = value;
                SetPropertyChanged(nameof(IdOrdemVenda));
            }
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

        Command _BuscaParcelasCommand;
        public Command BuscaParcelasCommand
        {
            get { return _BuscaParcelasCommand ?? (_BuscaParcelasCommand = new Command(() => ExecuteBuscaParcelasCommand())); }
        }

        public void ExecuteBuscaParcelasCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;

                var sqlite = DependencyService.Get<ISQLite>();
                using (var scope = new TransactionScope(sqlite))
                {
                    var service = new DataService(sqlite);

                    OrdemVendaParcelas = new ObservableCollection<OrdemVendaParcela>(service.BuscaParcelas(IdOrdemVenda));

                    foreach (OrdemVendaParcela parc in OrdemVendaParcelas)
                    {
                        if (parc.Pago == true)
                        {
                            parc.Cor = "Green";
                        }
                        else
                        {
                            if (parc.Vencimento < DateTime.UtcNow)
                            {
                                parc.Cor = "Red";
                            }
                            else
                            {
                                parc.Cor = "Blue";
                            }
                        }
                    }
                }

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
