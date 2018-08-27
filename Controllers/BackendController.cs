using Microsoft.AspNetCore.Mvc;

namespace Dotnet.Controllers {
    public class BackendController : Controller {

        public IActionResult Index() {
            return View();
        }
    }
}