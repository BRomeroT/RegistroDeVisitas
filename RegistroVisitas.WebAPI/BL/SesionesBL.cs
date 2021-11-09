using Microsoft.EntityFrameworkCore;
using RegistroVisitas.WebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroVisitas.WebAPI.BL
{
    public class SesionesBL
    {
        private readonly DataContext dataContext;
        public SesionesBL(DataContext dataContext) => this.dataContext = dataContext;

        public async Task<IEnumerable<Recepcionista>> GetRecepcionistasAsync() =>
            await dataContext.Recepcionistas.OrderBy(r => r.Nombre).ToListAsync();

        public async Task<bool> ValidarCodigoAsync(int id, string codigo) =>
            await dataContext.Recepcionistas.Where(r => r.Id == id && r.Codigo == codigo).AnyAsync();

        public async Task<bool> RegistrarSesion(int id, DateTime fecha)
        {
            var recepcionista = await dataContext.Recepcionistas.FindAsync(id);
            if (recepcionista != null)
            {
                await dataContext.Sesiones.AddAsync(new()
                {
                    Recepcionista = recepcionista.Nombre,
                    Fecha = fecha
                });
                return await dataContext.SaveChangesAsync() == 1;
            }
            return false;
        }

        public async Task<IEnumerable<Sesion>> GetSesionesDelMesAsync(int year, int month)
        {
            var fechaInicial = new DateTime(year, month, 1, 0, 0, 0);
            var fechaFinal = new DateTime(year, month, DateTime.DaysInMonth(year,month), 23, 59, 59);
            var query = from s in dataContext.Sesiones
                        where s.Fecha >= fechaInicial && s.Fecha <= fechaFinal
                        orderby s.Fecha descending
                        select s;
            return await query.ToListAsync();
        }
    }
}
