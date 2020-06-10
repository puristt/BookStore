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

        public Category GetById(int id)
        {
            var parameters = new { CategoryId = id };
            return _repository.LoadData("spGetCategory", parameters).FirstOrDefault();
        }

        public Category CheckByName(string categoryName)
        {
            var parameters = new { Title = categoryName };
            return _repository.LoadData("spCheckCategoryExistanceByTitle", parameters).FirstOrDefault();
        }

        public IEnumerable<CategoryListModel> GetCategoryListModel()
        {
            return _repository.LoadData<CategoryListModel>("spGetAllCategoriesWithBookCount");
        }

        public int Save(Category entity)
        {
            int result;
            if (entity.Id == default) // Eğer yeni bir entity ekleniyor ise Id null olur.
            {
                var parameters = new { entity.Title };
                result = _repository.SaveData<Category>("spInsertCategory", parameters);
            }
            else
            {
                var parameters = new { entity.Id, entity.Title };
                result = _repository.SaveData<Category>("spUpdateCategory", parameters);
            }

            return result;
        }

        public IEnumerable<Category> SearchByName(string name)
        {
            var parameters = new { Title = name };
            return _repository.LoadData("spSearchCategoryByTitle", parameters);
        }

        public int Delete(int id)
        {
            var parameters = new { Id = id };
            return _repository.SaveData<Category>("spDeleteCategory", parameters);
        }
    }
}
