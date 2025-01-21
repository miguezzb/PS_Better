using TeracromDatabase;
using TeracromModels;
using static TeracromModels.PSModels;

namespace TeracromController
{
    public class Vehiculos
    {
        private readonly IDatabaseService _databaseService;
        public Vehiculos(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        
        public async Task<RespuestaJson> GetVehiculo()
        {
            RespuestaJson respuesta = new RespuestaJson();

            try
            {
                string sql = "SELECT IdVehiculo, Placas, Tipo FROM Vehiculo;";
                var vehiculo = await _databaseService.QueryAsync<dynamic>(sql);

                respuesta.resultado = true;
                respuesta.data = vehiculo.Select(s => new Vehiculo
                {
                    IdVehiculo = s.IdVehiculo,
                    Placas = s.Placas,
                    Tipo = s.Tipo,
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