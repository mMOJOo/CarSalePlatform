//////////////////////////////////////////////////////////////////////
/////////       WEB PROGRAMMING HOMEWORK 23.12.2024      /////////////
///       BERKE ŞAHİN B221202053 / SUUDE NAS ÇETİN B221202006      ///
//////////////////////////////////////////////////////////////////////
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CarSalePlatform.Models
{
    public class User 
    {
        public int Id { get; set; } // It represents a unique identification (ID) number belonging to each user.

        [Required(ErrorMessage = "Email is required.")] // Specifies that the e-mail field is mandatory.
        [EmailAddress(ErrorMessage = "Invalid email format.")] // Checks that the entered value must be in the format of a valid e-mail address.
        // If the e-mail format is not valid, "Invalid e-mail format." the message is shown.
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")] // Specifies that the password field is mandatory.
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")] // Checks that the password must be at least 6 characters long.
        // If the password is shorter than 6 characters, "Password must be at least 6 characters long." the message is shown.
        public string Password { get; set; }

        
    }
}
