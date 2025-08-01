namespace Linn.Portal.Domain.Authorization
{
    public class Subject
    {
        public Guid Sub { get; set; }

        public ICollection<Association> Associations { get; set; }
    }
}
