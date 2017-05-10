using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace Carro.Models
{
    public partial class OrdemVendaProduto
    {
        [PrimaryKey, AutoIncrement]
        public long? Id { get; set; }

        public long? IdOrdemVenda { get; set; }

        public long? IdProduto { get; set; }

        public string Nome { get; set; }

        public decimal Valor { get; set; }

        public int Quantidade { get; set; }

        public int QuantidadeVendida { get; set; }

        public string Marca { get; set; }

        public string Descricao { get; set; }

        public string Local { get; set; }

        [ManyToOne]
        public OrdemVenda OrdemVenda { get; set; }
    }
}
