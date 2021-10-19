using Core.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class RepositorioDeVisitas : IRepository
    {
        public List<Calle> GetCalles() => new()
        {
            new("RM", "Real de", "Minas"),
            new("RO", "Real de", "Oro"),
            new("RP", "Real de", "Plata")
        };

        public List<string> GetLetras() => new() { "A", "B", "C", "D" };

        public List<int> GetNumeros(string calleCodigo = null)
        {
            var res = new List<int>();
            var max = calleCodigo switch
            {
                "RM" => 17,
                "R0" => 32,
                "RP" => 12,
                _ => 33
            };
            for (int i = 1; i <= max; i++)
                res.Add(i);
            return res;
        }

        public List<Recepcionista> GetRecepcionistas() => new()
        {
            new(1, "Benjamín"),
            new(2, "David"),
            new(3, "Gustavo"),
            new(4, "Mario"),
            new(5, "Martha"),
            new(6, "Pedro"),
            new(7, "Apoyo")
        }
;
        public List<Visita> GetVisitas(DateTime? fecha = null)
        {
            throw new NotImplementedException();
        }

        public List<Visita> GetVisitasDeHoy()
        {
            throw new NotImplementedException();
        }

        public bool GuardarVisita(Visita visita)
        {
            throw new NotImplementedException();
        }
    }
}
