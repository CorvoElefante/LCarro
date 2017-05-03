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
    public class CadastroDespesaViewModel : BaseViewModel
    {

        public CadastroDespesaViewModel(INavigation navigation) : base(navigation)
        {

            var sqlite = DependencyService.Get<ISQLite>();

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
                if (nomeEntry == string.Empty)
                {
                    nomeEntryInvalido = true;
                }
                else
                {
                    nomeEntryInvalido = false;
                }
            }
        }

        bool _nomeEntryInvalido = true;
        public bool nomeEntryInvalido
        {
            get
            {
                return _nomeEntryInvalido;
            }
            set
            {
                _nomeEntryInvalido = value;
                SetPropertyChanged(nameof(nomeEntryInvalido));
            }
        }

        decimal _valorEntry = 0.0m;
        public decimal valorEntry
        {
            get
            {
                return _valorEntry;
            }
            set
            {
                _valorEntry = value;
                SetPropertyChanged(nameof(valorEntry));
                if(valorEntry <= 0)
                {
                    valorEntryInvalido = true;
                }else
                {
                    valorEntryInvalido = false;
                }
            }
        }

        bool _valorEntryInvalido = true;
        public bool valorEntryInvalido
        {
            get
            {
                return _valorEntryInvalido;
            }
            set
            {
                _valorEntryInvalido = value;
                SetPropertyChanged(nameof(valorEntryInvalido));
            }
        }

        string _descricaoEntry = string.Empty;
        public string descricaoEntry
        {
            get
            {
                return _descricaoEntry;
            }
            set
            {
                _descricaoEntry = value;
                SetPropertyChanged(nameof(descricaoEntry));
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
                if (categoriaEntry == 0)
                {
                    categoriaEntryInvalido = true;
                }
                else
                {
                    categoriaEntryInvalido = false;
                }
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

        bool _categoriaEntryInvalido = true;
        public bool categoriaEntryInvalido
        {
            get
            {
                return _categoriaEntryInvalido;
            }
            set
            {
                _categoriaEntryInvalido = value;
                SetPropertyChanged(nameof(categoriaEntryInvalido));
                //0 = Selecione a categoria (Invalido)
            }
        }

        Command _SalvarDespesaCommand;
        public Command SalvarDespesaCommand
        {
            get { return _SalvarDespesaCommand ?? (_SalvarDespesaCommand = new Command(async () => await ExecuteSalvarDespesaCommand())); }
        }

        async Task ExecuteSalvarDespesaCommand()
        {
            if (!(nomeEntry == string.Empty || valorEntry <= 0 || categoriaEntry == 0))
            {
                if (!IsBusy)
                {
                    IsBusy = true;

                    var sqlite = DependencyService.Get<ISQLite>();
                    using (var scope = new TransactionScope(sqlite))
                    {
                        var service = new DataService(sqlite);
                        DateTime data = DateTime.Now;
                        service.SaveDespesa(new Despesa { Nome = nomeEntry, Valor = valorEntry, Descricao = descricaoEntry, Categoria = categoriaEntry, Registro = data });
                        scope.Complete();
                    }
                    await Navigation.PopAsync();
                    IsBusy = false;
                }
            }            
        }
    }
}
