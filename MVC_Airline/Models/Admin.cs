using System.ComponentModel.DataAnnotations;

namespace MVC_Airline.Models
{
    public class Admin
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PANNO { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        public string RoleName { get; set; }
        [Required]
        public string Status { get; set; }
       
        public bool IsApproved { get; set; }
    }
}
