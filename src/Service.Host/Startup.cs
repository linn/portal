namespace Linn.Portal.Service.Host
{
    using System.IO;

    using Linn.Common.Logging;
    using Linn.Common.Service.Core;
    using Linn.Common.Service.Core.Extensions;
    using Linn.Portal.IoC;
    using Linn.Portal.Service.Host.Negotiators;
    using Linn.Portal.Service.Models;
    using Linn.Service.IoC;

    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.FileProviders;
    using Microsoft.Extensions.Hosting;
    using Microsoft.IdentityModel.JsonWebTokens;
    using Microsoft.IdentityModel.Tokens;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            JsonWebTokenHandler.DefaultInboundClaimTypeMap.Clear();
            

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

            var x = ApplicationSettings.Get();

            // todo - use above settings to get the below info properly
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
            app.UseAuthorization();

            app.UseEndpoints(builder => { builder.MapEndpoints(); });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapEndpoints();
            });
        }
    }
}
