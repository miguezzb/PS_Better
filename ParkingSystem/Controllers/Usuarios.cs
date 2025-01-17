using Microsoft.AspNetCore.Mvc;

namespace ParkingSystem.Controllers
{
    public class Usuarios : Controller
    {
        public IActionResult Login()
        {
            //string action = ControllerContext.RouteData.GetRequiredString("action");
            //ViewBag.url = Request.Host;
            return View();
        }
        public IActionResult Logout()
        {
            return View();
        }
    }
}
