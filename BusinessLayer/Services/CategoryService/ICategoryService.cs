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
        IEnumerable<CategoryListModel> GetCategoriesWithBookCount();
        IEnumerable<Category> GetRelatedCategoriesByBookId(int id);
    }
}
