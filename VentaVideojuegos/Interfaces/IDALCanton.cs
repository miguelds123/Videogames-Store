﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaVideojuegos.Layers.Entities;

namespace VentaVideojuegos
{
    interface IDALCanton
    {
        List<Canton> GetAllCanton();
    }
}
