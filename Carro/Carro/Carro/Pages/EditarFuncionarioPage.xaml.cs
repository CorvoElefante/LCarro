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
    public partial class EditarFuncionarioPage : ContentPage
    {
        public EditarFuncionarioPage(Funcionario value)
        {
            BindingContext = new EditarFuncionarioViewModel(Navigation, value);
            InitializeComponent();
        }
    }
}
