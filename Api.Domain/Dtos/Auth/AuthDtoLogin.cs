using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Auth
{
    public class AuthDtoLogin
    {
        [Required(ErrorMessage = "Cnpj is required")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "Cnpj must be a maximum of {1} characters")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(64, MinimumLength = 8, ErrorMessage = "Password must be a maximum of {1} characters")]
        public string Password { get; set; }
    }
}