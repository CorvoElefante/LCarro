using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace Carro.Models
{
    public partial class PerdaProduto
    {
        [PrimaryKey, AutoIncrement]
        public long? Id { get; set; }

        [ForeignKey(typeof(Perda))]
        public long? IdPerda { get; set; }

        public long? IdProduto { get; set; }

        public string Nome { get; set; }

        public float Preco { get; set; }

        public int QuantidadePerdida { get; set; }

        public string Marca { get; set; }

        public string Descricao { get; set; }

        public string Local { get; set; }

        [ManyToOne]
        public Perda Perda { get; set; }
    }
}