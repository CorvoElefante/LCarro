using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Carro.Models;
using System.Collections.Generic;
using Carro.Repositories;
using Carro.Services;
using System.Threading.Tasks;
using Carro.Pages.Relatorios;

namespace Carro.ViewModels.Relatorios
{
    public class RelatorioProdutoValorTotalEstoqueResultadoViewModel : BaseViewModel
    {

        public RelatorioProdutoValorTotalEstoqueResultadoViewModel(INavigation navigation) : base(navigation)
        {

            ExecuteValorTotalEstoqueCommand();

        }

        decimal _valorTotal = 0m;
        public decimal valorTotal
        {
            get
            {
                return _valorTotal;
            }
            set
            {
                _valorTotal = value;
                SetPropertyChanged(nameof(valorTotal));
            }
        }

        Command _ValorTotalEstoqueCommand;
        public Command ValorTotalEstoqueCommand
        {
            get { return _ValorTotalEstoqueCommand ?? (_ValorTotalEstoqueCommand = new Command(() => ExecuteValorTotalEstoqueCommand())); }
        }

                void ExecuteValorTotalEstoqueCommand()
        {

            var sqlite = DependencyService.Get<ISQLite>();
            using (var scope = new TransactionScope(sqlite))
            {
                valorTotal = new DataService(sqlite).RelatorioValorTotalEstoque();
                scope.Complete();
            }

        }

    }
}
