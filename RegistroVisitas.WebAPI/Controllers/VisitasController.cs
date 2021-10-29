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
        public async Task<IEnumerable<SharedAPIModel.Visita>> GetVisitas(DateTime inicio, DateTime? final = null, string casa = "") =>
            (IEnumerable<SharedAPIModel.Visita>)await bl.Buscar(inicio, final, casa);
    }
}
