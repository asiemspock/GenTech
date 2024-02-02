using GenTech.Data;
using GenTech.Models;
using GenTech.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace GenTech.ViewModels
{
    public class CompanyViewModel : IValidatableObject
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        [Phone]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [MaxFileSize(2 * 1024 * 1024)]
        [AllowedExtensions(new string[] {".jpg", ".png", ".gif", ".jpeg", ".webp"})]
        public IFormFile CompanyLogo { get; set; }
        public string? CurrentLogo {  get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var context = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));

            if (context.Company.Any(x => x.CompanyName == CompanyName && x.Id != Id))
            {
                yield return new ValidationResult("Company Name already exists.", new[] { nameof(CompanyName) });
            }

            if (context.Company.Any(x => x.Email == Email && x.Id != Id))
            {
                yield return new ValidationResult("Email already exists.", new[] { nameof(Email) });
            }
            
            if (context.Company.Any(x => x.Phone == Phone && x.Id != Id))
            {
                yield return new ValidationResult("Phone number already exists.", new[] { nameof(Phone) });
            }
        }
    }
}
