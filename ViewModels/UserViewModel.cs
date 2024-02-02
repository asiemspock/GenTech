using GenTech.Data;
using GenTech.Validation;
using System.ComponentModel.DataAnnotations;

namespace GenTech.ViewModels
{
    public class UserViewModel : IValidatableObject
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [MaxFileSize(2 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".jpg", ".png", ".gif", ".jpeg", ".webp" })]
        public IFormFile Photo { get; set; }
        public string? CurrentPhoto { get; set; }
        [Phone]
        public string Phone { get; set; }
        [Display(Name = "Select a Company")]
        [Required]
        public int CompanyId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var context = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));

            if (context.User.Any(x => x.UserName == UserName && x.Id != Id))
            {
                yield return new ValidationResult("Username already exists.", new[] { nameof(UserName) });
            }

            if (context.User.Any(x => x.Email == Email && x.Id != Id))
            {
                yield return new ValidationResult("Email already exists.", new[] { nameof(Email) });
            }

            if (context.User.Any(x => x.Phone == Phone && x.Id != Id))
            {
                yield return new ValidationResult("Phone number already exists.", new[] { nameof(Phone) });
            }
        }
    }
}
