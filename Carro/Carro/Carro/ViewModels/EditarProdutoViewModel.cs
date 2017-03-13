﻿using System;
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

        public EditarProdutoViewModel(INavigation navigation) : base(navigation)
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
            if (!IsBusy)
            {
                IsBusy = true;

                var sqlite = DependencyService.Get<ISQLite>();
                using (var scope = new TransactionScope(sqlite))
                {
                    var service = new DataService(sqlite);

                    service.SaveProduto(new Produto { Nome = nomeEntry, Marca = marcaEntry, Descricao = descricaoEntry, Local = localEntry });
                    scope.Complete();
                }
                IsBusy = false;
            }
        }
    }
}
