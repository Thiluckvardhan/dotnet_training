using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace StudentProject.Models
{
    [ModelMetadataType(typeof(StudentMetadata))]
    public partial class Student
    {
    }

    public class StudentMetadata
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
        [RegularExpression(@"^[a-zA-Z\s.'-]+$", ErrorMessage = "Name must contain only letters, spaces, dots, hyphens, or apostrophes.")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = null!;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [StringLength(150, ErrorMessage = "Email must not exceed 150 characters.")]
        public string Email { get; set; } = null!;

        [Phone(ErrorMessage = "Invalid phone number.")]
        [RegularExpression(@"^\d{10,15}$", ErrorMessage = "Phone must be 10 to 15 digits only.")]
        [Display(Name = "Phone Number")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [RegularExpression(@"^(Active|Inactive|Graduated)$", ErrorMessage = "Status must be Active, Inactive, or Graduated.")]
        public string Status { get; set; } = null!;

        [Required(ErrorMessage = "Join date is required.")]
        [Display(Name = "Join Date")]
        public DateOnly JoinDate { get; set; }

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }
    }
}
