//////////////////////////////////////////////////////////////////////
/////////       WEB PROGRAMMING HOMEWORK 23.12.2024      /////////////
///       BERKE ŞAHİN B221202053 / SUUDE NAS ÇETİN B221202006      ///
//////////////////////////////////////////////////////////////////////
using System.ComponentModel.DataAnnotations; // It provides verification (validation) and data identification features.
using System.ComponentModel.DataAnnotations.Schema; // It is used to configure database tables in a more detailed way.
using Microsoft.AspNetCore.Http;

namespace CarSalePlatform.Models
{
    public class Car
    {
        // Thanks to the methods found below, we define all the characteristics of the car.
        public int Id { get; set; }

        [Required]
        public string Brand { get; set; } = string.Empty;

        [Required]
        public string Model { get; set; } = string.Empty;

        [Range(1900, 2024)]
        public int Year { get; set; }

        [Required]
    public string FuelType { get; set; } = "Benzinli"; 

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public string Description { get; set; } = string.Empty;

        public string? PhotoPath { get; set; } 

        [NotMapped]
        public IFormFile? PhotoFile { get; set; } 
    }
}