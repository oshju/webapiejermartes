using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using webapiejer.Models;

namespace webapiejer.Helpers
{
    public class HelperEmpleadosAzure
    {
        private const string DireccionApi = "https://apiempleadospgs.azurewebsites.net/";

        private HttpClient CrearCliente()
        {
            HttpClient clientehttp = new HttpClient();
            clientehttp.DefaultRequestHeaders.Accept.Clear();
            clientehttp.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return clientehttp;
        }


        public async Task<List<Empleados>> GetEmpleados()
        {
            List<Empleados> listadatos = null;
            //CREAMOS LA PETICION 
            String peticion = DireccionApi + "api/Empleados";
            var uri = new Uri(string.Format(peticion, string.Empty));
            HttpClient client = CrearCliente();
            var respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                listadatos = JsonConvert.DeserializeObject<List<Empleados>>(contenido);
            }
            return listadatos;
        }


    }
}
