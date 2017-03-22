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
    public class EditarProdutoViewModel : BaseViewModel
    {

        public EditarProdutoViewModel(INavigation navigation, Produto value) : base(navigation)
        {
            var sqlite = DependencyService.Get<ISQLite>();

            idEntry = value.Id;
            nomeEntry = value.Nome;
            precoEntry = value.Preco;
            quantidadeEntry = value.Quantidade;
            marcaEntry = value.Marca;
            descricaoEntry = value.Descricao;
            localEntry = value.Local;
            produtoEntry = value;
    }

        Produto _produtoEntry;
        public Produto produtoEntry
        {
            get
            {
                return _produtoEntry;
            }
            set
            {
                _produtoEntry = value;
                SetPropertyChanged(nameof(produtoEntry));
            }
        }

        long? _idEntry = 0;
        public long? idEntry
        {
            get
            {
                return _idEntry;
            }
            set
            {
                _idEntry = value;
                SetPropertyChanged(nameof(idEntry));
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

        float _precoEntry = 0.0F;
        public float precoEntry
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

        int _quantidadeAdicionadaEntry = 0;
        public int quantidadeAdicionadaEntry
        {
            get
            {
                return _quantidadeAdicionadaEntry;
            }
            set
            {
                _quantidadeAdicionadaEntry = value;
                SetPropertyChanged(nameof(quantidadeAdicionadaEntry));
                quantidadeTotalEntry = quantidadeEntry + quantidadeAdicionadaEntry;
            }
        }

        int _quantidadeTotalEntry;
        public int quantidadeTotalEntry
        {
            get
            {
                return _quantidadeTotalEntry;
            }
            set
            {
                _quantidadeTotalEntry = value;
                SetPropertyChanged(nameof(quantidadeTotalEntry));
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

                        service.SaveProduto(new Produto { Id = idEntry, Nome = nomeEntry, Preco = precoEntry, Quantidade = (quantidadeEntry + quantidadeAdicionadaEntry), Marca = marcaEntry, Descricao = descricaoEntry, Local = localEntry });
                        scope.Complete();
                    }
                    await Navigation.PopAsync();
                    IsBusy = false;
                }
            }
                
        }

        Command _DeletarProdutoCommand;
        public Command DeletarProdutoCommand
        {
            get { return _DeletarProdutoCommand ?? (_DeletarProdutoCommand = new Command(async () => await ExecuteDeletarProdutoCommand())); }
        }

        async Task ExecuteDeletarProdutoCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;

                var sqlite = DependencyService.Get<ISQLite>();
                using (var scope = new TransactionScope(sqlite))
                {
                    var service = new DataService(sqlite);

                    service.DeleteProduto(produtoEntry);
                    scope.Complete();
                }
                await Navigation.PopAsync();
                IsBusy = false;
            }
        }
    }
}
