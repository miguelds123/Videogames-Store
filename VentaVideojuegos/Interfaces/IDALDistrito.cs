﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaVideojuegos.Layers.Entities;

namespace VentaVideojuegos.Interfaces
{
    interface IDALDistrito
    {
        List<Distrito> GetAllProvincia();
    }
}
