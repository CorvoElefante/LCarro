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
    public partial class EditarProdutoPage : ContentPage
    {
        public EditarProdutoPage(Produto value)
        {
            BindingContext = new EditarProdutoViewModel(Navigation, value);
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            precoEntry.Text = "";
        }
    }
}
