using DataAccessLayer.Repository.ReviewRepository;
using Entities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.ReviewService
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        public IEnumerable<Review> GetReviewsForBook(int bookId)
        {
            return _reviewRepository.GetBookReviews(bookId);
        }
    }
}
