
using System.Data;
using Microsoft.Data.SqlClient;
using webapi.Model;

namespace webapi.Services.ProductServices
{
    public class ProductRepository : IProductRepository<Product>
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetAllProduct1", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Map reader values to Product object properties
                                Product product = new Product
                                {
                                    ProductID = Convert.ToInt32(reader["ProductID"]),
                                    Name = reader["Name"].ToString(),
                                    Brand = reader["Brand"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    ImageURL = reader["ImageURL"].ToString(),
                                    Price = Convert.ToInt32(reader["Price"]),
                                };

                                products.Add(product);
                            }
                        }
                    }
                }
                return products;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while retrieving Product items: " + ex.Message);
                throw;
            }
        }

        public Product GetById(int productId)
        {
            Product product = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetProductById", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ProductID", productId);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                product = new Product
                                {
                                    ProductID = Convert.ToInt32(reader["ProductID"]),
                                    Name = reader["Name"].ToString(),
                                    Brand = reader["Brand"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    ImageURL = reader["ImageURL"].ToString(),
                                    Price = Convert.ToDecimal(reader["Price"])
                                };
                            }
                        }
                    }
                }
                return product;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while retrieving Product item by ID: " + ex.Message);
                throw;
            }
        }

        public bool Add(Product item)
        {
            try
            {
                using (SqlConnection myCon = new SqlConnection(_connectionString))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand("SP_InsertProduct", myCon))
                    {
                        myCommand.CommandType = CommandType.StoredProcedure;
                        myCommand.Parameters.AddWithValue("@Name", item.Name);
                        myCommand.Parameters.AddWithValue("@Brand", item.Brand);
                        myCommand.Parameters.AddWithValue("@Description", item.Description);
                        myCommand.Parameters.AddWithValue("@ImageURL", item.ImageURL);
                        myCommand.Parameters.AddWithValue("@Price", item.Price);
                        myCommand.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool Update(Product item)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_UpdateProduct", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ProductID", item.ProductID);
                        command.Parameters.AddWithValue("@Name", item.Name);
                        command.Parameters.AddWithValue("@Brand", item.Brand);
                        command.Parameters.AddWithValue("@Description", item.Description);
                        command.Parameters.AddWithValue("@ImageURL", item.ImageURL);
                        command.Parameters.AddWithValue("@Price", item.Price);


                        connection.Open();

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating Product item: " + ex.Message);
                throw;
            }
        }

        public bool Delete(int productId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_DeleteProduct", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ProductID", productId);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting Product item: " + ex.Message);
                throw;
            }
        }
    }
}
