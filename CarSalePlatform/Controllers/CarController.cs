//////////////////////////////////////////////////////////////////////
/////////       WEB PROGRAMMING HOMEWORK 23.12.2024      /////////////
///       BERKE ŞAHİN B221202053 / SUUDE NAS ÇETİN B221202006      ///
//////////////////////////////////////////////////////////////////////

using CarSalePlatform.Models;
using Microsoft.AspNetCore.Mvc;
using CarSalePlatform.Filters;
// Thanks to the above libraries, we can use features such as MVC operations, special filters(for example, RequireLogin).

namespace CarSalePlatform.Controllers
{
    [RequireLogin] // It makes it mandatory to log in for all actions. If there is no login, the user is redirected to the Login page.
    public class CarController : Controller
    {
        private readonly AppDbContext _context;

        public CarController(AppDbContext context)  // It is the context class that we use for database operations.
        {
            _context = context;
        }

        public IActionResult Index() // It is used to list all cars.
        {
            var cars = _context.Cars.ToList(); // It brings all the cars in the database.
            ViewBag.LastUpdated = DateTime.Now.ToString("dd/MM/yyyy | HH:mm"); // It shows when the listing page was last updated.
            return View(cars);
        }

        public IActionResult Create() // The form for adding an empty car to the user (Create.cshtml) provides.
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Car car)
        {
            if (ModelState.IsValid) // It checks whether the validation rules in the car model are followed or not.
            {
                if (car.PhotoFile != null)
                {
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images"); // If the PhotoFile is full, the photo is saved to the wwwroot/images folder on the server.
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + car.PhotoFile.FileName; // The Guid is used to make the photo a unique file name.
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName); 

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        car.PhotoFile.CopyTo(fileStream);
                    }

                    car.PhotoPath = "/images/" + uniqueFileName; // The saved photo path (PhotoPath) is added to the database.
                }

                _context.Cars.Add(car); // Adds the new car to the database.
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(car);
        }

        public IActionResult Edit(int id) // The car that the user wants to edit (Edit.cshtml) brings it to the user.
        {
            var car = _context.Cars.Find(id); // It finds the relevant car from the database with the ID.
            if (car == null)
            {
                return NotFound(); // If the car is not found, a 404 error returns.
            }

            return View(car);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [HttpPost]

// This code snippet is used to update a car registration that is already in the database. The user enters new values in the edit form. These values are assigned to the corresponding properties of the existing car object.
public IActionResult Edit(Car car)
{
    if (ModelState.IsValid)
    {
        var existingCar = _context.Cars.Find(car.Id); // car.Id with the, the existing record from the database is found and assigned to the existing car object.
        if (existingCar == null)
        {
            return NotFound();
        }

        existingCar.Brand = car.Brand;
        existingCar.Model = car.Model;
        existingCar.Year = car.Year;
        existingCar.Price = car.Price;
        existingCar.Description = car.Description;
        existingCar.FuelType = car.FuelType;

        if (car.PhotoFile != null)
        {
            if (!string.IsNullOrEmpty(existingCar.PhotoPath))
            {
                var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", existingCar.PhotoPath.TrimStart('/'));
                if (System.IO.File.Exists(oldFilePath))
                {
                    System.IO.File.Delete(oldFilePath);
                }
            }

            
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + car.PhotoFile.FileName;
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                car.PhotoFile.CopyTo(fileStream);
            }

            existingCar.PhotoPath = "/images/" + uniqueFileName;
        }

        _context.Cars.Update(existingCar); // The updated existingCar object is saved to the database.
        _context.SaveChanges(); // The updated existingCar object is saved to the database.

        return RedirectToAction("Index");
    }

    return View(car);
}


        public IActionResult Delete(int id) // It shows the car which one the user wants to delete.
        {
            var car = _context.Cars.Find(id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        public IActionResult Details(int id) // The details of a particular car (Details.cshtml) brings it up.
        {
            var car = _context.Cars.FirstOrDefault(c => c.Id == id); // It brings the first car that matches the id.
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id) // This action, which performs the deletion process, processes the post from the form.
        {
            var car = _context.Cars.Find(id);
            if (car != null)
            {
                _context.Cars.Remove(car); // Deletes the car from the database.
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}