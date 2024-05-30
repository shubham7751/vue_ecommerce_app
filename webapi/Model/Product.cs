using Azure;
using Microsoft.SqlServer.Server;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing;
using System.Security.AccessControl;

namespace webapi.Model
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Brand is required")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Image URL is required")]
        [Url(ErrorMessage = "Invalid URL format")]
        public string ImageURL { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value")]
        public decimal Price { get; set; }
     public Product()
        {
        }
        public Product(int productId, string name, string brand, string description, string imageUrl, decimal price)
        {
            ProductID = productId;
            Name = name;
            Brand = brand;
            Description = description;
            ImageURL = imageUrl;
            Price = price;
        }

    }
}