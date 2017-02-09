using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace Carro.Models
{
    public partial class Funcionario
    {
        [PrimaryKey, AutoIncrement]
        public long? Id { get; set; }

        public float Salario { get; set; }

        public string Funcao { get; set; }
    }
}
