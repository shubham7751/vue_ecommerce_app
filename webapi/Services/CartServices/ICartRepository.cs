

using webapi.Model;

namespace webapi.Services.CartServices
{
   
        public interface ICartRepository
        {
            IEnumerable<Cart> GetAllItems(); // Get all items in the cart
            Cart GetCartItemById(int ParamCartID); // Get a specific cart item by its ID
            bool AddCartItem(Cart item); // Add an item to the cart
        Cart UpdateCartItem(Cart item,int ParamCartID); // Update quantity or other details of a cart item
            bool DeleteCartItem(int ParamCartID); // Remove an item from the cart
            void ClearCart(); // Remove all items from the cart
           // bool Checkout(); // Process checkout for the items in the cart
        }
    }

