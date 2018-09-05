using Anotar.Log4Net;
using CAD.Models.Setting;
using Dotnet.Services.Generic;
using Dotnet.Utils.Common;
using LinqKit;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CAD.Controllers.Setting {

    [Route("[controller]")]
    public class SettingController : Controller {

        private readonly IGenericService<Lesson> lessonService;

        public SettingController(IGenericService<Lesson> lessonService) {

            this.lessonService = lessonService;
        }

        [HttpGet("LessonList")]
        public IActionResult LessonList() {

            return View();
        }

        [HttpGet("LessonGrid")]
        public JsonResult LessonGrid([FromQuery]Lesson form) {

            LogTo.Debug("Name:" + form.Name + ", Description:" + form.Description);

            var predicate = PredicateBuilder.New<Lesson>(true);
            if (!StringUtils.TrimIsNull(form.Name)) {
                predicate = predicate.And(lesson => lesson.Name.Contains(form.Name));
            }

            if (!StringUtils.TrimIsNull(form.Description)) {
                predicate = predicate.And(user => user.Description.Contains(form.Description));
            }

            var users = lessonService.GetAll(predicate);
            return Json(users);
        }

        /// <summary>
        /// Uploads an image to the server.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        /// 
        [HttpPost("UploadImage/{type}")]
        public IActionResult UploadImage(string type) {

            try {
                string fileName = CommonUtils.UploadFile(Request.Form.Files, "images\\" + type);
                return Json(fileName);
            } catch (Exception ex) {
                return Json("Upload Failed: " + ex.Message);
            }
        }

        [HttpGet("LessonCreate")]
        public IActionResult LessonCreate() {

            return View();
        }

        [HttpPost("LessonCreate")]
        [ValidateAntiForgeryToken]
        public IActionResult LessonCreate([FromForm]Lesson form) {
            LogTo.Debug("form:" + form);
            if (ModelState.IsValid) {
                lessonService.Insert(form);
            }
            return Json(CommonUtils.GetJsonResult(ModelState, Url.Action("LessonList")));
        }


        [HttpGet("LessonEdit/{id}")]
        public IActionResult LessonEdit(string id) {

            var dbLesson = lessonService.GetById(id);
            return View(dbLesson);
        }


        [HttpPost("LessonEdit")]
        [ValidateAntiForgeryToken]
        public IActionResult LessonEdit([FromForm]Lesson form) {

            if (ModelState.IsValid) {
                lessonService.Update(form);
            }
            return Json(CommonUtils.GetJsonResult(ModelState, Url.Action("LessonList")));
        }

    }
}
