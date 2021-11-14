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
            await bl.Salida(new() { Id = visita.Id, FechaHoraDeSalida = visita.FechaHoraDeSalida, RecepcionistaDeSalida = visita.RecepcionistaDeSalida, Notas = visita.Notas });

        [HttpGet("Buscar")]
        public async Task<IEnumerable<SharedAPIModel.Visita>> GetVisitas(DateTime inicio, DateTime? final = null, string casa = "")
        {
            var res = await bl.Buscar(inicio, final, casa);
            return res.ToSharedModel();
        }

        [HttpGet("Eliminar")]
        public async Task<int> Eliminar(string token, DateTime inicio, DateTime? final = null, string casa = "")
        {
            if (token != "Fracc2751") return 0;
            return await bl.Eliminar(inicio, final, casa);
        }

        [HttpGet("EliminarTodo")]
        public async Task<int> Eliminar(string token)
        {
            if (token != "Fracc2751") return 0;
            return await bl.Eliminar();
        }

    }
}
