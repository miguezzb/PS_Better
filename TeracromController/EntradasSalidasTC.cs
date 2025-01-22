using TeracromDatabase;
using TeracromModels;
using static TeracromModels.PSModels;

namespace TeracromController
{
    public class EntradasSalidasTC
    {
        private readonly IDatabaseService _databaseService;
        public EntradasSalidasTC(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<RespuestaJson> GetEntradasSalidas()
        {
            RespuestaJson respuesta = new RespuestaJson();

            try
            {
                string sql = "SELECT IdEntrada_Salida, Folio, FechaEntrada, FechaSalida FROM Entradas_Salidas;";
                var entradaSalida = await _databaseService.QueryAsync<dynamic>(sql);

                respuesta.resultado = true;
                respuesta.data = entradaSalida.Select(s => new Entradas_Salidas
                {
                    IdEntrada_Salida = s.IdEntrada_Salida,
                    Folio = s.Folio,
                    FechaEntrada = s.FechaEntrada,
                    FechaSalida = s.FechaSalida
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