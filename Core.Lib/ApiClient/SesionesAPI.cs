using Core.Helpers;
using Sysne.Core.ApiClient;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.ApiClient
{
    internal class SesionesAPI : WebApiClient
    {
        public SesionesAPI() : base(Settings.Current.WebAPIUrl, "Sesiones") { }

        public async Task<(HttpStatusCode StatusCode, IEnumerable<SharedAPIModel.Recepcionista>)> GetRecepcionistasAsync() =>
            await CallGetAsync<IEnumerable<SharedAPIModel.Recepcionista>>("Recepcionistas");

        public async Task<(HttpStatusCode StatusCode, bool Válido)> AutentificarAsync(SharedAPIModel.Identificacion identificacion) =>
            await CallPostAsync<SharedAPIModel.Identificacion, bool>("", identificacion);

        public async Task<(HttpStatusCode StatusCode, IEnumerable<SharedAPIModel.Sesion>)> GetSesionesDelDia(int año, int mes) =>
            await CallGetAsync<IEnumerable<SharedAPIModel.Sesion>>("", ("year", año), ("month", mes));
    }
}
