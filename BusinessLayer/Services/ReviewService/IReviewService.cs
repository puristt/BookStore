using Entities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.ReviewService
{
    public interface IReviewService
    {
        IEnumerable<Review> GetReviewsForBook(int bookId);
    }
}
