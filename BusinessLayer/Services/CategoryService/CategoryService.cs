using DataAccessLayer.Repository.CategoryRepository;
using Entities.DataModels;
using Entities.WebViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryRepository.GetAll();
        }

        public IEnumerable<CategoryListModel> GetCategoriesWithBookCount()
        {
            return _categoryRepository.GetCategoryListModel();
        }

        public IEnumerable<Category> GetRelatedCategoriesByBookId(int id)
        {
            return _categoryRepository.GetAllByBookId(id);
        }
    }
}
