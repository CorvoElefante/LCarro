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
    public class OpcaoViewModel : BaseViewModel
    {
        public OpcaoViewModel(INavigation navigation) : base(navigation)
        {

        }

        Command _BackupPageCommand;
        public Command BackupPageCommand
        {
            get { return _BackupPageCommand ?? (_BackupPageCommand = new Command(async () => await ExecuteBackupPageCommand())); }
        }

        async Task ExecuteBackupPageCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new OpcaoBackupPage());
                IsBusy = false;
            }
        }

        Command _OpcaoSobreCommand;
        public Command OpcaoSobreCommand
        {
            get { return _OpcaoSobreCommand ?? (_OpcaoSobreCommand = new Command(async () => await ExecuteOpcaoSobreCommand())); }
        }

        async Task ExecuteOpcaoSobreCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new OpcaoSobrePage());
                IsBusy = false;
            }
        }
    }
}
