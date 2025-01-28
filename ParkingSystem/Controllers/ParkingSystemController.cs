using Microsoft.AspNetCore.Mvc;
using TeracromController;
using TeracromDatabase;
using TeracromModels;
using static TeracromModels.PSModels;

namespace ParkingSystem.Controllers
{
    public class ParkingSystemController : Controller
    {
        private readonly IDatabaseService _databaseService;

        public ParkingSystemController(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        [HttpPost]
        public async Task<RespuestaJson> GetVehiculo()
        {
            RespuestaJson respuesta = await new Vehiculos(_databaseService).GetVehiculo();
            return respuesta;
        }

        [HttpPost]
        public async Task<RespuestaJson> GetUsuarios()
        {
            RespuestaJson respuesta = await new UsuarioTC(_databaseService).GetUsuarios();
            return respuesta;
        }

        [HttpPost]
        public async Task<RespuestaJson> PostUsuario([FromBody] PSModels.Usuarios ususario)
        {
            RespuestaJson respuesta = await new UsuarioTC(_databaseService).PostUsuario(ususario);
            return respuesta;
        }

        [HttpPost]
        public async Task<RespuestaJson> GetEntradasSalidas()
        {
            RespuestaJson respuesta = await new EntradasSalidasTC(_databaseService).GetEntradasSalidas();
            return respuesta;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}