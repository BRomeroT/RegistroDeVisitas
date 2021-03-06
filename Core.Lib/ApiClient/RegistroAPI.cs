using Core.Helpers;
using Sysne.Core.ApiClient;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.ApiClient
{
    internal class RegistroAPI : WebApiClient
    {
        public RegistroAPI() : base(Settings.Current.WebAPIUrl, "Visitas") { }

        public async Task<(HttpStatusCode StatusCode, bool Registrado)> Registrar(SharedAPIModel.Visita visita) =>
            await CallPostAsync<SharedAPIModel.Visita, bool>("", visita);

        public async Task<(HttpStatusCode StatusCode, IEnumerable<SharedAPIModel.Visita>)> GetVisitasActias() =>
            await CallGetAsync<IEnumerable<SharedAPIModel.Visita>>("");

        public async Task<(HttpStatusCode StatusCode, bool Registrado)> Salida(SharedAPIModel.Visita visita) =>
            await CallPostAsync<SharedAPIModel.Visita, bool>("Salida", visita);

        public async Task<(HttpStatusCode StatusCode, IEnumerable<SharedAPIModel.Visita>)> Buscar(DateTime inicio, DateTime? final = null, string casa = "") =>
            await CallGetAsync<IEnumerable<SharedAPIModel.Visita>>("Buscar", ("inicio", inicio), ("final", final), ("casa", casa));
    }
}
