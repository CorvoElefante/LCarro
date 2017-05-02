using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace Carro.Models
{
    public partial class OrdemVenda
    {
        [PrimaryKey, AutoIncrement]
        public long? Id { get; set; }

        public bool eVenda { get; set; }

        [ForeignKey(typeof(Pessoa))]
        public long? IdCliente { get; set; }

        [OneToOne]
        public Pessoa Pessoa { get; set; }

        public string Data { get; set; }

        public int Prazo { get; set; }

        public float Valor { get; set; }

        public DateTime Registro { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<FuncionarioServico> FuncionarioServicos { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<OrdemVendaProduto> OrdemVendaProdutos { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<OrdemVendaServico> OrdemVendaServicos { get; set; }
    }
}

