using CAD.Models.Setting;
using Dotnet.Services.Generic;
using Dotnet.Services.Identity;
using Dotnet.Utils.Enum;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Dotnet.Services {
    public static class ServiceInjection {

        public static IServiceCollection InjectServices (this IServiceCollection services) {
            // 參考 Creating a simple login in ASP.NET Core 2 using Authentication and Authorization (NOT Identity)
            // http://future-shock.net/blog/post/creating-a-simple-login-in-asp.net-core-2-using-authentication-and-authorization-not-identity
            services.AddAuthentication (options => {
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie (options => { options.LoginPath = "/Account/Login"; });
            services.AddMvc ().AddRazorPagesOptions (options => {
                options.Conventions.AuthorizeFolder ("/");
                options.Conventions.AllowAnonymousToPage ("/Account/Login");
            });

            // 參考 https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-2.1&tabs=visual-studio%2Caspnetcore2x
            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                // If the LoginPath isn't set, ASP.NET Core defaults 
                // the path to /Account/Login.
                options.LoginPath = "/Account/Login";
                // If the AccessDeniedPath isn't set, ASP.NET Core defaults 
                // the path to /Account/AccessDenied.
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            // Add all other services here.
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IGenericService<Lesson>, LessonService>();

            // Enum
            services.AddSingleton<IEnumProvider, EnumProvider>();
            
            return services;
        }
    }
}