namespace Globant.StandardArchitecture.Core.Domain
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public int? UpsertBy { get; set; }
        public DateTime UpsertAt { get; set; }
        public bool Active { get; set; }
    }

}
