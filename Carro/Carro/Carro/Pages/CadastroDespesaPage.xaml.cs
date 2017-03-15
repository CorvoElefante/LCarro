using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carro.ViewModels;
using Xamarin.Forms;

namespace Carro.Pages
{
    public partial class CadastroDespesaPage : ContentPage
    {
        public CadastroDespesaPage()
        {
            BindingContext = new CadastroDespesaViewModel(Navigation);
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
