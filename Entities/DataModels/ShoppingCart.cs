using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataModels
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }

        public User User { get; set; } // User Table
    }
}
