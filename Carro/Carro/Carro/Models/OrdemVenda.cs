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

        public int PrazoInicial { get; set; }

        public int NumeroParcelas { get; set; }

        public decimal Valor { get; set; }

        public DateTime Registro { get; set; }

        public decimal DescontoTotal { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<FuncionarioServico> FuncionarioServicos { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<OrdemVendaProduto> OrdemVendaProdutos { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<OrdemVendaServico> OrdemVendaServicos { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<OrdemVendaParcela> OrdemVendaParcela { get; set; }
    }
}

