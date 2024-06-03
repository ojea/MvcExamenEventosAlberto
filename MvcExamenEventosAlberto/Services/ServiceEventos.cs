using MvcExamenEventosAlberto.Models;
using System.Net.Http.Headers;

namespace MvcExamenEventosAlberto.Services
{
    public class ServiceEventos
    {
        private MediaTypeWithQualityHeaderValue header;
        private string UrlApi;

        public ServiceEventos(IConfiguration configuration)
        {
            this.UrlApi = configuration.GetValue<string>("ApiUrls:ApiEventosAWS");
            this.header = new MediaTypeWithQualityHeaderValue ("application/json");
        }

        private async Task<T> CallApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())

            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response =
                    await client.GetAsync(this.UrlApi + request);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<List<Eventos>> GetEventosAsync()
        {
            string request = "api/Eventos";
            List<Eventos> data =
                await this.CallApiAsync<List<Eventos>>(request);
            return data;
        }

        public async Task<List<CategoriasEvento>> GetCategoriasAsync()
        {
            string request = "/api/Eventos/GetCategoria";
            List<CategoriasEvento> data =
                await this.CallApiAsync<List<CategoriasEvento>>(request);
            return data;
        }

        public async Task<List<Eventos>>FindEventoCategoria(int id)

        {

            string request = "/api/Eventos/Find/" + id;

            List<Eventos> data =
                await this.CallApiAsync<List<Eventos>>(request);
            return data;

        }
    }
}
