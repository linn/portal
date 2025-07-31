namespace Linn.Portal.Service.Modules
{
    using System.Threading.Tasks;

    using Linn.Common.Service.Core;
    using Linn.Common.Service.Core.Extensions;
    using Linn.Portal.Service.Models;
    using Linn.Service.Service.Models;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Routing;

    public class ApplicationModule : IModule
    {
        public void MapEndpoints(IEndpointRouteBuilder app)
        {
            app.MapGet("/", this.Redirect);
            app.MapGet("/portal", this.GetApp);
            app.MapGet("/portal/protected", this.GetProtected);

        }

        private Task Redirect(HttpRequest req, HttpResponse res)
        {
            res.Redirect("/portal");
            return Task.CompletedTask;
        }

        private async Task GetApp(HttpRequest req, HttpResponse res)
        {
            await res.Negotiate(new ViewResponse { ViewName = "Index.cshtml" });
        }
        
        private async Task GetProtected(HttpRequest req, HttpResponse res)
        {
            var user = req.HttpContext.User;
            res.StatusCode = 200;
            res.ContentType = "application/json";
            await res.WriteAsync("{\"message\":\"Success\"}");
        }
    }
}
