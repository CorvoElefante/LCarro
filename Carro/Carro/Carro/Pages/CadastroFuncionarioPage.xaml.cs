using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carro.ViewModels;
using Xamarin.Forms;

namespace Carro.Pages
{
    public partial class CadastroFuncionarioPage : ContentPage
    {
        public CadastroFuncionarioPage()
        {
            BindingContext = new CadastroFuncionarioViewModel(Navigation);
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            salarioEntry.Text = "";
        }
    }
}
