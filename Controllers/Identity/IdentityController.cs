using Anotar.Log4Net;
using Dotnet.Models.Identity;
using Dotnet.Services.Generic;
using Dotnet.Utils.Common;
using LinqKit;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet.Controllers.Identity {

    /// <summary>
    /// Custom Model Binding with Attributes
    /// 參考: https://exceptionnotfound.net/asp-net-core-demystified-model-binding-in-mvc/
    /// </summary>
    [Route("[controller]")]
    public class IdentityController : Controller {
        private readonly IGenericService<User> userService;
        private readonly IGenericService<Role> roleService;

        public IdentityController(IGenericService<User> userService, IGenericService<Role> roleService) {

            this.userService = userService;
            this.roleService = roleService;
        }

        #region USERS
        [HttpGet("UserList")]
        public IActionResult UserList() {

            return View();
        }

        /// <summary>
        /// 使用 PredicateBuilder
        /// 參考 http://aminggo.idv.tw/blog/?p=1370
        ///      http://blog.darkthread.net/post-2015-10-23-linqkit.aspx
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpGet("UserGrid")]
        public JsonResult UserGrid([FromQuery]User form) {

            LogTo.Debug("account:" + form.Account + ", name:" + form.Name + ", status:" + form.Status);

            var predicate = PredicateBuilder.New<User>(true);
            if (!StringUtils.TrimIsNull(form.Account)) {
                predicate = predicate.And(user => user.Account.Contains(form.Account));
            }

            if (!StringUtils.TrimIsNull(form.Name)) {
                predicate = predicate.And(user => user.Name.Contains(form.Name));
            }

            if (!StringUtils.TrimIsNull(form.Status)) {
                predicate = predicate.And(user => user.Status.Equals(form.Status));
            }

            var users = userService.GetAll(predicate);
            return Json(users);
        }

        [HttpGet("UserCreate")]
        public IActionResult UserCreate() {

            ViewData["Roles"] = roleService.GetAll();
            return View();
        }
        
        [HttpPost("UserCreate")]
        [ValidateAntiForgeryToken]
        public IActionResult UserCreate(User form) {

            LogTo.Debug("user account:" + form.Account);

            var dbUser = userService.Get(user => user.Account.Equals(form.Account));
            if (dbUser != null) {
                ModelState.AddModelError(string.Empty, "此帳號已存在!");
            }

            if (ModelState.IsValid) {
                userService.Insert(form);
            }

            return Json(CommonUtils.GetJsonResult(ModelState, Url.Action("UserList")));
        }

        [HttpGet("UserEdit/{id}")]
        public IActionResult UserEdit(string id) {

            LogTo.Debug("user id :" + id);
            //var dbUser = userService.Get(user=> user.Id.Equals(id), user => user.UserRoles);
            var dbUser = userService.GetById(id);

            ViewData["Roles"] = roleService.GetAll();
            return View(dbUser);
        }

        [HttpPost("UserEdit")]
        [ValidateAntiForgeryToken]
        public IActionResult UserEdit([FromForm]User form) {

            form.UserRoles.ForEach(userRole => LogTo.Debug("UserId:" + userRole.UserId + ", RoleId:" + userRole.RoleId));
            if (ModelState.IsValid) {
                userService.Update(form);
            }

            return Json(CommonUtils.GetJsonResult(ModelState, Url.Action("UserList")));
        }
        
        [HttpDelete("UserDelete")]
        [ValidateAntiForgeryToken]
        public IActionResult UserDelete(string id) {

            LogTo.Debug("id:" + id);
            userService.Delete(id);
            return Json(CommonUtils.GetJsonResult(ModelState, Url.Action("UserList")));
        }
        
        #endregion


        #region ROLES
        [HttpGet("RoleList")]
        public IActionResult RoleList() {

            return View();
        }


        [HttpGet("RoleGrid")]
        public JsonResult RoleGrid() {

            var roles = roleService.GetAll();
            return Json(roles);
        }

        [HttpGet("RoleCreate")]
        public IActionResult RoleCreate() {

            return View();
        }

        [HttpPost("RoleCreate")]
        [ValidateAntiForgeryToken]
        public JsonResult RoleCreate([FromForm]Role form) {

            LogTo.Debug("Role code:" + form.Code + ", description:" + form.Description);

            var dbRole = roleService.Get(role => role.Code.Equals(form.Code));

            if (dbRole != null) {
                ModelState.AddModelError(string.Empty, "此角色代碼已存在!");
            }
            LogTo.Debug("Model State: " + ModelState.IsValid);
            if (ModelState.IsValid) {
                roleService.Insert(form);
            }

            return Json(CommonUtils.GetJsonResult(ModelState, Url.Action("RoleList")));
        }

        [HttpGet("RoleEdit/{id}")]
        public IActionResult RoleEdit(string id) {

            LogTo.Debug("id:" + id);
            var dbRole = roleService.Get(role => role.Id.Equals(id));
            return View(dbRole);
        }


        [HttpPost("RoleEdit")]
        [ValidateAntiForgeryToken]
        public JsonResult RoleEdit([FromForm]Role form) {

            if (ModelState.IsValid) {
                roleService.Update(form);
            }
            return Json(CommonUtils.GetJsonResult(ModelState, Url.Action("RoleList")));
        }

        [HttpDelete("RoleDelete")]
        [ValidateAntiForgeryToken]
        public JsonResult RoleDelete(string id) {

            LogTo.Debug("id:" + id);
            roleService.Delete(id);
            return Json(CommonUtils.GetJsonResult(ModelState, Url.Action("RoleList")));
        }
        #endregion
    }
}