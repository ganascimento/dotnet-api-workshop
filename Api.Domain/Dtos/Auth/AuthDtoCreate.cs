using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Auth
{
    public class AuthDtoCreate
    {
        [Required(ErrorMessage = "Cnpj is required")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "Cnpj must be a maximum of {1} characters")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(64, MinimumLength = 8, ErrorMessage = "Password must be a maximum of {1} characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name must be a maximum of {1} characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Street is required")]
        [StringLength(100, ErrorMessage = "Street must be a maximum of {1} characters")]
        public string Street { get; set; }

        public int Number { get; set; }
        public string Complement { get; set; }

        [Required(ErrorMessage = "District is required")]
        [StringLength(100, ErrorMessage = "District must be a maximum of {1} characters")]
        public string District { get; set; }

        [Required(ErrorMessage = "Uf is required")]
        [StringLength(2, ErrorMessage = "Uf must be a maximum of {1} characters")]
        public string Uf { get; set; }
    }
}