using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace Carro.Models
{
    public partial class Perda
    {
        [PrimaryKey, AutoIncrement]
        public long? Id { get; set; }

        public string Nome { get; set; }

        public string Justificativa { get; set; }

        public int Quantidade { get; set; }

        [ForeignKey(typeof(Produto))]
        public long IdProduto { get; set; }

        [OneToOne]
        public Produto Produto { get; set; }
    }
}
