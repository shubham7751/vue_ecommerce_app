using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using webapi.Model;
using webapi.Services.ProductServices;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository<Product> _productRepository;

        public ProductController(IProductRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            try
            {
                var products = _productRepository.GetAll();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving products: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            try
            {
                var product = _productRepository.GetById(id);
                if (product != null)
                {
                    return Ok(product);
                }
                else
                {
                    return NotFound($"Product with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving product: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool exists = _productRepository.Exists(product.ImageURL);
                    if (exists)
                    {
                        return Conflict("Product with the same image URL already exists.");
                    }

                    bool success = _productRepository.Add(product);
                    if (success)
                    {
                        return Ok("Product added successfully.");
                    }
                    else
                    {
                        return BadRequest("Failed to add product.");
                    }
                }
                else
                {
                    return BadRequest("Invalid product data.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding product: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existingProduct = _productRepository.GetById(id);
                    if (existingProduct != null)
                    {
                        product.ProductID = id; // Ensure the ID is set correctly
                        bool success = _productRepository.Update(product);
                        if (success)
                        {
                            return Ok($"Product with ID {id} updated successfully.");
                        }
                        else
                        {
                            return BadRequest($"Failed to update product with ID {id}.");
                        }
                    }
                    else
                    {
                        return NotFound($"Product with ID {id} not found.");
                    }
                }
                else
                {
                    return BadRequest("Invalid product data.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating product: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                var existingProduct = _productRepository.GetById(id);
                if (existingProduct != null)
                {
                    bool success = _productRepository.Delete(id);
                    if (success)
                    {
                        return Ok($"Product with ID {id} deleted successfully.");
                    }
                    else
                    {
                        return BadRequest($"Failed to delete product with ID {id}.");
                    }
                }
                else
                {
                    return NotFound($"Product with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting product: {ex.Message}");
            }
        }
    }
}
