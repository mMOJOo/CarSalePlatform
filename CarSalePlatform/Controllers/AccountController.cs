//////////////////////////////////////////////////////////////////////
/////////       WEB PROGRAMMING HOMEWORK 23.12.2024      /////////////
///       BERKE ŞAHİN B221202053 / SUUDE NAS ÇETİN B221202006      ///
//////////////////////////////////////////////////////////////////////

using CarSalePlatform.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarSalePlatform.Filters;
// Thanks to the above libraries, we can use features such as MVC operations, special filters(for example, RequireLogin).

namespace CarSalePlatform.Controllers
{
    public class AccountController : Controller // A controller that manages user registration (Register), login (Login), and Logout operations.
    
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context) // It is the context class that we use for database operations.
        {
            _context = context;
        }

        [AllowAnonymous] // This means that no authentication is required for the action.
        public IActionResult Register() // We show the user an empty registration form.
        {
            return View();
        }

        [HttpPost] // This action processes the form data from the user.
        [AllowAnonymous]
        public IActionResult Register(User user)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == user.Email); // It is checked whether the user's email is unique or not. If there is a user registered with the same email, the error message returns and the form is shown again.
            if (existingUser != null)
            {
                ViewBag.Error = "This email is already registered. Please use a different email."; // Here is the error message.
                return View(user); // And the form is shown again.
            }

            if (ModelState.IsValid) // Checks whether it complies with the Required in the User model.
            {
                _context.Users.Add(user); // if it passes the control, it adds the new user to the database.
                _context.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(user);
        }

        [AllowAnonymous]
        public IActionResult Login() // The user's login form (Login.cshtml) returns.
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password); // It checks the user's e-mail and password information.

            if (user != null) // Of course, if there is a user.
            {
                HttpContext.Session.SetString("UserEmail", user.Email); // The user stores his/her e-mail in the session. This is used to indicate that the user has logged in.
                return RedirectToAction("Index", "Home"); // When the login is successful, it redirects the user to the Index action in the HomeController.
            }

            ViewBag.Error = "Invalid email or password."; // Displays the error message when the username or password is incorrect.
            return View();
        }
        [RequireLogin]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Clears the user's session information.
            return RedirectToAction("Login"); // And after logging out, it redirects the user to the Login page.
        }
    }
}
