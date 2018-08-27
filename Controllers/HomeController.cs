using System;
using System.Diagnostics;
using Dotnet.Models.Web;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller {
   

    public HomeController() {
        
    }

    public IActionResult Index () {

        return View ();
    }
    /*

    [HttpGet("Carousel")]
    public JsonResult Carousel() {

        var result = carouselService.GetAll(carousel => "Y".Equals(carousel.Status));
        return Json(result);
    }

    [HttpGet("ProductCategories")]
    public JsonResult ProductCategories() {

        var result = new List<DdlItem>();
        foreach (var category in Enum.GetValues(typeof(ProductCategory))) {
            result.Add(new DdlItem(category.ToString(), category.GetType().GetMember(category.ToString()).FirstOrDefault()?.GetCustomAttribute<DescriptionAttribute>()?.Description));
        }
        return Json(result);
    }
    
    [HttpGet("PostGrid")]
    public JsonResult PostGrid([FromQuery]string Category, int page) {

        LogTo.Debug("Category:" + Category + ", page:" + page);
        var predicate = PredicateBuilder.New<Post>(true);
        if (!StringUtils.TrimIsNull(Category)) {
            predicate = predicate.And(post => post.Category.Equals(Category));
        }

        var posts = postService.Query(predicate, page);
        return Json(posts);
    }
    */

    [Route ("/error")]
    [ResponseCache (Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error () {

        return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}