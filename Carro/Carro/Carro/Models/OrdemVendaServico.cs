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

        [ForeignKey(typeof(OrdemVenda))]
        public long? IdOrdemVenda { get; set; }

        public long? IdServico { get; set; }

        public string Nome { get; set; }

        public decimal Valor { get; set; }

        public int QuantidadeVendida { get; set; }

        public string Descricao { get; set; }

        public string Tempo { get; set; }

        public decimal Desconto { get; set; }

        [ManyToOne]
        public OrdemVenda OrdemVenda { get; set; }
    }
}
