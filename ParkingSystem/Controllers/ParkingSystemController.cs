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
            RespuestaJson respuesta = await new Vehiculo(_databaseService).GetVehiculo();
            return respuesta;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}