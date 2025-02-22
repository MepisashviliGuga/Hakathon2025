namespace Hakathon.API.infrastructure.Auth
{
    public class JWTConfiguration
    {
        public string Secret { get; set; }
        public int ExpirationInMInutes { get; set; }
    }
}
