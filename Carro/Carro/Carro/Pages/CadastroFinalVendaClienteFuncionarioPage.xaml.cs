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
    public partial class CadastroFinalVendaClienteFuncionarioPage : ContentPage
    {
        public CadastroFinalVendaClienteFuncionarioPage()
        {
            BindingContext = new CadastroFinalVendaViewModel(Navigation);
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

            if (((CadastroFinalVendaViewModel)BindingContext).RemoveFuncionarioCommand.CanExecute(null))
            {
                ((CadastroFinalVendaViewModel)BindingContext).RemoveFuncionarioCommand.Execute(mi.CommandParameter);
            }
            DisplayAlert("", "Funcionário removido com sucesso", "OK");
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    pessoaSelecionadaLabel.Text = ((CadastroVendaViewModel)BindingContext).pessoaSelecionada?.Nome;
        //}
    }
}
