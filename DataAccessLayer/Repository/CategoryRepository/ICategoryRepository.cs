using Entities.DataModels;
using Entities.WebViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.CategoryRepository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        IEnumerable<Category> GetAllByBookId(int id);
        IEnumerable<CategoryListModel> GetCategoryListModel();
        Category GetById(int id);
        int Save(Category entity);
        Category CheckByName(string categoryName);
        IEnumerable<Category> SearchByName(string name);
        int Delete(int id);
        
    }
}
