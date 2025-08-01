namespace Linn.Portal.Domain.Authorization
{
    public class Permission
    {
        public int Id { get; set; }

        public Privilege Privilege { get; set; }

        public Subject Subject { get; set; }

        public bool IsActive { get; set; }
    }
}
