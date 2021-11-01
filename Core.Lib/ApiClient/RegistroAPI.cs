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
    }
}
