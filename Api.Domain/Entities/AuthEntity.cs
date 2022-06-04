using Api.Domain.Entities.Base;

namespace Api.Domain.Entities
{
    public class AuthEntity : BaseEntity
    {
        public string Cnpj { get; set; }
        public string Password { get; set; }
    }
}