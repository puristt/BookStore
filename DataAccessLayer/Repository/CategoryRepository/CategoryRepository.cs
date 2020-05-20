using DataAccessLayer.DatabaseManager;
using Entities.DataModels;
using Entities.WebViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDapperRepository<Category> _repository;
        public CategoryRepository(IDapperRepository<Category> repository)
        {
            _repository = repository;
        }
        public IEnumerable<Category> GetAll()
        {
            return _repository.LoadData("spGetAllCategories");
        }

        public IEnumerable<Category> GetAllByBookId(int id)
        {
            var parameters = new { BookId = id };

            return _repository.LoadData("spGetBookRelatedCategories", parameters);
        }

        public IEnumerable<CategoryListModel> GetCategoryListModel()
        {
            return _repository.LoadData<CategoryListModel>("spGetAllCategoriesWithBookCount");
        }
    }
}
