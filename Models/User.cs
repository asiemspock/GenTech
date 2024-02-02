using System.ComponentModel.DataAnnotations;

namespace GenTech.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public byte[] Photo { get; set; }
        [Phone]
        public string Phone { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
