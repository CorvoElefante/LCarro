﻿using System;
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
    public class EditarClienteViewModel : BaseViewModel
    {

        public EditarClienteViewModel(INavigation navigation, Pessoa value) : base(navigation)
        {

            var sqlite = DependencyService.Get<ISQLite>();
            idEntry = value.Id;
            nomeEntry = value.Nome;
            ruaNEntry = value.RuaN;
            bairroEntry = value.Bairro;
            telefoneEntry = value.Telefone;
            emailEntry = value.Email;
            ndataEntry = value.Data;
            cpfEntry = value.Cpf;
            pessoaEntry = value;

        }

        Pessoa _pessoaEntry;
        public Pessoa pessoaEntry
        {
            get
            {
                return _pessoaEntry;
            }
            set
            {
                _pessoaEntry = value;
                SetPropertyChanged(nameof(pessoaEntry));
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
                if (nomeEntry != string.Empty)
                {
                    nomeEntryInvalido = false;
                }
                else
                {
                    nomeEntryInvalido = true;
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

        string _ruaNEntry = string.Empty;
        public string ruaNEntry
        {
            get
            {
                return _ruaNEntry;
            }
            set
            {
                _ruaNEntry = value;
                SetPropertyChanged(nameof(ruaNEntry));
            }
        }

        string _bairroEntry = string.Empty;
        public string bairroEntry
        {
            get
            {
                return _bairroEntry;
            }
            set
            {
                _bairroEntry = value;
                SetPropertyChanged(nameof(bairroEntry));
            }
        }

        string _telefoneEntry = string.Empty;
        public string telefoneEntry
        {
            get
            {
                return _telefoneEntry;
            }
            set
            {
                _telefoneEntry = value;
                SetPropertyChanged(nameof(telefoneEntry));
            }
        }

        string _emailEntry = string.Empty;
        public string emailEntry
        {
            get
            {
                return _emailEntry;
            }
            set
            {
                _emailEntry = value;
                SetPropertyChanged(nameof(emailEntry));
            }
        }

        DateTime _ndataEntry = DateTime.MinValue;
        public DateTime ndataEntry
        {
            get
            {
                return _ndataEntry;
            }
            set
            {
                _ndataEntry = value;
                SetPropertyChanged(nameof(ndataEntry));
            }
        }

        string _cpfEntry = string.Empty;
        public string cpfEntry
        {
            get
            {
                return _cpfEntry;
            }
            set
            {
                _cpfEntry = value;
                SetPropertyChanged(nameof(cpfEntry));
            }
        }

        Command _SalvarClienteCommand;
        public Command SalvarClienteCommand
        {
            get { return _SalvarClienteCommand ?? (_SalvarClienteCommand = new Command(async () => await ExecuteSalvarClienteCommand())); }
        }

        async Task ExecuteSalvarClienteCommand()
        {
            if (nomeEntry != string.Empty)
            {
                if (!IsBusy)
                {
                    IsBusy = true;

                    var sqlite = DependencyService.Get<ISQLite>();
                    using (var scope = new TransactionScope(sqlite))
                    {
                        var service = new DataService(sqlite);

                        service.SavePessoa(new Pessoa { Id = idEntry, Nome = nomeEntry, RuaN = ruaNEntry, Bairro = bairroEntry, Telefone = telefoneEntry, Email = emailEntry, Data = ndataEntry, Cpf = cpfEntry });
                        scope.Complete();
                    }
                    await Navigation.PopAsync();
                    IsBusy = false;
                }
                else
                {
                    nomeEntry = string.Empty;
                }
            }

        }

        Command _DeletarClienteCommand;
        public Command DeletarClienteCommand
        {
            get { return _DeletarClienteCommand ?? (_DeletarClienteCommand = new Command(async () => await ExecuteDeletarClienteCommand())); }
        }

        async Task ExecuteDeletarClienteCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;

                var sqlite = DependencyService.Get<ISQLite>();
                using (var scope = new TransactionScope(sqlite))
                {
                    var service = new DataService(sqlite);

                    service.DeletePessoa(pessoaEntry);
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
                await Navigation.PushAsync(new EditarClienteHelpPage());
                IsBusy = false;
            }
        }
    }
}
