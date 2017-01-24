﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace Carro.Models
{
    public partial class Despesa
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public float Valor { get; set; }

        public string Categoria { get; set; }// Materiais, escritório...
    }
}
