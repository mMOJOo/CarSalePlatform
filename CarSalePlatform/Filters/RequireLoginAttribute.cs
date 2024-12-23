//////////////////////////////////////////////////////////////////////
/////////       WEB PROGRAMMING HOMEWORK 23.12.2024      /////////////
///       BERKE ŞAHİN B221202053 / SUUDE NAS ÇETİN B221202006      ///
//////////////////////////////////////////////////////////////////////
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters; // It allows us to use filtering mechanisms.
// Thanks to the above libraries, we can use features such as MVC operations, special filters(for example, RequireLogin).

namespace CarSalePlatform.Filters
{
    public class RequireLoginAttribute : ActionFilterAttribute // ASP.NET It is an infrastructure used in Core to perform certain controls before or after actions are executed.
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userEmail = context.HttpContext.Session.GetString("UserEmail"); // User session control.

            if (string.IsNullOrEmpty(userEmail)) // If userEmail is empty or undefined, it means that the user is not logged in.
            {
                
                context.Result = new RedirectToActionResult("Login", "Account", null); // Directs the user to the "Login" action in the "Account" controller.
            }

            base.OnActionExecuting(context); // If logged in, it allows the action to work normally.
        }
    }
}
