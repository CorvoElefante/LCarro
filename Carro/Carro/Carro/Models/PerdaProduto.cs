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

        [ForeignKey(typeof(Produto))]
        public long? IdProduto { get; set; }

        [OneToOne]
        public Produto Produto { get; set; }

        public int Quantidade { get; set; }

        [ManyToOne]
        public Perda Perda { get; set; }
    }
}