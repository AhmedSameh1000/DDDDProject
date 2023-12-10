namespace BuberDinner.Application.Services.JWT
{
    public class JWTSettings
    {
        public const string SectionName = "JWTSettings";
        public string secret { get; set; }
        public string audience { get; set; }
        public string issuer { get; set; }
        public int expires { get; set; }
    }
}
