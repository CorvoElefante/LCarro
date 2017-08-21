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
    public class EditarFinalVendaPagarParcelasViewModel : BaseViewModel
    {

        public EditarFinalVendaPagarParcelasViewModel(INavigation navigation, OrdemVendaParcela value) : base(navigation){

            Parcela = value;
        }

        OrdemVendaParcela _Parcela = new OrdemVendaParcela();
        public OrdemVendaParcela Parcela
        {
            get
            {
                return _Parcela;
            }
            set
            {
                _Parcela = value;
                SetPropertyChanged(nameof(Parcela));
            }
        }

        Command _PagaParcelaCommand;
        public Command PagaParcelaCommand
        {
            get { return _PagaParcelaCommand ?? (_PagaParcelaCommand = new Command(async () => await ExecutePagaParcelaCommand())); }
        }

        async Task ExecutePagaParcelaCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;

                var sqlite = DependencyService.Get<ISQLite>();
                using (var scope = new TransactionScope(sqlite))
                {
                    var service = new DataService(sqlite);

                    service.PagaParcela(Parcela.IdOrdemVenda, Parcela.Id);
                    scope.Complete();
                }
                await Navigation.PopAsync();
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
                await Navigation.PushAsync(new EditarFinalVendaPagarParcelasHelpPage());
                IsBusy = false;
            }
        }
    }
}
