namespace Globant.StandardArchitecture.Core.Domain
{
    public class UserGroupUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int UserGroupId { get; set; }
        public int UpsertBy { get; set; }
        public DateTime UpsertAt { get; set; }
        public bool Active { get; set; }
    }

}
