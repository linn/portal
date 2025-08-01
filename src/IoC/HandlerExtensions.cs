namespace Linn.Portal.IoC
{
    using Linn.Common.Service.Core.Handlers;

    using Microsoft.Extensions.DependencyInjection;

    public static class HandlerExtensions
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            return services.AddSingleton<IHandler, JsonResultHandler<dynamic>>();
        }
    }
}
