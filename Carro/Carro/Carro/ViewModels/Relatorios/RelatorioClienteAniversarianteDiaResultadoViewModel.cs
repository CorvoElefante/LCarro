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
    public class RelatorioClienteAniversarianteDiaResultadoViewModel : BaseViewModel
    {
        public RelatorioClienteAniversarianteDiaResultadoViewModel(INavigation navigation) : base(navigation)
        {
            ExecuteAtualizaPessoaCommand();
            ExecuteAtualizaAniversariantesCommand();
        }

        ObservableCollection<Pessoa> _Pessoas = new ObservableCollection<Pessoa>();
        public ObservableCollection<Pessoa> Pessoas
        {
            get
            {
                return _Pessoas;
            }
            set
            {
                _Pessoas = value;
                SetPropertyChanged(nameof(Pessoas));
            }
        }

        ObservableCollection<Pessoa> _Aniversariantes = new ObservableCollection<Pessoa>();
        public ObservableCollection<Pessoa> Aniversariantes
        {
            get
            {
                return _Aniversariantes;
            }
            set
            {
                _Aniversariantes = value;
                SetPropertyChanged(nameof(Aniversariantes));
            }
        }

        DateTime _ndataEntry = new DateTime(2000, 1, 1);
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

        Command _AtualizaPessoaCommand;
        public Command AtualizaPessoaCommand
        {
            get { return _AtualizaPessoaCommand ?? (_AtualizaPessoaCommand = new Command(() => ExecuteAtualizaPessoaCommand())); }
        }

        void ExecuteAtualizaPessoaCommand()
        {

            var sqlite = DependencyService.Get<ISQLite>();
            using (var scope = new TransactionScope(sqlite))
            {
                Pessoas = new ObservableCollection<Pessoa>(
                    new DataService(sqlite).GetPessoas()
                );
                scope.Complete();
            }

        }

        Command _AtualizaAniversariantesCommand;
        public Command AtualizaAniversariantesCommand
        {
            get { return _AtualizaAniversariantesCommand ?? (_AtualizaAniversariantesCommand = new Command(() => ExecuteAtualizaAniversariantesCommand())); }
        }

        void ExecuteAtualizaAniversariantesCommand()
        {

            foreach (Pessoa pessoa in Pessoas)
            {
                if(pessoa.Data.Day == DateTime.Today.Day && pessoa.Data.Month == DateTime.Today.Month && pessoa.Data != ndataEntry)
                {
                    Aniversariantes.Add(pessoa);
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
                await Navigation.PushAsync(new RelatorioClienteAniversarianteDiaResultadoHelpPage());
                IsBusy = false;
            }
        }
    }
}
