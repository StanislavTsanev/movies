namespace Movies.Infrastructure.Identity
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(UserEntity user);
    }
}
