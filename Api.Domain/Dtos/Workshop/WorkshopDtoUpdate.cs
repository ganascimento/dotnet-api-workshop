using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Workshop
{
    public class WorkshopDtoUpdate {
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