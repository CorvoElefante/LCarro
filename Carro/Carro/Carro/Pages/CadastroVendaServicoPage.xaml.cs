using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Carro.ViewModels;
using Carro.Models;

namespace Carro.Pages
{
    public partial class CadastroVendaServicoPage : ContentPage
    {
        public CadastroVendaServicoPage(CadastroVendaViewModel vendaViewModel)
        {
            BindingContext = vendaViewModel;
            InitializeComponent();
        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            if (e == null)
            {
                return; // has been set to null, do not 'process' tapped event 
            }
            ((ListView)sender).SelectedItem = null; // de-select the row
        }

        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);

            if (((CadastroVendaViewModel)BindingContext).RemoveServicoCommand.CanExecute(null))
            {
                ((CadastroVendaViewModel)BindingContext).RemoveServicoCommand.Execute(mi.CommandParameter);
            }
            DisplayAlert("", "Serviço removido com sucesso", "OK");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
