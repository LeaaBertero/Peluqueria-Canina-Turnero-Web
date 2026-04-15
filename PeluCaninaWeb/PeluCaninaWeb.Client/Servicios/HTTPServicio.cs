
using PeluCaninaWeb.Client.Servicios;
using System.Text;
using System.Text.Json;

namespace PeluCaninaWeb.Client.Servicios
{
    public class HTTPServicio : IHTTPServicio
    {
        private readonly HttpClient http;

        #region Constructor
        public HTTPServicio(HttpClient http)
        {
            this.http = http;
        }
        #endregion

        #region Servicio Get
        public async Task<HTTPRespuesta<T>> Get<T>(string url)
        {
            var response = await http.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var respuesta = await DesSerializar<T>(response);
                return new HTTPRespuesta<T>(respuesta, false, response);
            }
            else
            {
                return new HTTPRespuesta<T>(default, true, response);
            }
        }
        #endregion

        #region Servicio Post
        public async Task<HTTPRespuesta<object>> Post<T>(string url, T entidad)
        {
            var enviarJson = JsonSerializer.Serialize(entidad);

            var enviarContent = new StringContent(enviarJson,
                                Encoding.UTF8,
                                "application/json");

            var response = await http.PostAsync(url, enviarContent);
            if (response.IsSuccessStatusCode)
            {
                var respuesta = await DesSerializar<object>(response);
                return new HTTPRespuesta<object>(respuesta, false, response);
            }
            else
            {
                return new HTTPRespuesta<object>(default, true, response);
            }
        }
        #endregion

        #region Servicio Put
        public async Task<HTTPRespuesta<object>> Put<T>(string url, T entidad)
        {
            var enviarJson = JsonSerializer.Serialize(entidad);

            var enviarContent = new StringContent(enviarJson,
                                Encoding.UTF8,
                                "application/json");

            var response = await http.PutAsync(url, enviarContent);
            if (response.IsSuccessStatusCode)
            {
                //var respuesta = await DesSerializar<object>(response);
                return new HTTPRespuesta<object>(null, false, response);
            }
            else
            {
                return new HTTPRespuesta<object>(default, true, response);
            }
        }
        #endregion

        #region Servicio Delete
        public async Task<HTTPRespuesta<object>> Delete(string url)
        {
            var respuesta = await http.DeleteAsync(url);
            return new HTTPRespuesta<object>(null,
                                             !respuesta.IsSuccessStatusCode,
                                             respuesta);
        }
        #endregion

        #region Servicio DesSerializar
        private async Task<T?> DesSerializar<T>(HttpResponseMessage response)
        {
            var respuestaStr = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(respuestaStr,
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
        #endregion
    }
}
