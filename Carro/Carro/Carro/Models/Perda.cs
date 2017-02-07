﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace Carro.Models
{
    public partial class Perda
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int Quantidade { get; set; }

        public string Justificativa { get; set; }
    }
}