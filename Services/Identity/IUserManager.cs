using Dotnet.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Dotnet.Services.Identity {

    public class ValidateResult {

        public User User { get; set; }
        public bool Success { get; set; }

        public ValidateResult(User user = null, bool success = false) {

            this.User = user;
            this.Success = success;
        }
    }

    public interface IUserManager {

        ValidateResult Validate(LoginModel form, ModelStateDictionary modelState);
        void SignIn(HttpContext httpContext, User user);
        void SignOut(HttpContext httpContext);
        bool ChangePassword(ChangePasswordModel form, ModelStateDictionary modelState);
    }
}
