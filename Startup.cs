using Dotnet.Services;
using Dotnet.Utils.Filter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
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
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddDbContext<DefaultContext>(options => {
                options.UseSqlite(config.GetConnectionString("DefaultConnection")); // 使用SQLite
            });

            services.AddWebOptimizer(pipeline => {
                pipeline.AddCssBundle("/css/bundle.css", getCss());

                pipeline.AddJavaScriptBundle("/js/bundle.js", getJs());

                // This will minify any JS and CSS file that isn't part of any bundle
                pipeline.MinifyCssFiles();
                pipeline.MinifyJsFiles();
            });
        }

        private string[] getCss() {

            List<string> css = new List<string>();

            css.Add("lib/bootstrap/bootstrap.min.css");
            css.Add("lib/font-awesome/css/font-awesome.min.css");
            css.Add("lib/bootstrap/sweetalert2/sweetalert2.min.css");
            css.Add("lib/bootstrap/bootstrap-select/bootstrap-select.css");
            css.Add("css/navbar.css");
            css.Add("css/font.css");
            css.Add("css/validate.css");
            css.Add("css/main.css");

            return css.ToArray();
        }

        private string[] getJs() {

            List<string> js = new List<string>();

            js.Add("lib/jquery/jquery.min.js");
            js.Add("lib/jquery/blockui/jquery.blockUI.js");
            js.Add("lib/bootstrap/bootstrap.bundle.min.js");
            js.Add("lib/vue/vue.min.js");
            js.Add("lib/vue/axios/axios.min.js");
            js.Add("lib/jquery/download/download.min.js");
            js.Add("lib/jquery/moment/moment.min.js");
            js.Add("lib/bootstrap/sweetalert2/sweetalert2.min.js");
            js.Add("lib/bootstrap/bootstrap-select/bootstrap-select.js");
            js.Add("lib/bootstrap/bootstrap-filestyle/bootstrap-filestyle.min.js");
            js.Add("lib/vue/vuejs-datatable.js");
            js.Add("lib/vue/custom/vue-selectpicker.js");
            js.Add("lib/remark/remark.min.js");

            js.Add("js/common.js");
            js.Add("js/main.js");

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
