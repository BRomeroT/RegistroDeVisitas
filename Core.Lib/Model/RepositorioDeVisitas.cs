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
            new("RP", "Real de", "Plata"),
            new("RS", "Fracionamiento real de", "Santa Clara")
        };

        public List<string> GetLetras() => new() { "A", "B", "C", "D" };

        public List<int> GetNumeros(string calleCodigo)
        {
            var res = new List<int>();
            var max = calleCodigo switch
            {
                "RM" => 17,
                "RO" => 32,
                "RP" => 12,
                "RS" => 1,
                _ => 0
            };
            for (int i = 1; i <= max; i++)
                res.Add(i);
            return res;
        }

        public List<Recepcionista> GetRecepcionistas() => throw new NotImplementedException();
        //    new()
        //{
        //    new(1, "Benjamín"),
        //    new(2, "David"),
        //    new(3, "Gustavo"),
        //    new(4, "Mario"),
        //    new(5, "Martha"),
        //    new(5, "Montse"),
        //    new(6, "Pedro"),
        //    new(7, "--Otro--")
        //}

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
