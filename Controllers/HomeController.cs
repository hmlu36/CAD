using System.Diagnostics;
using Dotnet.Models.Web;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller {
   

    public HomeController() {
        
    }

    public IActionResult Index () {

        return View ();
    }

    [Route ("/error")]
    [ResponseCache (Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error () {

        return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}