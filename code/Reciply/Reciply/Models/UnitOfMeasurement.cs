using System;
using System.Collections.Generic;
using System.Text;

namespace Reciply.Models
{
    public enum UnitOfMeasurement
    {
        //Standards
        kg,
        dag,
        g,
        l,
        ml,

        //Sonderfälle
        Pkg,
        Stück,
        Esslöffel,
        Teelöffel,
        Prise
    }
}
