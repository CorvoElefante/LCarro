using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Carro
{
    public partial class Pessoa : ContentPage
    {
        public Pessoa()
        {
            InitializeComponent();
        }
        protected void SalvarClicked(object sender, EventArgs e)
        {
            var pessoa = new Pessoa
            {
                nome = nome,
                endereco = endereco,
                telefone = telefone,
                email = email,
                ndata = telefone,
                cpf = cpf
            };
        }
    }
}
