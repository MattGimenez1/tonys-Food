using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Vistas
{
    public class TestMercadoPago
    {
        // ⚠️ Reemplazá esto por tu Access Token real (el que empieza con APP_USR-...)
        private static readonly string AccessToken = "ACA access token";

        public static async Task<string> ProbarConexion()
        {
            using (HttpClient cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("Authorization", "Bearer " + AccessToken);

                // Le pedimos los últimos pagos recibidos (orden más reciente primero)
                string url = "https://api.mercadopago.com/v1/payments/search?sort=date_created&criteria=desc&limit=5";

                HttpResponseMessage respuesta = await cliente.GetAsync(url);
                string contenido = await respuesta.Content.ReadAsStringAsync();

                if (!respuesta.IsSuccessStatusCode)
                {
                    return "ERROR: " + respuesta.StatusCode + "\n" + contenido;
                }

                JObject json = JObject.Parse(contenido);
                int totalResultados = (int)json["paging"]["total"];

                return "Conexión exitosa. Total de pagos en tu cuenta: " + totalResultados;
            }
        }
            public static async Task<string> ObtenerUltimoPago()
        {
            using (HttpClient cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("Authorization", "Bearer " + AccessToken);

                string url = "https://api.mercadopago.com/v1/payments/search?sort=date_created&criteria=desc&limit=1";

                HttpResponseMessage respuesta = await cliente.GetAsync(url);
                string contenido = await respuesta.Content.ReadAsStringAsync();

                if (!respuesta.IsSuccessStatusCode)
                {
                    return "ERROR: " + respuesta.StatusCode + "\n" + contenido;
                }

                JObject json = JObject.Parse(contenido);
                JArray resultados = (JArray)json["results"];

                if (resultados.Count == 0)
                {
                    return "No hay pagos registrados.";
                }

                JToken pago = resultados[0];

                long id = (long)pago["id"];
                decimal monto = (decimal)pago["transaction_amount"];
                string estado = (string)pago["status"];
                string fecha = (string)pago["date_created"];

                string nombrePagador = "Desconocido";
                JToken payer = pago["payer"];
                if (payer != null)
                {
                    string nombre = (string)payer["first_name"];
                    string apellido = (string)payer["last_name"];
                    if (!string.IsNullOrEmpty(nombre) || !string.IsNullOrEmpty(apellido))
                        nombrePagador = (nombre + " " + apellido).Trim();
                    else if (payer["email"] != null)
                        nombrePagador = (string)payer["email"];
                }

                return "Id: " + id +
                       "\nMonto: $" + monto.ToString("N0") +
                       "\nEstado: " + estado +
                       "\nFecha: " + fecha +
                       "\nPagador: " + nombrePagador;
            }
        }
        public static async Task<JToken> ObtenerUltimoPagoRaw()
        {
            using (HttpClient cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("Authorization", "Bearer " + AccessToken);
                string url = "https://api.mercadopago.com/v1/payments/search?sort=date_created&criteria=desc&limit=1";

                HttpResponseMessage respuesta = await cliente.GetAsync(url);
                if (!respuesta.IsSuccessStatusCode) return null;

                string contenido = await respuesta.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(contenido);
                JArray resultados = (JArray)json["results"];

                return resultados.Count > 0 ? resultados[0] : null;
            }
        }
    }
}