using System;
using Newtonsoft.Json;

namespace webapiejer.Models
{
    public class Empleados
    {
        [JsonProperty("idEmpleado")]
        public int idEmpleado { get; set; }
        [JsonProperty("apellido")]
        public String apellido { get; set; }
        [JsonProperty("oficio")]
        public String oficio { get; set; }
        [JsonProperty("salario")]
        public String salario { get; set; }

    }
}
