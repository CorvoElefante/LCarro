using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carro.Models;
using Carro.ViewModels;
using Xamarin.Forms;

namespace Carro.Pages
{
    public partial class CadastroPerdaPage : ContentPage
    {
        public CadastroPerdaPage()
        {
            BindingContext = new CadastroPerdaViewModel(Navigation);
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

            if (((CadastroPerdaViewModel)BindingContext).RemoveProdutoCommand.CanExecute(null))
            {
                ((CadastroPerdaViewModel)BindingContext).RemoveProdutoCommand.Execute(mi.CommandParameter);
            }
            DisplayAlert("", "Item removido com sucesso", "OK");
        }
    }
}
