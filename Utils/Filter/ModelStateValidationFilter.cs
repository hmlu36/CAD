using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Anotar.Log4Net;
using Dotnet.Models.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Dotnet.Utils.Filter {
    public class ModelStateValidationFilter : ActionFilterAttribute {

        private List<string> excludeColumns = new List<string> { "Id", "CreatedTime", "CreatedUser", "ModifiedTime", "ModifiedUser" };

        /*
        public override void OnActionExecuting (ActionExecutingContext context) {
            LogTo.Debug ("ModelStateValidation OnActionExecuting start...");

            LogTo.Debug ("ModelStateValidation OnActionExecuting end...");
        }
        */

        // 自製驗證訊息
        // 為了要轉換成中文語系
        public override void OnActionExecuting(ActionExecutingContext context) {

            // LogTo.Debug("ModelStateValidation OnActionExecuting start...");

            // LogTo.Debug("OnActionExecuted:" + context.HttpContext.Request.Method);
            // 判斷POST或是PUT才做Model Building驗證
            string httpMethod = context.HttpContext.Request.Method;
            if ((("POST".Equals(httpMethod) || "PUT".Equals(httpMethod)) && !context.ModelState.IsValid)) {
                var modelStateErrors = (from modelState in context.ModelState.Values
                                        from error in modelState.Errors
                                        where !excludeColumns.Any(column => error.ErrorMessage.Contains(column)) // 過濾掉排除欄位
                                        select error);

                ValidateMessage validateMessage = new ValidateMessage();
                validateMessage.Success = false;
                List<string> errors = new List<string>();
                foreach (var modelStateError in modelStateErrors) {
                    var isRequired = Regex.Match(modelStateError.ErrorMessage, "The (.*?) field is required.");
                    if (isRequired.Success) {
                        //log.Debug (message.ErrorMessage);
                        //log.Debug (isRequired.Groups[1].Value + "必填欄位");
                        errors.Add(isRequired.Groups[1].Value + "必填欄位");
                        // TODO 陸續加入英文轉中文驗證訊息
                    } else {
                        //LogTo.Debug(modelStateError.ErrorMessage);
                        errors.Add(modelStateError.ErrorMessage);
                    }
                }
                // 判斷是否有驗證未通過
                if (errors.Count() > 0) {
                    validateMessage.Message = errors;
                    context.Result = new ObjectResult(validateMessage);
                } else {
                    context.ModelState.Clear();
                }
            }

            // LogTo.Debug("ModelStateValidation OnActionExecuting finish...");
        }
    }
}