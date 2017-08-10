using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace Carro.Models
{
    public partial class FuncionarioServico
    {
        [PrimaryKey, AutoIncrement]
        public long? Id { get; set; }

        [ForeignKey(typeof(OrdemVenda))]
        public long? IdOrdemVenda { get; set; }

        [ForeignKey(typeof(Funcionario))]
        public long? IdFuncionario { get; set; }

        [OneToOne (CascadeOperations = CascadeOperation.CascadeRead)]
        public Funcionario Funcionario { get; set; }

        [ManyToOne (CascadeOperations = CascadeOperation.CascadeRead)]
        public OrdemVenda OrdemVenda { get; set; }

    }
}

