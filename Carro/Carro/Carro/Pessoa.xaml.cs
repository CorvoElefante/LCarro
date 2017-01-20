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
            using (var dados = new AcessoDados())
            {
                Lista.ItemsSource = dados.Listar();
            }
        }
        protected void SalvarClicked(object sender, EventArgs e)
        {
            var pessoa = new Pessoa()
            {
                nome = this.Nome.Text,
                ruaN = this.RuaN.Text,
                bairro = this.Bairro.Text,
                cpf = this.Cpf.Text,
                telefone = this.Telefone.Text,
                data = this.Data.Text,
                email = this.Email.Text
            };
           using(var dados = new AcessoDados())
            {
                dados.Insert(pessoa);
                Lista.ItemsSource = dados.Listar();
            }
        }
    }
}
