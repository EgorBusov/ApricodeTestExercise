using Microsoft.AspNetCore.Mvc;

namespace GameApi.Controllers
{
    public class GameController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
