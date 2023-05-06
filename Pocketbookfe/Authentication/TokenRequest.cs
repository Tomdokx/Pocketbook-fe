using System.ComponentModel.DataAnnotations;

namespace pocketbookfe.Authentication
{
    public class TokenRequest
{
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
}
}
