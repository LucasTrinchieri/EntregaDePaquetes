﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Repartidor : Persona
    {
        public decimal Comision { get; set; }

        public decimal CalcularComision()
        {
            return Comision * ;
        }
    }
}
