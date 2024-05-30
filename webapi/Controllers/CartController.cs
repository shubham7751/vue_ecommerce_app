
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using webapi.Model;
using webapi.Services.CartServices;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {

        private readonly ICartRepository _CartRepository;

        public CartController(ICartRepository CartRepository)
        {
            _CartRepository = CartRepository;
        }

        // GET: api/cart/getallitems
        [HttpGet("getallitems")]
        public IActionResult GetAllItems()
        {
            try
            {
                // Call the GetAllItems method from the repository/service layer
                var cartItems = _CartRepository.GetAllItems();

                // Check if any items were retrieveda
                if (cartItems != null && cartItems.Any())
                {
                    // Return the retrieved cart items
                    return Ok(cartItems);

                }
                else
                {
                    // Return a not found response if no items were retrieved
                    return NotFound("No items found in the cart.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                Console.WriteLine("An error occurred while retrieving cart items: " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error occurred.");
            }
        }
        // GET: api/cart/getcartitembyid/{id}
        [HttpGet("getcartitembyid/{ParamCartID}")]
        public IActionResult GetCartItemById(int ParamCartID)
        {
            try
            {
                // Call the GetCartItemById method from the repository/service layer
                var cartItem = _CartRepository.GetCartItemById(ParamCartID);

                // Check if the cart item was retrieved successfully
                if (cartItem != null)
                {
                    // Return the retrieved cart item
                    return Ok(cartItem);
                }
                else
                {
                    // Return a not found response if the item was not found
                    return NotFound("Cart item not found.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                Console.WriteLine("An error occurred while retrieving cart item by ID: " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error occurred.");
            }
        }

        // POST: api/cart/addtocart
        [HttpPost("addtocart")]
        public IActionResult AddToCart([FromBody] Cart item)
        {
            try
            {
                // Validate the received cartItem using data annotations
                var validationResults = new List<ValidationResult>();
                bool isValid = Validator.TryValidateObject(item, new ValidationContext(item), validationResults, true);

                if (!isValid)
                {
                    // If the cartItem is not valid, return a BadRequest response with the validation errors
                    return BadRequest(validationResults);
                }

                // Call the AddToCart method from the repository/service layer
                bool result = _CartRepository.AddCartItem(item);

                // Check the result
                if (result)
                {
                    return Ok("Item added to cart successfully.");
                }
                else
                {
                    return BadRequest("Failed to add item to cart.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                Console.WriteLine("An error occurred while adding item to cart: " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error occurred.");
            }
        }
        // PUT: api/cart/updateCartItem/{cartID}
        [HttpPut("updateCartItem/{ParamCartID}")]
        public IActionResult UpdateCartItem(int ParamCartID, [FromBody] Cart item)
        {
            try
            {
                // Call the UpdateCartItem method from the repository/service layer
                Cart updatedCartItem = _CartRepository.UpdateCartItem(item, ParamCartID);

                // Check if the cart item was updated successfully
                if (updatedCartItem != null)
                {
                    // If updated successfully, return 200 OK with a custom success message
                    string successMessage = "Cart item updated successfully.";
                    return Ok(new { Message = successMessage, CartItem = updatedCartItem });
                }
                else
                {
                    // If the cart item was not found or failed to update, return 404 Not Found
                    return NotFound("Cart item not found or failed to update.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                Console.WriteLine("An error occurred while updating cart item: " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error occurred.");
            }
        }


        // DELETE: api/cart/deletecartitem/{id}
        [HttpDelete("deletecartitem/{ParamCartID}")]
        public IActionResult DeleteCartItem(int ParamCartID)
        {
            try
            {
                // Call the DeleteCartItem method from the repository/service layer
                bool result = _CartRepository.DeleteCartItem(ParamCartID);

                // Check the result
                if (result)
                {
                    return Ok("Cart item deleted successfully.");
                }
                else
                {
                    return BadRequest("Failed to delete cart item.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                Console.WriteLine("An error occurred while deleting cart item: " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error occurred.");
            }
        }
        // DELETE: api/cart/clearcart
        [HttpDelete("clearcart")]
        public IActionResult ClearCart()
        {
            try
            {
                // Call the ClearCart method from the repository/service layer
                _CartRepository.ClearCart();
                return Ok("Cart cleared successfully.");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                Console.WriteLine("An error occurred while clearing the cart: " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error occurred.");
            }
        }

    }



}
