namespace Api.Domain.Dtos.Auth
{
    public class AuthDtoLoginResult
    {
        public bool Authenticated { get; set; }
        public string Create { get; set; }
        public string Expiration { get; set; }
        public string AccessToken { get; set; }
    }
}