using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace lab2_signmeup_bluntcd.Pages
{
    public class SignupModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Full name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string GuestName { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Please select your year")]
        public string Year { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Please select an attendance option")]
        public string AttendingOption { get; set; } = string.Empty;

        public void OnGet()
        {
            // This runs when someone visits the page
        }

        public IActionResult OnPost()
        {
            // Check if all validation rules passed
            if (!ModelState.IsValid)
            {
                // If validation failed, stay on the same page and show errors
                return Page();
            }

            // If we get here, all validation passed!
            // Create a confirmation message
            var confirmationMessage = $"Thank you {GuestName}! Your reservation has been noted. We'll send details to {Email}.";

            ViewData["SuccessMessage"] = confirmationMessage;

            // Clear the form after successful submission
            ClearForm();

            return Page();
        }

        // Helper method to clear all form fields
        private void ClearForm()
        {
            GuestName = string.Empty;
            Email = string.Empty;
            Year = string.Empty;
            AttendingOption = string.Empty;
        }

    }
}