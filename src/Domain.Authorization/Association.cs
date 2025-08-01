namespace Linn.Portal.Domain.Authorization
{
    public class Association
    {
        public Subject Subject { get; set; }
        
        public Uri AssociatedResource { get; set; }
        
        public bool isActive { get; set; }
    }
}
