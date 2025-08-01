namespace Linn.Portal.Facade.Services
{
    using System.Threading.Tasks;

    using Linn.Common.Facade;

    public interface IInvoiceService
    {
        Task<IResult<dynamic>> GetInvoice(int id, string subjectId);
    }
}
