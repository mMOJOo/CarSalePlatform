//////////////////////////////////////////////////////////////////////
/////////       WEB PROGRAMMING HOMEWORK 23.12.2024      /////////////
///       BERKE ŞAHİN B221202053 / SUUDE NAS ÇETİN B221202006      ///
//////////////////////////////////////////////////////////////////////
using CarSalePlatform.Models; // Includes the model classes of the application.
using Microsoft.AspNetCore.Identity; // Provides user authentication and management.
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args); // Service addition operations are performed in this section.

builder.Services.AddDistributedMemoryCache(); //  Adds a temporary memory cache for the application.
builder.Services.AddSession(); // ASP.NET Enables session management in Core.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))); // It uses the PostgreSQL database. 
    // GetConnectionString: appsettings.reads the connection string in the json file.
builder.Services.AddControllersWithViews(); // It allows you to use both Controllers and Views.

var app = builder.Build(); // Completes all service configurations and creates the application object.

if (app.Environment.IsDevelopment()) // The Developer Exception Page is activated to view errors in detail.
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // Errors are not shown to the user; they are redirected to the /Home/Error page.
}

app.UseHttpsRedirection(); // It automatically redirects HTTP requests to HTTPS.
app.UseStaticFiles(); // It provides support for static files (CSS, JavaScript, images).
app.UseRouting(); // Maps URLs to specific Controller and Action methods.
app.UseSession();  // Activates session management.
app.UseAuthorization(); // Activates the authorization mechanism.

app.MapControllerRoute( // The Login action on the AccountController is set to the start page.
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run(); // Runs the application and starts listening to requests.