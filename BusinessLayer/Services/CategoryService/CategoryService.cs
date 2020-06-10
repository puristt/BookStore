using BusinessLayer.ErrorHelper;
using DataAccessLayer.Repository.BookRepository;
using DataAccessLayer.Repository.CategoryRepository;
using Entities;
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
        private readonly IBookRepository _bookRepository;

        public CategoryService(ICategoryRepository categoryRepository, IBookRepository bookRepository)
        {
            _categoryRepository = categoryRepository;
            _bookRepository = bookRepository;
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryRepository.GetAll();
        }

        public IEnumerable<CategoryListModel> GetCategoriesWithBookCount()
        {
            return _categoryRepository.GetCategoryListModel();
        }

        public Category GetCategoryById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public IEnumerable<Category> GetRelatedCategoriesByBookId(int id)
        {
            return _categoryRepository.GetAllByBookId(id);
        }

        public GenericResults<Category> SaveModel(Category model)
        {
            var db_category = _categoryRepository.CheckByName(model.Title);
            GenericResults<Category> updateModel = new GenericResults<Category>();

            if (db_category != null)
            {
                updateModel.AddError(ErrorMessageCode.CategoryALreadyExists, "Bu kategori daha önce kayıt edilmiş!");
                return updateModel;
            }

            updateModel.Model = this.PrepareEntity(model);

            int result = _categoryRepository.Save(updateModel.Model);
            if (result == 0)
            {
                updateModel.AddError(ErrorMessageCode.SomethingWentWrong, "Bir şeyler yanlış gitti. Tekrar deneyiniz!");
            }

            return updateModel;
        }

        public Category PrepareEntity(Category model)
        {
            var entity = _categoryRepository.GetById(model.Id) ?? new Category();

            entity.Title = model.Title;
            return entity;
        }

        public IEnumerable<Category> SearchCategoryByName(string categoryName)
        {
            if (categoryName == null)
            {
                categoryName = "";
            }
            return _categoryRepository.SearchByName(categoryName);
        }

        public bool DeleteCategory(int id)
        {
            int bookCount = _bookRepository.CountByCategoryId(id);

            if (bookCount > 0)
                return false;

            int result = _categoryRepository.Delete(id);

            if (result == 0)
                return false;

            return true;
        }
    }
}
