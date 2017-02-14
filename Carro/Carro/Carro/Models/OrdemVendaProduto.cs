using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace Carro.Models
{
    public partial class OrdemVendaProduto
    {
        [PrimaryKey, AutoIncrement]
        public long? Id { get; set; }

        public long IdOrdemVenda { get; set; }

        public long IdProduto { get; set; }

        public float Valor { get; set; }

        public int Quantidade { get; set; }
    }
}
