namespace Actio.Common.Auth
{
    public class JwtOptions
    {
        public string Secretkey { get; set; }

        public long ExpiryMinutes { get; set; }

        public string Issuer { get; set; }
    }
}
