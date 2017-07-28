using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Carro.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged, IDisposable
    {

        public BaseViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }

        public INavigation Navigation { get; set; }

        bool _IsBusy = false;
        public bool IsBusy
        {
            get { return _IsBusy; }
            set
            {
                _IsBusy = value;
                SetPropertyChanged(nameof(IsBusy));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal void SetPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void Dispose()
        {
            // Limpa quaisquer eventos subscritos ao PropertyChanged
            if (PropertyChanged == null)
            {
                return;
            }
            var invocationList = PropertyChanged.GetInvocationList();
            foreach (var invocation in invocationList)
            {
                PropertyChanged -= (PropertyChangedEventHandler)invocation;
            }
        }

        Command _VoltaCommand;
        public Command VoltaCommand
        {
            get { return _VoltaCommand ?? (_VoltaCommand = new Command(async () => await ExecuteVoltaCommand())); }
        }

        async Task ExecuteVoltaCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PopAsync();
                IsBusy = false;
            }
        }
    }
}
