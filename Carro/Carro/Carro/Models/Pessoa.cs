using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace Carro
{
    public partial class Pessoa
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string RuaN { get; set; }

        public string Bairro { get; set; }

        public string Cpf { get; set; }

        public string Telefone { get; set; }

        public string Data { get; set; }

        public string Email { get; set; }
    }
}
