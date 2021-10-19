using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class Recepcionista
    {
        public Recepcionista(int id = 0, string nombre = "") => (Id, Nombre) = (id, nombre);
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
