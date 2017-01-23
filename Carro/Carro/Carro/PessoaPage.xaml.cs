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
                Nome = pessoanomeE.Text,
                RuaN = pessoaruaNE.Text,
                Bairro = pessoabairroE.Text,
                Cpf = pessoacpfE.Text,
                Telefone = pessoatelefoneE.Text,
                Data = pessoadataE.Text,
                Email = pessoaemailE.Text
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
