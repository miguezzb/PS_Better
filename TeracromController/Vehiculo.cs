using TeracromDatabase;
using TeracromModels;
using static TeracromModels.PSModels;

namespace TeracromController
{
    public class Vehiculo
    {
        private readonly IDatabaseService _databaseService;
        public Vehiculo(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        
        public async Task<RespuestaJson> GetVehiculo()
        {
            string sql = "SELECT IdVehiculo, Placas, Tipo;";
            var vehiculo = await _databaseService.QueryAsync<dynamic>(sql);
            return new RespuestaJson
            {
                resultado = true,
                data = vehiculo.Select(s => new
                {
                    IdVehiculo = s.IdVehiculo,
                    Placas = s.Placas,
                    Tipo = s.Tipo,
                }).ToList()
            };

        }
    }
}