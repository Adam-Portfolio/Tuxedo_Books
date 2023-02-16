using System.Text.Json.Serialization;

namespace Bookstore.Models
{
    // Instances of this class are stored in session after being converted to a 
    // JSON string. Since the readonly Subtotal property doesn't need to be
    // stored, it's decorated with the [JsonIgnore] attribute so it will 
    // be skipped when the JSON string is created.

    public class CartItem
    {
        public BookDTO Book { get; set; } = new BookDTO();
        public int Quantity { get; set; }

        [JsonIgnore]
        public double Subtotal => Book.Price * Quantity;
    }
}
