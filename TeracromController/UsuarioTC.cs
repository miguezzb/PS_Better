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
    }
}
