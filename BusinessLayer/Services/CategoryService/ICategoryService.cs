using BusinessLayer.ErrorHelper;
using Entities.AdminViewModels.Category;
using Entities.DataModels;
using Entities.WebViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.CategoryService
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
        IEnumerable<CategoryListPagingModel> GetAllWithPaging(out int totalItemCount);
        IEnumerable<CategoryListModel> GetCategoriesWithBookCount();
        IEnumerable<Category> GetBookCategories(int bookId);
        IEnumerable<Category> GetRelatedCategoriesByBookId(int id);
        Category GetCategoryById(int id);
        GenericResults<Category> SaveModel(Category model);
        IEnumerable<Category> SearchCategoryByName(string categoryName);
        IEnumerable<CategoryListPagingModel> SearchCategoryByTitleWithPaging(string searchText, int pageNumber, int pageSize, out int totalItemCount);
        bool DeleteCategory(int id);
    }
}
