using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistroVisitas.WebAPI.BL;
using RegistroVisitas.WebAPI.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegistroVisitas.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VisitasController : ControllerBase
    {
        private readonly RegistrosBL bl;

        public VisitasController(DataContext dataContext) => bl = new(dataContext);

        [HttpPost]
        public async Task<bool> Registrar(SharedAPIModel.Visita visita) =>
            await bl.Entrada(visita);

        [HttpGet]
        public async Task<IEnumerable<SharedAPIModel.Visita>> GetVisitasActivas()
        {
            var res = await bl.VisitasActivas();
            return res.ToSharedModel();
        }

        [HttpPost("Salida")]
        public async Task<bool> Salida(SharedAPIModel.Visita visita) =>
            await bl.Salida(new() { Id = visita.Id, FechaHoraDeSalida = visita.FechaHoraDeSalida, Notas = visita.Notas });

        [HttpGet("Buscar")]
        public async Task<IEnumerable<SharedAPIModel.Visita>> GetVisitas(DateTime inicio, DateTime? final = null, string casa = "")
        {
            var res = await bl.Buscar(inicio, final, casa);
            IEnumerable<SharedAPIModel.Visita> Visitas()
            {
                foreach (var visita in res)
                    yield return visita;
            }
            return Visitas();
        }
    }
}
