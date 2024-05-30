using System.ComponentModel.DataAnnotations;
namespace webapi.Model
{
    public class Cart
    {

        public int CartID { get; set; }
        [Required(ErrorMessage = "UserId is required.")]
        public String Id { get; set; }
        [Required(ErrorMessage = "ProductID is required.")]
        public int ProductID { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Discount { get; set; }

        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        public Cart(int cartID, string id, int productId, decimal unitPrice, decimal discount, int quantity, decimal totalPrice)
        {
            CartID = cartID;
            Id = id;
            ProductID = productId;
            UnitPrice = unitPrice;
            Discount = discount;
            Quantity = quantity;
            TotalPrice = totalPrice;
        }
    }
}
