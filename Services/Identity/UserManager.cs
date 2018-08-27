using Anotar.Log4Net;
using CAD;
using Dotnet.Models.Identity;
using Dotnet.Services.Generic;
using Dotnet.Utils.Common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Dotnet.Services.Identity {

    /// <summary>
    /// 參考: https://github.com/DmitrySikorsky/AspNetCoreCustomUserManager
    /// </summary>
    public class UserManager : IUserManager {

        private DefaultContext context;
        private IGenericService<User> userService;
        private IGenericService<Role> roleService;

        public UserManager(IGenericService<User> userService, IGenericService<Role> roleService, DefaultContext context) {

            this.userService = userService;
            this.roleService = roleService;
            this.context = context;
        }

        public ValidateResult Validate(LoginModel form, ModelStateDictionary modelState) {

            // 驗證錯誤直接跳過
            if (!modelState.IsValid) {
                return new ValidateResult(success: false);
            }

            var dbUser = userService.Get(user => string.Equals(user.Account, form.Account, StringComparison.OrdinalIgnoreCase));

            if (dbUser == null) {
                LogTo.Debug(form.Account + " 帳號不存在!");
                modelState.AddModelError("", "請輸入正確的帳號或姓名!");
                return new ValidateResult(success: false);
            } else if (!HashUtils.VerifyPassword(form.Password, dbUser.PasswordHash)) {
                LogTo.Debug(form.Account + " 密碼輸入錯誤!");
                modelState.AddModelError("", "請輸入正確的帳號或姓名!");
                return new ValidateResult(success: false);
            }

            return new ValidateResult(user: dbUser, success: true);
        }

        public async void SignIn(HttpContext httpContext, User user) {

            ClaimsIdentity identity = new ClaimsIdentity(this.GetUserClaims(user), CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            await httpContext.SignInAsync(
              CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties() { }
            );
        }

        public async void SignOut(HttpContext httpContext) {

            await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        private IEnumerable<Claim> GetUserClaims(User user) {

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Account));
            claims.Add(new Claim(ClaimTypes.Name, user.Name));
            claims.AddRange(this.GetUserRoleClaims(user));
            return claims;
        }

        private IEnumerable<Claim> GetUserRoleClaims(User user) {

            List<Claim> claims = new List<Claim>();
            IEnumerable<string> roleIds = context.UserRoles.Where(ur => ur.UserId == user.Id).Select(ur => ur.RoleId).ToList();

            if (roleIds != null) {
                foreach (string roleId in roleIds) {
                    Role role = roleService.Get(r => r.Id.Equals(roleId));

                    claims.Add(new Claim(ClaimTypes.Role, role.Code));
                }
            }

            return claims;
        }

        public bool ChangePassword(ChangePasswordModel form, ModelStateDictionary modelState) {

            if (!modelState.IsValid) {
                return false;
            }

            var dbUser = userService.Get(user => user.Account.Equals(form.Account));
            if (!HashUtils.VerifyPassword(form.OldPassword, dbUser.PasswordHash)) {
                modelState.AddModelError("", "舊密碼輸入錯誤");
            } else {
                dbUser.Password = form.NewPassword;
                userService.Update(dbUser);
            }
            return true;
        }

    }
}
