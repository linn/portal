namespace Linn.Portal.Persistence.Authorization
{
    using Linn.Portal.Domain.Authorization;

    public interface ISubjectRepository
    {
        Subject GetById(string sub);
    }
}
