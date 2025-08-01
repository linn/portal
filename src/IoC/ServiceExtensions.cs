namespace Linn.Portal.IoC
{
    using Linn.Common.Facade;
    using Linn.Common.Rendering;
    using Linn.Portal.Facade.Services;

    using Microsoft.Extensions.DependencyInjection;

    using RazorEngineCore;

    public static class ServiceExtensions
    {
        public static IServiceCollection AddFacadeServices(this IServiceCollection services)
        {
            return services.AddScoped<IInvoiceService, InvoiceService>();
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<IRazorEngine, RazorEngine>()
                .AddSingleton<ITemplateEngine, RazorTemplateEngine>();
        }

        public static IServiceCollection AddBuilders(this IServiceCollection services)
        {
            return services;
        }
    }
}
