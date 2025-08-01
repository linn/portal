namespace Linn.Portal.Domain.Authorization
{
    public class Subject
    {
        public Guid Sub { get; set; }

        public ICollection<Association> Associations { get; set; }
        
        public ICollection<Permission> Permissions { get; set; }

        public bool HasPermissionFor(Privilege privilege, Uri resource)
        {
            var hasAssociation = this.Associations.Any(a => a.AssociatedResource == resource);
            var hasPrivilege = this.Permissions.Any(p =>
                p.IsActive &&
                p.Privilege.IsActive &&
                p.Privilege.Action == privilege.Action);

            return hasAssociation && hasPrivilege;
        }

    }
}
