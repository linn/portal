namespace Linn.Portal.Persistence.Authorization
{
    using Linn.Portal.Domain.Authorization;

    public class SubjectRepository : ISubjectRepository
    {
        // mock this out for now until we do migrations and create some data
        public Subject GetById(string sub)
        {
            return new Subject
                       {
                           Sub = Guid.Parse(sub),
                           Associations = new List<Association>
                                              {
                                                  new Association
                                                      {
                                                          isActive = true,
                                                          AssociatedResource = new Uri("/retailers/123")
                                                      }
                                              },
                           Permissions = new List<Permission>
                                             {
                                                 new Permission
                                                     {
                                                         IsActive = true,
                                                         Privilege = new Privilege
                                                                         {
                                                                             Action = AuthorisedActions.ViewInvoice,
                                                                             IsActive = true
                                                                         }
                                                     }
                                             }

                       };
        }
    }
}
