namespace Linn.Portal.Service.Modules
{
    using System.Linq;
    using System.Threading.Tasks;

    using Linn.Common.Service.Core;
    using Linn.Common.Service.Core.Extensions;
    using Linn.Portal.Facade.Services;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Routing;

    public class InvoiceModule : IModule
    {
        public void MapEndpoints(IEndpointRouteBuilder app)
        {
            app.MapGet("/portal/api/invoices/{id:int}", this.GetInvoice);
        }
        
        private async Task GetInvoice(HttpRequest req, HttpResponse res, int id, IInvoiceService service)
        {
            var user = req.HttpContext.User;

            if (user.Identity?.IsAuthenticated == true)
            {
                var sub = user.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;

                var invoice = await service.GetInvoice(id, sub);
                await res.Negotiate(invoice);
            }
            else
            {
                req.HttpContext.Response.StatusCode = 401;
                await req.HttpContext.Response.WriteAsync("Not authenticated");
            }
        }
    }
}
