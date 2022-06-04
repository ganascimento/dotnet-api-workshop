using System;

namespace Api.Domain.Dtos.Auth
{
    public class AuthDtoLoginResult
    {
        public bool Authenticated { get; set; }
        public DateTime Expiration { get; set; }
        public string AccessToken { get; set; }
    }
}