
using System.Data;

using Microsoft.Data.SqlClient;
using webapi.Model;

namespace webapi.Services.CartServices
{
    public class CartRepository : ICartRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public CartRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<Cart> GetAllItems()
        {
            List<Cart> cartItems = new List<Cart>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetAllCartItems", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Map reader values to Cart object properties
                                Cart cartItem = new Cart(
                                    cartID: Convert.ToInt32(reader["CartID"]),
                                 id: reader["Id"].ToString(),
                                 productId: Convert.ToInt32(reader["ProductID"]),
                                 unitPrice: Convert.ToDecimal(reader["UnitPrice"]),
                                  discount: Convert.ToDecimal(reader["Discount"]),
                                  quantity: Convert.ToInt32(reader["Quantity"]),
                                  totalPrice: Convert.ToDecimal(reader["TotalPrice"])
  );

                                cartItems.Add(cartItem);
                            }
                        }
                    }
                }
                return cartItems;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                Console.WriteLine("An error occurred while retrieving cart items: " + ex.Message);
                throw; // Rethrow the exception to propagate it
            }
        }
        public Cart GetCartItemById(int ParamCartID)
        {
            Cart cartItem = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetCartItemById", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CartID", ParamCartID); // Corrected parameter name
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Create a new Cart object using the constructor
                                cartItem = new Cart(
                                    cartID: Convert.ToInt32(reader["CartID"]),

                                    id: reader["Id"].ToString(),
                                    productId: Convert.ToInt32(reader["ProductID"]),
                                    unitPrice: Convert.ToDecimal(reader["UnitPrice"]),
                                    discount: Convert.ToDecimal(reader["Discount"]),
                                    quantity: Convert.ToInt32(reader["Quantity"]),
                                    totalPrice: Convert.ToDecimal(reader["TotalPrice"])
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                Console.WriteLine("An error occurred while retrieving cart item by ID: " + ex.Message);
                throw; // Rethrow the exception to propagate it
            }
            return cartItem;
        }

        public bool AddCartItem(Cart item)
        {
            try
            {
                using (SqlConnection myCon = new SqlConnection(_connectionString))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand("SP_AddToCart1", myCon))
                    {
                        myCommand.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        //myCommand.Parameters.AddWithValue("@CartID", item.CartID);
                        myCommand.Parameters.AddWithValue("@Id", item.Id); // Assuming item.Id is string
                        myCommand.Parameters.AddWithValue("@ProductID", item.ProductID);
                        myCommand.Parameters.AddWithValue("@UnitPrice", item.UnitPrice);
                        myCommand.Parameters.AddWithValue("@Discount", item.Discount);
                        myCommand.Parameters.AddWithValue("@Quantity", item.Quantity);

                        // Execute the stored procedure
                        myCommand.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
        public Cart UpdateCartItem(Cart item, int ParamCartID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_UpdateCartItem1", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Set the parameters
                        //command.Parameters.AddWithValue("@CartID", ParamCartID);
                        command.Parameters.AddWithValue("@Id", item.Id);
                        command.Parameters.AddWithValue("@ProductId", item.ProductID);
                        command.Parameters.AddWithValue("@UnitPrice", item.UnitPrice);
                        command.Parameters.AddWithValue("@Discount", item.Discount);
                        command.Parameters.AddWithValue("@Quantity", item.Quantity);

                        // Open the connection
                        connection.Open();

                        // Execute the command
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if the update was successful
                        if (rowsAffected > 0)
                        {
                            // If successful, return the updated cart item by fetching it from the database
                            return GetCartItemById(ParamCartID);
                        }
                        else
                        {
                            // If no rows were affected, return null or handle appropriately
                            return null;
                            throw new Exception("No rows were affected by the update operation.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                Console.WriteLine("An error occurred while updating cart item: " + ex.Message);
                throw; // Rethrow the exception to propagate it
            }
        }
        public bool DeleteCartItem(int ParamCartID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_DeleteCartItem", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CartID", ParamCartID);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0; // Return true if at least one row was affected
                  //return true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                Console.WriteLine("An error occurred while deleting cart item: " + ex.Message);
                throw; // Rethrow the exception to propagate it
            }
        }
        public void ClearCart()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_ClearCart", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                Console.WriteLine("An error occurred while clearing the cart: " + ex.Message);
                throw; // Rethrow the exception to propagate it
            }
        }

    }
}
