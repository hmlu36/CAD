using Anotar.Log4Net;
using CAD.Models.Setting;
using Dotnet.Services.Generic;
using Dotnet.Utils.Common;
using LinqKit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Linq;

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

        [HttpGet("LessonAdd")]
        public IActionResult LessonAdd() {

            return View(new Lesson());
        }

        [HttpPost("LessonAdd")]
        [ValidateAntiForgeryToken]
        public IActionResult LessonAdd([FromForm]Lesson form) {

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

            form.TeachingAids.ToList().ForEach(teachingAid => LogTo.Debug("TechingAid:" + teachingAid.Description));
            
            if (ModelState.IsValid) {
                lessonService.Update(form);
            }
            return Json(CommonUtils.GetJsonResult(ModelState, Url.Action("LessonList")));
        }

        private void FormValidation(ModelStateDictionary ModelState, Lesson form) {
        }
    }
}
