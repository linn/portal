using System.IO;
using Linn.Common.Logging;
using Linn.Common.Service.Core;
using Linn.Common.Service.Core.Extensions;
using Linn.Portal.IoC;
// using Linn.Portal.Service;
using Linn.Portal.Service.Host.Negotiators;
using Linn.Service.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Linn.Portal.Service.Host
{
    using System.Linq;

    using Linn.Portal.Service.Models;

    using Microsoft.IdentityModel.JsonWebTokens;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            JsonWebTokenHandler.DefaultInboundClaimTypeMap.Clear();
            
            var x = ApplicationSettings.Get();

            services.AddCors();
            services.AddSingleton<IViewLoader, ViewLoader>();
            services.AddSingleton<IResponseNegotiator, HtmlNegotiator>();
            services.AddSingleton<IResponseNegotiator, UniversalResponseNegotiator>();

            services.AddCredentialsExtensions();
            services.AddSqsExtensions();
            services.AddLog();

            services.AddServices();
            services.AddFacadeServices();
            services.AddBuilders();
            services.AddHandlers();

            // Ensure your configuration or settings class gives this info properly
            var authority = "https://cognito-idp.eu-west-1.amazonaws.com/eu-west-1_HL1uFEa5R";
            var audience = "64fbgrkkslt1choig1e8km1g45";

            services.AddAuthentication(options =>
                    {
                        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                .AddJwtBearer(options =>
                    {
                        options.Authority = authority;

                        options.TokenValidationParameters = new TokenValidationParameters
                                                                {
                                                                    ValidateIssuer = true,
                                                                    ValidIssuer = "https://cognito-idp.eu-west-1.amazonaws.com/eu-west-1_HL1uFEa5R",

                                                                    ValidateAudience = false,
                                                                    ValidAudience = audience,

                                                                    ValidateLifetime = true,
                                                                    ValidateIssuerSigningKey = true
                                                                };
                    });
            
            services.AddAuthorization();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStaticFiles(new StaticFileOptions
                {
                    RequestPath = "/portal/build",
                    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "client", "build"))
                });
            }
            else
            {
                app.UseStaticFiles(new StaticFileOptions
                {
                    RequestPath = "/portal/build",
                    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "app", "client", "build"))
                });
            }

            app.UseAuthentication();
            

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Append("Vary", "Accept");
                await next.Invoke();
            });

            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features.Get<IExceptionHandlerPathFeature>()?.Error;
                var log = app.ApplicationServices.GetService<ILog>();
                log.Error(exception?.Message, exception);

                var response = new { error = $"{exception?.Message}  -  {exception?.StackTrace}" };
                await context.Response.WriteAsJsonAsync(response);
            }));

            app.UseRouting();
            app.UseAuthorization(); // <-- Must add this

            app.UseEndpoints(endpoints =>
            {
                // Map your normal endpoints
                endpoints.MapEndpoints();

                // Example test endpoint to verify user authentication:
                endpoints.MapGet("/protected", async context =>
                {
                    var user = context.User;
                    if (user?.Identity?.IsAuthenticated == true)
                    {
                        await context.Response.WriteAsJsonAsync(new
                        {
                            message = "User is authenticated",
                            
                            username = user.Identity.Name,
                            claims = user.Claims.ToList().Select(c => new { c.Type, c.Value })
                        });
                    }
                    else
                    {
                        context.Response.StatusCode = 401;
                        await context.Response.WriteAsync("Not authenticated");
                    }
                });
            });
        }
    }
}
