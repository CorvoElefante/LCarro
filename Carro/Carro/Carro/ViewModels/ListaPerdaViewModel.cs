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
    public class ListaPerdaViewModel : BaseViewModel
    {

        public ListaPerdaViewModel(INavigation navigation) : base(navigation)
        {

            var sqlite = DependencyService.Get<ISQLite>();
            ExecuteAtualizaPerdaCommand();

        }

        ObservableCollection<Perda> _Perdas = new ObservableCollection<Perda>();
        public ObservableCollection<Perda> Perdas
        {
            get
            {
                return _Perdas;
            }
            set
            {
                _Perdas = value;
                SetPropertyChanged(nameof(Perdas));
            }
        }

        public class ListaProduto
        {
            public long? Id { get; set; }

            public string Nome { get; set; }

            public float Preco { get; set; }

            public int Quantidade { get; set; }

            public string Marca { get; set; }

            public string Descricao { get; set; }

            public string Local { get; set; }

            public int QuantidadePerdida { get; set; }
        }

        public class ListaProdutoPerda
        {
            public long? Id { get; set; }

            public string Nome { get; set; }

            public string Justificativa { get; set; }

            public ObservableCollection<ListaProduto> ListaProduto = new ObservableCollection<ListaProduto>();
        }

        ObservableCollection<ListaProdutoPerda> _ListaProdutoPerdas =  new ObservableCollection<ListaProdutoPerda>();
        public ObservableCollection<ListaProdutoPerda> ListaProdutoPerdas
        {
            get
            {
                return _ListaProdutoPerdas;
            }
            set
            {
                _ListaProdutoPerdas = value;
                SetPropertyChanged(nameof(ListaProdutoPerdas));
            }
        }

        string _Search = string.Empty;
        public string Search
        {
            get { return _Search; }
            set
            {
                _Search = value;
                var sqlite = DependencyService.Get<ISQLite>();
                Perdas = new ObservableCollection<Perda>(new DataService(sqlite).FindPerdaByNome(_Search));
            }
        }

        Command _AddPerdaCommand;
        public Command AddPerdaCommand
        {
            get { return _AddPerdaCommand ?? (_AddPerdaCommand = new Command(async () => await ExecuteAddPerdaCommand())); }
        }

        async Task ExecuteAddPerdaCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new CadastroPerdaPage());
                IsBusy = false;
            }
        }

        Command _AtualizaPerdaCommand;
        public Command AtualizaPerdaCommand
        {
            get { return _AtualizaPerdaCommand ?? (_AtualizaPerdaCommand = new Command(() => ExecuteAtualizaPerdaCommand())); }
        }

        void ExecuteAtualizaPerdaCommand()
        {

            var sqlite = DependencyService.Get<ISQLite>();
            using (var scope = new TransactionScope(sqlite))
            {
                Perdas = new ObservableCollection<Perda>(new DataService(sqlite).FindPerdaByNome(""));
                scope.Complete();
            }

        }

        Command _EditarPerdaCommand;
        public Command EditarPerdaCommand
        {
            get { return _EditarPerdaCommand ?? (_EditarPerdaCommand = new Command<Perda>(async (qq) => await ExecuteEditarPerdaCommand(qq))); }
        }

        async Task ExecuteEditarPerdaCommand(Perda value)
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new EditarPerdaPage(value));
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
                await Navigation.PushAsync(new ListaPerdaHelpPage());
                IsBusy = false;
            }
        }
    }
}
