namespace TeracromModels
{
    public class PSModels
    {
        public class Usuarios {

            public int IdUsuario { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Correo { get; set; }
            public string Contrasena { get; set; }
            public byte[] Imagen { get; set; }
            public string ImagenBase64 { get; set; }
        }

        public class Vehiculo
        {
            public int IdVehiculo { get; set; }
            public string Placas { get; set; }
            public int Tipo { get; set; }
        }

        public class RespuestaJson
        {
            public bool resultado { get; set; }
            public string mensaje { get; set; }
            public object data { get; set; }
            public object data2 { get; set; }
            public List<string> error { get; set; }
            public RespuestaJson()
            {
                resultado = false;
                mensaje = "";
                error = new List<string>();
            }
        }
    }
}
