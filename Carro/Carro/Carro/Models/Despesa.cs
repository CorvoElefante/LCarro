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

        public decimal Valor { get; set; }

        public int Categoria { get; set; }
        //0 = Selecione a categoria (Invalido)
        //1 = Alimentação
        //2 = Compra de produtos
        //3 = Funcionários
        //4 = Manutenção
        //5 = Materias de Escritório
        //6 = Materias de Limpeza
        //7 = Outros

        public DateTime Registro { get; set; }
    }
}
