using Dotnet.Services;
using Dotnet.Utils.Filter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace CAD {

    public class Startup {


        private readonly IConfiguration config;

        public Startup(IConfiguration config) {

            this.config = config;
        }

        public void ConfigureServices(IServiceCollection services) {

            services.InjectServices();

            services.AddMvc(options => {
                options.Filters.Add(typeof(ModelStateValidationFilter));
            })
            .AddJsonOptions(options => {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver(); // JSON第一個字大寫
            });


            services.AddDbContext<DefaultContext>(options => {
                options.UseSqlite(config.GetConnectionString("DefaultConnection")); // 使用SQLite
            });

            services.AddWebOptimizer(pipeline => {
                pipeline.AddCssBundle("/css/frontendBundle.css", getCss("frontend"));
                pipeline.AddCssBundle("/css/loginBundle.css", getCss("login"));
                pipeline.AddCssBundle("/css/backendBundle.css", getCss("backend"));

                pipeline.AddJavaScriptBundle("/js/frontendBundle.js", getJs("frontend"));
                pipeline.AddJavaScriptBundle("/js/loginBundle.js", getJs("login"));
                pipeline.AddJavaScriptBundle("/js/backendBundle.js", getJs("backend"));

                // This will minify any JS and CSS file that isn't part of any bundle
                pipeline.MinifyCssFiles();
                pipeline.MinifyJsFiles();
            });
        }

        private string[] getCss(string type) {

            List<string> css = new List<string>();

            css.Add("lib/bootstrap/bootstrap.min.css");
            css.Add("css/font.css");
            css.Add("lib/font-awesome/css/font-awesome.min.css");

            if ("frontend".Equals(type)) {
                css.Add("css/frontend.css");
            } else if ("backend".Equals(type)) {
                css.Add("css/validate.css");
                css.Add("css/backend.css");
                css.Add("lib/bootstrap/sweetalert2/sweetalert2.min.css");
                css.Add("lib/bootstrap/bootstrap-select/bootstrap-select.css");
            } else if ("login".Equals(type)) {
                css.Add("css/validate.css");
                css.Add("css/login.css");
                return css.ToArray();
            }

            css.Add("css/navbar.css");

            return css.ToArray();
        }

        private string[] getJs(string type) {

            List<string> js = new List<string>();

            js.Add("lib/jquery/jquery.min.js");
            js.Add("lib/jquery/blockui/jquery.blockUI.js");
            js.Add("lib/bootstrap/bootstrap.min.js");
            js.Add("lib/vue/vue.min.js");
            js.Add("lib/vue/axios/axios.min.js");

            if ("frontend".Equals(type)) {
                js.Add("js/frontend.js");
                js.Add("lib/jquery/jquery-easing/jquery.easing.min.js");
                js.Add("lib/vue/custom/vue-post.js");
            } else if ("backend".Equals(type)) {
                js.Add("js/backend.js");
                js.Add("js/common.js");
                js.Add("lib/jquery/download/download.min.js");
                js.Add("lib/jquery/moment/moment.min.js");
                js.Add("lib/bootstrap/sweetalert2/sweetalert2.min.js");
                js.Add("lib/bootstrap/bootstrap-select/bootstrap-select.js");
                js.Add("lib/bootstrap/bootstrap-filestyle/bootstrap-filestyle.min.js");
                js.Add("lib/vue/vuejs-datatable.js");
                js.Add("lib/vue/custom/vue-selectpicker.js");
            }

            return js.ToArray();
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DefaultContext context) {

            // 建立資料庫            
            context.Database.EnsureCreated();

            app.UseWebOptimizer();

            // 語系設定
            app.UseStaticFiles();

            // 登入驗證
            app.UseAuthentication();

            // 錯誤訊息
            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();

            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id:guid?}"
                );
            });
        }
    }
}
