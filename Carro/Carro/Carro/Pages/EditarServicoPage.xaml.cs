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
    public partial class EditarServicoPage : ContentPage
    {
        public EditarServicoPage(Servico value)
        {
            BindingContext = new EditarServicoViewModel(Navigation, value);
            InitializeComponent();
        }
    }
}
