using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistroVisitas.WebAPI.BL;
using RegistroVisitas.WebAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegistroVisitas.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SesionesController : ControllerBase
    {
        private readonly SesionesBL bl;
        public SesionesController(DataContext dataContext) => bl = new SesionesBL(dataContext);

        [HttpGet]
        public async Task<IEnumerable<SharedAPIModel.Sesion>> SesionesDelDia(int year, int month) =>
            (await bl.GetSesionesDelMesAsync(year, month)).ToSharedModel();

        [HttpPost]
        public async Task<bool> Autentificar(SharedAPIModel.Identificacion identificacion)
        {
            var res = await bl.ValidarCodigoAsync(identificacion.Id, identificacion.Codigo);
            if (res)
                res = await bl.RegistrarSesion(identificacion.Id, identificacion.Fecha);
            return res;
        }
    }
}
