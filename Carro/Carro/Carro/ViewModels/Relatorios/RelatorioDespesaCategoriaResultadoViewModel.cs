using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Carro.Models;
using System.Collections.Generic;
using Carro.Repositories;
using Carro.Services;
using System.Threading.Tasks;
using Carro.Pages.Relatorios;
using Carro.Pages.Help.RelatoriosHelp;

namespace Carro.ViewModels.Relatorios
{
    public class RelatorioDespesaCategoriaResultadoViewModel : BaseViewModel
    {
        public RelatorioDespesaCategoriaResultadoViewModel(INavigation navigation, RelatorioDespesaCategoriaSelecaoViewModel.CategoriaCompleta categoria) : base(navigation)
        {
            dataInicial = categoria.DataInicio;
            dataFinal = categoria.DataFinal;
            categoriaEntry = categoria.tipoCategoria;
            ExecuteListaDespesaCommand();

        }

        DateTime _dataInicial = System.DateTime.Today;
        public DateTime dataInicial
        {
            get
            {
                return _dataInicial;
            }
            set
            {
                _dataInicial = value;
                SetPropertyChanged(nameof(dataInicial));
            }
        }

        DateTime _dataFinal = System.DateTime.Now;
        public DateTime dataFinal
        {
            get
            {
                return _dataFinal;
            }
            set
            {
                _dataFinal = value;
                SetPropertyChanged(nameof(dataFinal));
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
                //0 = Selecione a categoria (Invalido)
                //1 = Alimentação
                //2 = Compra de produtos
                //3 = Funcionários
                //4 = Manutenção
                //5 = Materias de Escritório
                //6 = Materias de Limpeza
                //7 = Outros
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

        Command _ListaDespesaCommand;
        public Command ListaDespesaCommand
        {
            get { return _ListaDespesaCommand ?? (_ListaDespesaCommand = new Command(() => ExecuteListaDespesaCommand())); }
        }

        void ExecuteListaDespesaCommand()
        {

            var sqlite = DependencyService.Get<ISQLite>();
            using (var scope = new TransactionScope(sqlite))
            {
                Despesas = new ObservableCollection<Despesa>(
                    new DataService(sqlite).RelatorioDespesas(dataInicial, dataFinal, categoriaEntry)
                );
                scope.Complete();
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
                await Navigation.PushAsync(new RelatorioDespesaCategoriaResultadoHelpPage());
                IsBusy = false;
            }
        }
    }
}
