using System.ComponentModel.DataAnnotations;

namespace Az204.Domain.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        [Display(Name = "First MidName")]
        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(50)]
        public string? FirstMidName { get; set; }

        [StringLength(50)]
        public string? LastName { get; set; }

        [StringLength(50)]
        public string? Telephone { get; set; }

        [StringLength(50)]
        public string? Location { get; set; }

        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        public string? Email { get; set; }
    }
}
