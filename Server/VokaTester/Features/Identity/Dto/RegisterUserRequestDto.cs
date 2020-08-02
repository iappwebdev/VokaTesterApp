namespace VokaTester.Features.Identity.Dto
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterUserRequestDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
