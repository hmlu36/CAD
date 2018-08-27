using Dotnet.Models.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet.Utils.Enum {

    /// <summary>
    /// 參考: https://dzone.com/articles/aspnet-core-building-an-enum-provider-to-convert-c
    /// </summary>
    public class EnumsToJavaScriptViewComponent : ViewComponent {
        private readonly IEnumProvider _enumProvider;

        public EnumsToJavaScriptViewComponent(IEnumProvider enumProvider) {
            _enumProvider = enumProvider;
        }

        public Task<HtmlString> InvokeAsync() {
            var buffer = new StringBuilder(10000);

            foreach (var jsEnum in _enumProvider.GetEnumTypes()) {
                buffer.Append("var ");
                buffer.Append(jsEnum.Name);
                buffer.Append(" = ");
                buffer.Append(EnumToString(jsEnum));
                buffer.Append("; \r\n");
            }
            //buffer.Append("\r\n Vue.component('v-select', VueSelect.VueSelect);");
            return Task.FromResult(new HtmlString(buffer.ToString()));
        }

        private static string EnumToString(Type enumType) {
            var values = System.Enum.GetValues(enumType);
            List<DdlItem> ddls = new List<DdlItem>();   
            foreach (var value in values) {
                DdlItem ddl = new DdlItem(value.ToString(), value.GetType().GetMember(value.ToString()).FirstOrDefault()?.GetCustomAttribute<DescriptionAttribute>()?.Description);

                ddls.Add(ddl);
            }

            return JsonConvert.SerializeObject(ddls);
        }
    }
}
