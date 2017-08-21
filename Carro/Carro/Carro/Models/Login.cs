using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace Carro.Models
{
    public partial class Login
    {
        [PrimaryKey, AutoIncrement]
        public long? Id { get; set; }

        public DateTime Vencimento { get; set; }
    }
}
