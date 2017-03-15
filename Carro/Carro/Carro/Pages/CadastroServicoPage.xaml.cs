using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Carro.ViewModels;

namespace Carro.Pages
{
    public partial class CadastroServicoPage : ContentPage
    {
        public CadastroServicoPage()
        {
            BindingContext = new CadastroServicoViewModel(Navigation);
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            precoEntry.Text="";
        }
    }
}
