using Anotar.Log4Net;
using Dotnet.Models.Identity;
using Dotnet.Utils.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Dotnet.Services.Identity;

namespace Dotnet.Controllers.Identity {

    [Route("[controller]")]
    public class AccountController : Controller {

        private IUserManager userManager;

        public AccountController(IUserManager userManager) {

            this.userManager = userManager;
        }

        #region login
        [AllowAnonymous]
        [HttpGet("Login")]
        public IActionResult Login() {
            if (User.Identity.IsAuthenticated) {
                return Redirect(Url.Action("Index", "Backend"));
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost("Login")]
        public IActionResult Login(LoginModel form) {
            LogTo.Debug("login start....");
            LogTo.Debug("name:" + form.Account + ", password:" + form.Password);
            
            ValidateResult validateResult = userManager.Validate(form, ModelState);
            if (validateResult.Success) {
                userManager.SignIn(HttpContext, validateResult.User);
            }

            LogTo.Debug("login finish....");
            return Json(CommonUtils.GetJsonResult(ModelState, Url.Action("Index", "Backend")));
        }
        #endregion


        [AllowAnonymous]
        public IActionResult ForgotPassword() {

            return View();
        }

        /*
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(ForgotPasswordModel form) {
            logger.Debug("Name:" + form.Name);

            if (ModelState.IsValid) {
                SecurityUser dbUser = userService.GetByAccount(form.Account);
                if (dbUser == null || !dbUser.Name.Equals(form.Name)) {
                    ModelState.AddModelError("", "請輸入正確的帳號或姓名!");
                } else if (StringUtils.TrimIsNull(dbUser.Email)) {
                    ModelState.AddModelError("", "您的Email為空，請洽人資人員設定!");
                } else {
                    userService.ForgetPassword(dbUser, form);
                }
            }

            return Json(CommonUtils.GetJsonResult(ModelState, Url.Action("Login")));
        }
*/


        [HttpPost("Logout")]
        public IActionResult Logout() {

            LogTo.Debug("Logout");
            userManager.SignOut(HttpContext);
            return RedirectToAction("Login");
        }

        [HttpGet("AccessDenied")]
        public IActionResult AccessDenied() {

            return RedirectToAction("Index", "Backend");
        }

        [HttpGet("ChangePassword")]
        public IActionResult ChangePassword() {

            return View();
        }

        [HttpPost("ChangePassword")]
        [ValidateAntiForgeryToken]
        public IActionResult ChangePassword(ChangePasswordModel form) {
            LogTo.Debug("Account: " + form.Account);
            userManager.ChangePassword(form, ModelState);
            return Json(CommonUtils.GetJsonResult(ModelState, Url.Action("Index", "Backend")));
        }
    }
}