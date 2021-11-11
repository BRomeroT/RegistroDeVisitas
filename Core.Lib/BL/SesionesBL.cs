using Core.ApiClient;
using Sysne.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.BL
{
    public class SesionesBL:ObservableObject
    {
        private readonly SesionesAPI webAPI = new();
        public async Task<IEnumerable<Model.Recepcionista>> Recepcionistas()
        {
            var (StatusCode, Recepcionistas) = await webAPI.GetRecepcionistasAsync();
            return StatusCode == HttpStatusCode.OK ? Recepcionistas.ToModel() : new List<Model.Recepcionista>();
        }

        public async Task<bool> Iniciar(int id, string codigo)
        {
            var (StatusCode, Válido) = await webAPI.AutentificarAsync(new()
            {
                Id=id,
                Codigo=codigo, 
                Fecha=DateTime.Now
            });
            return StatusCode == HttpStatusCode.OK && Válido;
        }

        public async Task<IEnumerable<Model.Sesion>> GetSesionsDe(int año, int mes)
        {
            var (StatusCode, Sesiones) = await webAPI.GetSesionesDelDia(año, mes);
            return StatusCode == HttpStatusCode.OK ? Sesiones.ToModel() : new List<Model.Sesion>();
        }
    }
}
