using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace Carro.Models
{
    public partial class OrdemVendaServico
    {
        [PrimaryKey, AutoIncrement]
        public long? Id { get; set; }

        public long IdOrdemVenda { get; set; }

        public long IdServico { get; set; }

        public float Valor { get; set; }

        public int Quantidade { get; set; }

    }
}
