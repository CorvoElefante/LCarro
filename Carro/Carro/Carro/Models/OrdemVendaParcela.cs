using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace Carro.Models
{
    public partial class OrdemVendaParcela
    {
        [PrimaryKey, AutoIncrement]
        public long? Id { get; set; }

        [ForeignKey(typeof(OrdemVenda))]
        public long? IdOrdemVenda { get; set; }

        public int  NumeroParcela { get; set; }

        public decimal ValorParcela { get; set; }

        public DateTime Vencimento { get; set; }

        public bool Pago { get; set; }

        [ManyToOne]
        public OrdemVenda OrdemVenda { get; set; }
    }
}
