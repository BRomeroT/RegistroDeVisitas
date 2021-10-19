using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class Calle
    {
        //https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#positional-patterns
        public Calle(string codigo, string prefijo = null, string nombre = "", string sufijo = null) =>
            (Codigo, Prefijo, Nombre, Sufijo) = (codigo, prefijo, nombre, sufijo);

        public string Codigo { get; set; }
        public string Prefijo { get; set; }
        public string Nombre { get; set; }
        public string Sufijo { get; set; }
    }
}
