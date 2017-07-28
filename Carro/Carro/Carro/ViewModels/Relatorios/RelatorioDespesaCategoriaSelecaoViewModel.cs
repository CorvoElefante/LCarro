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
    public class RelatorioDespesaCategoriaSelecaoViewModel : BaseViewModel
    {
        public RelatorioDespesaCategoriaSelecaoViewModel(INavigation navigation) : base(navigation)
        {


        }

        public class CategoriaCompleta
        {
            public DateTime DataInicio;
            public DateTime DataFinal;
            public int tipoCategoria;
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

        DateTime _dataFinal = DateTime.UtcNow;
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

        Command _RelDespesaCommand;
        public Command RelDespesaCommand
        {
            get { return _RelDespesaCommand ?? (_RelDespesaCommand = new Command(async () => await ExecuteRelDespesaCommand())); }
        }

        async Task ExecuteRelDespesaCommand()
        {
            if (!IsBusy)
            {
                CategoriaCompleta categoria = new CategoriaCompleta();
                categoria.DataInicio = dataInicial;
                categoria.DataFinal = dataFinal;
                categoria.tipoCategoria = categoriaEntry;
                IsBusy = true;
                await Navigation.PushAsync(new RelatorioDespesaCategoriaResultadoPage(categoria));
                IsBusy = false;
            }
        }
    }
}
