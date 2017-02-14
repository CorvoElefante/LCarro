using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace Carro.Models
{
    public partial class OrdemVenda
    {
        [PrimaryKey, AutoIncrement]
        public long? Id { get; set; }

        public bool eVenda { get; set; }

        public long IdOrdemVendaProduto { get; set; }

        public long IdOrdemVendaServico { get; set; }

        public long IdFuncionarioServico { get; set; }

        public long IdCliente { get; set; }

        public string Data { get; set; }

        public int Prazo { get; set; }

        public float Valor { get; set; }
    }
}

