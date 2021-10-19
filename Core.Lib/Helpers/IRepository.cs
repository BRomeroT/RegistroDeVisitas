using Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Helpers
{
    public interface IRepository
    {
        List<Recepcionista> GetRecepcionistas();
        List<Calle> GetCalles();
        List<int> GetNumeros(string calleCodigo = null);
        List<string> GetLetras();

        bool GuardarVisita(Visita visita);
        List<Visita> GetVisitas(DateTime? fecha = null);
        List<Visita> GetVisitasDeHoy();
    }
}
