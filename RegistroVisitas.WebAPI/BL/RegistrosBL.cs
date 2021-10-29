using Microsoft.EntityFrameworkCore;
using RegistroVisitas.WebAPI.Model;
using SharedAPIModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroVisitas.WebAPI.BL
{
    public class RegistrosBL
    {
        private readonly DataContext dataContext;
        public RegistrosBL(DataContext dataContext) => this.dataContext = dataContext;

        public async Task<bool> Entrada(Model.Visita visita)
        {
            dataContext.Visitas.Add(visita);
            var res = await dataContext.SaveChangesAsync();
            return res > 0;
        }

        public async Task<bool> Salida(Model.Visita visita)
        {
            var original = dataContext.Visitas.FirstOrDefault(v => v.Id == visita.Id);
            if (original != null)
            {
                original.FechaHoraDeSalida = visita.FechaHoraDeSalida;
                original.Notas = visita.Notas;
                var res = await dataContext.SaveChangesAsync();
                return res > 0;
            }
            return false;
        }

        public async Task<IEnumerable<Model.Visita>> Buscar(DateTime inicio, DateTime? final = null, string casa = "")
        {
            var fechaInicial = (final != null) ? inicio : new(inicio.Year, inicio.Month, inicio.Day, 0, 0, 0);
            var fechaFinal = (final != null) ? final : new(inicio.Year, inicio.Month, inicio.Day, 23, 59, 59);
            var query = from v in dataContext.Visitas
                      where v.FechaHoraDeEntrada >= fechaInicial &&
                      v.FechaHoraDeEntrada <= fechaFinal
                      select v;
            if (!string.IsNullOrEmpty(casa))
                query = from v in query
                      where v.CasaId == casa
                      select v;
            var res = await query.ToListAsync();
            return res;
        }
    }
}
