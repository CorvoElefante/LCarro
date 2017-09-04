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
    public class OpcaoBackupViewModel : BaseViewModel
    {
        public OpcaoBackupViewModel(INavigation navigation) : base(navigation)
        {

        }

        Command _RealizarBackupCommand;
        public Command RealizarBackupCommand
        {
            get { return _RealizarBackupCommand ?? (_RealizarBackupCommand = new Command(async () => await ExecuteRealizarBackupCommand())); }
        }

        async Task ExecuteRealizarBackupCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                bool ok;
                var sqlite = DependencyService.Get<ISQLite>();
                ok = sqlite.BackupDBTo();

                IsBusy = false;
            }
        }

        Command _ImportarBackupCommand;
        public Command ImportarBackupCommand
        {
            get { return _ImportarBackupCommand ?? (_ImportarBackupCommand = new Command(async () => await ExecuteImportarBackupCommand())); }
        }

        async Task ExecuteImportarBackupCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;

                IsBusy = false;
            }
        }
    }
}
