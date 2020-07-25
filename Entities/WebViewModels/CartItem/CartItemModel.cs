

namespace Entities.WebViewModels.CartItem
{
    public class CartItemModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string BookImageUrl { get; set; }
        public string BookTitle { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double Subtotal { get; set; }

    }
}
