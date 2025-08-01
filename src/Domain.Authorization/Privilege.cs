namespace Linn.Portal.Domain.Authorization
{
    public class Privilege
    {
        public int Id { get; set; }

        public string Action { get; set; }

        public bool IsActive { get; set; }
    }
}
