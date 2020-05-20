using DataAccessLayer.DatabaseManager;
using Entities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.ReviewRepository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly IDapperRepository<Review> _repository;
        public ReviewRepository(IDapperRepository<Review> repository)
        {
            _repository = repository;
        }
        public IEnumerable<Review> GetBookReviews(int id)
        {
            var parameters = new { BookId = id };
            return _repository.LoadData("spGetBookReviews", parameters);
        }
    }
}
