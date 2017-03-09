using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Carro.ViewModels;

namespace Carro.Pages
{
    public partial class EditarFuncionario : ContentPage
    {
        public EditarFuncionario(Funcionario value)
        {
            BindingContext = new EditarFuncionarioViewModel(Navigation, value);
            InitializeComponent();
        }
    }
}
