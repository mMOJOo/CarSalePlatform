//////////////////////////////////////////////////////////////////////
/////////       WEB PROGRAMMING HOMEWORK 23.12.2024      /////////////
///       BERKE ŞAHİN B221202053 / SUUDE NAS ÇETİN B221202006      ///
//////////////////////////////////////////////////////////////////////
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarSalePlatform.Models;
// Thanks to the above libraries, we can use features such as MVC operations, special filters(for example, RequireLogin).

namespace CarSalePlatform.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index() // This is the default action of the controller.
    {
        return View("Welcome"); // This determines the first page that logged-in users see.
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() // Using the ErrorViewModel, it shows the user the details about the error (for example, the RequestId).
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

