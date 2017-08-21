using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Carro.ViewModels;
using Carro.Models;
using System.Collections.ObjectModel;

namespace Carro.Pages
{
    public partial class EditarFinalVendaParcelaPage : ContentPage
    {
        public EditarFinalVendaParcelaPage(long? value)
        {
            BindingContext = new EditarFinalVendaParcelaViewModel(Navigation, value);
            InitializeComponent();
        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            if (e == null)
            {
                return; // has been set to null, do not 'process' tapped event 
            }

            if (((EditarFinalVendaParcelaViewModel)BindingContext).PagarParcelasCommand.CanExecute(null))
            {
                ((EditarFinalVendaParcelaViewModel)BindingContext).PagarParcelasCommand.Execute(((ListView)sender).SelectedItem);
            }
            ((ListView)sender).SelectedItem = null; // de-select the row
        }

        protected override void OnAppearing()
        {
            if (((EditarFinalVendaParcelaViewModel)BindingContext).BuscaParcelasCommand.CanExecute(null))
            {
                ((EditarFinalVendaParcelaViewModel)BindingContext).BuscaParcelasCommand.Execute(null);
            }
            base.OnAppearing();
        }
    }
}