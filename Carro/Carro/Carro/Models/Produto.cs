using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace Carro.Models
{
    public partial class Produto
    {
        [PrimaryKey, AutoIncrement]
        public long? Id { get; set; }

        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public int Quantidade { get; set; }

        public string Marca { get; set; }

        public string Descricao { get; set; }

        public string Local { get; set; }//Localizacao do produto na loja(estante, balcao, mostruario...)

    }
}
