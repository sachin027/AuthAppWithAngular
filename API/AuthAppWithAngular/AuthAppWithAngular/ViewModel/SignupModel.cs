using System.ComponentModel.DataAnnotations;

namespace AuthAppWithAngular.ViewModel
{
    public class SignupModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
