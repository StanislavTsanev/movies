namespace Movies.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
