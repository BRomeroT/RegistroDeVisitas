using Core.ApiClient;
using Core.Model;
using Sysne.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Core.BL
{
    internal class RegistroBL : ObservableObject
    {
        private readonly RegistroAPI webAPI = new();
        public async Task<bool> RegistrarVisita(Visita visita)
        {
            var (StatusCode, Registrado) = await webAPI.Registrar(visita);
            return StatusCode == System.Net.HttpStatusCode.OK && Registrado;
        }
    }
}
