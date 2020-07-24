using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataModels
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }

        //public List<Review> Reviews { get; set; } //Review Table
        //public List<Book> FavoriteBooks { get; set; } //Book Table
    }
}
