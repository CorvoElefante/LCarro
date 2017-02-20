using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace Carro.Models
{
    public partial class Despesa
    {
        [PrimaryKey, AutoIncrement]
        public long? Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public float Valor { get; set; }

        [ForeignKey(typeof(Categoria))]
        public long IdCategoria { get; set; }

        [OneToOne]
        public Categoria Categoria { get; set; }
    }
}
