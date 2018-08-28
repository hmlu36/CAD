using Anotar.Log4Net;
using CAD.Models.Setting;
using Dotnet.Services.Generic;
using Dotnet.Utils.Common;
using LinqKit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAD.Controllers.Setting {

    [Route("[controller]")]
    public class SettingController : Controller {

        private readonly IGenericService<Category> cagetoryService;

        public SettingController(IGenericService<Category> cagetoryService) {

            this.cagetoryService = cagetoryService;
        }


        [HttpGet("CategoryList")]
        public IActionResult CategoryList() {
            return View();
        }


        [HttpGet("CategoryGrid")]
        public JsonResult CategoryGrid([FromQuery]Category form) {

            LogTo.Debug("Code:" + form.Code + ", Description:" + form.Description);

            var predicate = PredicateBuilder.New<Category>(true);
            if (!StringUtils.TrimIsNull(form.Code)) {
                predicate = predicate.And(user => user.Code.Contains(form.Code));
            }

            if (!StringUtils.TrimIsNull(form.Description)) {
                predicate = predicate.And(user => user.Description.Contains(form.Description));
            }

            var users = cagetoryService.GetAll(predicate);
            return Json(users);
        }
    }
}
