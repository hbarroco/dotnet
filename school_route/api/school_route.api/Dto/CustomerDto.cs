using System.ComponentModel.DataAnnotations;

namespace school_route.api.Dto
{
    public class CustomerDto
    {
        public CustomerDto() { }

        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime Dob { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
