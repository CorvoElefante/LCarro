using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Carro
{
    public partial class PessoaPage : ContentPage
    {
        public PessoaPage()
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
                Nome = nomeEntry.Text,
                RuaN = ruaNEntry.Text,
                Bairro = bairroEntry.Text,
                Cpf = cpfEntry.Text,
                Telefone = telefoneEntry.Text,
                Data = dataEntry.Text,
                Email = emailEntry.Text
            };
           using(var dados = new AcessoDados())
            {
                dados.Insert(pessoa);
                //dados.Commit();
                Lista.ItemsSource = dados.Listar();
            }
        }

    }
}
