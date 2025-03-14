namespace Globant.StandardArchitecture.Core.Domain
{
    public class UserGroup
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int UpsertBy { get; set; }
        public DateTime UpsertAt { get; set; }
        public bool Active { get; set; }
    }

}
