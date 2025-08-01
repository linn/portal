namespace Linn.Portal.Domain.Authorization
{
    public class Subject
    {
        public Guid Sub { get; set; }

        public ICollection<Association> Associations { get; set; }
        
        public ICollection<Permission> Permissions { get; set; }

        public bool HasPermissionFor(Privilege privilege, Uri resource)
        {
            if (this.Associations
                    .FirstOrDefault(x => x.AssociatedResource == resource) == null)
            {
                return false;
            }

            if (this.Permissions.Any(x => x.IsActive 
                                          && x.Privilege.Action == privilege.Action 
                                          && x.Privilege.IsActive))
            {
                return true;
            }
            
            return false;
        }
    }
}
