using Core.ApiClient;
using Core.Model;
using Sysne.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

using System.Net;

namespace Core.BL
{
    internal class RegistroBL : ObservableObject
    {
        private readonly RegistroAPI webAPI = new();
        public async Task<bool> RegistrarVisita(Visita visita)
        {
            var (StatusCode, Registrado) = await webAPI.Registrar(visita);
            return StatusCode == HttpStatusCode.OK && Registrado;
        }
        public async Task<IEnumerable<Visita>> VisitaActivas()
        {
            var (StatusCode, Visitas) = await webAPI.GetVisitasActias();
            return StatusCode == HttpStatusCode.OK ? Visitas.ToModel(): new List<Visita>();
        }

        public async Task<bool> RegistrarSalida(Visita visita){
            var (StatusCode, res) = await webAPI.Salida(visita);
            return StatusCode== HttpStatusCode.OK && res;
        }

    }
}
