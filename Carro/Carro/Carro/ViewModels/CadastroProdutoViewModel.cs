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
    public class CadastroProdutoViewModel : BaseViewModel
    {

        public CadastroProdutoViewModel(INavigation navigation) : base(navigation)
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

        decimal _precoEntry = 0.0m;
        public decimal precoEntry
        {
            get
            {
                return _precoEntry;
            }
            set
            {
                _precoEntry = value;
                SetPropertyChanged(nameof(precoEntry));
                if (precoEntry <= 0)
                {
                    precoEntryInvalido = true;
                }
                else
                {
                    precoEntryInvalido = false;
                }
            }
        }

        bool _precoEntryInvalido = true;
        public bool precoEntryInvalido
        {
            get
            {
                return _precoEntryInvalido;
            }
            set
            {
                _precoEntryInvalido = value;
                SetPropertyChanged(nameof(precoEntryInvalido));
            }
        }

        int _quantidadeEntry = 0;
        public int quantidadeEntry
        {
            get
            {
                return _quantidadeEntry;
            }
            set
            {
                _quantidadeEntry = value;
                SetPropertyChanged(nameof(quantidadeEntry));
            }
        }

        string _marcaEntry = string.Empty;
        public string marcaEntry
        {
            get
            {
                return _marcaEntry;
            }
            set
            {
                _marcaEntry = value;
                SetPropertyChanged(nameof(marcaEntry));
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

        string _localEntry = string.Empty;
        public string localEntry
        {
            get
            {
                return _localEntry;
            }
            set
            {
                _localEntry = value;
                SetPropertyChanged(nameof(localEntry));
            }
        }

        Command _SalvarProdutoCommand;
        public Command SalvarProdutoCommand
        {
            get { return _SalvarProdutoCommand ?? (_SalvarProdutoCommand = new Command(async () => await ExecuteSalvarProdutoCommand())); }
        }

        async Task ExecuteSalvarProdutoCommand()
        {
            if (!(nomeEntry == string.Empty || precoEntry <= 0))
            {
                if (!IsBusy)
                {
                    IsBusy = true;

                    var sqlite = DependencyService.Get<ISQLite>();
                    using (var scope = new TransactionScope(sqlite))
                    {
                        var service = new DataService(sqlite);
                        DateTime data = DateTime.UtcNow;
                        service.SaveProduto(new Produto { Nome = nomeEntry, Preco = precoEntry, Quantidade = quantidadeEntry, Marca = marcaEntry, Descricao = descricaoEntry, Local = localEntry, Registro = data });
                        scope.Complete();
                    }
                    await Navigation.PopAsync();
                    IsBusy = false;
                }
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
                await Navigation.PushAsync(new CadastroProdutoHelpPage());
                IsBusy = false;
            }
        }
    }
}
