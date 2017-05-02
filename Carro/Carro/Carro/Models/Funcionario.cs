using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace Carro.Models
{
    public partial class Funcionario
    {
        [PrimaryKey, AutoIncrement]
        public long? Id { get; set; }

        public decimal Salario { get; set; }

        public string Funcao { get; set; }

        [ForeignKey(typeof(Pessoa))]
        public long? PessoaId { get; set; }

        [OneToOne]
        public Pessoa Pessoa { get; set; }

        public DateTime Registro { get; set; }
    }
}
