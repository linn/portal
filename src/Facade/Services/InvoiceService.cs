namespace Linn.Portal.Facade.Services
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Threading.Tasks;

    using Linn.Common.Facade;
    using Linn.Portal.Domain.Authorization;
    using Linn.Portal.Persistence.Authorization;

    public class InvoiceService : IInvoiceService
    {
        public async Task<IResult<dynamic>> GetInvoice(int id, string subjectId)
        {
            // todo, replace with dependency injection
            var subject = new SubjectRepository().GetById(subjectId);
            
            // todo - replace with http call to internal apps /sales/invoices/id
            dynamic invoice = new ExpandoObject();
            invoice.documentNumber = 1;
            invoice.description = "an invoice";
            invoice.links = new List<object>
                                {
                                    new { rel = "retailer", href = "/retailers/123" }
                                };

            if (!subject.HasPermissionFor(AuthorisedActions.ViewInvoice, new Uri(invoice.links[0].href)))
            {
                return new UnauthorisedResult<dynamic>();
            }
            
            return new SuccessResult<dynamic>(invoice);
        }
    }
}
