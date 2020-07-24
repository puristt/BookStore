using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataModels
{
    public class CartItem
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public int ShoppingCartId { get; set; }
        public DateTime CreatedDate { get; set; }

        //public Book Book { get; set; } // Book Table
        //public ShoppingCart ShoppingCart { get; set; } // ShoppingCart Table
    }
}
