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
    public partial class EditarDespesaPage : ContentPage
    {
        public EditarDespesaPage(Despesa value)
        {
            BindingContext = new EditarDespesaViewModel(Navigation, value);
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            valorEntry.Text = "";
            categoriaEntry.Text = "";
        }
    }
}
