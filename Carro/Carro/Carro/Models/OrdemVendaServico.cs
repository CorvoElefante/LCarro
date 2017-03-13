using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace Carro.Models
{
    public partial class OrdemVendaServico
    {
        [PrimaryKey, AutoIncrement]
        public long? Id { get; set; }

        public long? IdOrdemVenda { get; set; }

        [ForeignKey(typeof(Servico))]
        public long IdServico { get; set; }

        [OneToOne]
        public Servico Servico { get; set; }

        public float Valor { get; set; }

        public int Quantidade { get; set; }

        [ManyToOne]
        public OrdemVenda OrdemVenda { get; set; }
    }
}
