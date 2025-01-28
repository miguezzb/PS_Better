using TeracromDatabase;
using TeracromModels;
using static TeracromModels.PSModels;

namespace TeracromController
{
    public class UsuarioTC
    {
        private readonly IDatabaseService _databaseService;
        public UsuarioTC(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<RespuestaJson> GetUsuarios()
        {
            RespuestaJson respuesta = new RespuestaJson();

            try
            {
                string sql = "SELECT IdUsuario, Nombre, Apellido, Correo, Imagen FROM Usuarios;";
                var usuario = await _databaseService.QueryAsync<dynamic>(sql);

                respuesta.resultado = true;
                respuesta.data = usuario.Select(s => new Usuarios
                {
                    IdUsuario = s.IdUsuario,
                    Nombre = s.Nombre,
                    Apellido = s.Apellido,
                    Correo = s.Correo,
                    Imagen = s.Imagen
                }).ToList();
            }
            catch (Exception ex)
            {
                respuesta.mensaje = "Ocurrió un error: " + ex.Message;
            }
            return respuesta;
        }

        public async Task<RespuestaJson> PostUsuario(Usuarios usuario)
        {
            RespuestaJson respuesta = new RespuestaJson();
            try
            {
                string sql = @"INSERT INTO Usuarios (Nombre, Apellido, Correo, Contrasena Imagen) 
                       VALUES (@Nombre, @Apellido, @Correo, @Contrasena, @Imagen);";

                var parametros = new
                {
                    Nombre = usuario.Nombre,
                    Apellido = usuario.Apellido,
                    Correo = usuario.Correo,
                    Contrasena = usuario.Contrasena,
                    Imagen = usuario.Imagen
                };

                var resultado = await _databaseService.ExecuteAsync(sql, parametros);

                if (resultado > 0)
                {
                    respuesta.resultado = true;
                    respuesta.mensaje = "Usuario insertado correctamente.";
                }
                else
                {
                    respuesta.resultado = false;
                    respuesta.mensaje = "No se pudo insertar el usuario.";
                }
            }
            catch (Exception ex)
            {
                respuesta.resultado = false;
                respuesta.mensaje = "Ocurrió un error: " + ex.Message;
            }
            return respuesta;
        }
    }
}
