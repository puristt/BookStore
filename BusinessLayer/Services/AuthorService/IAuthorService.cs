using BusinessLayer.ErrorHelper;
using Entities.AdminViewModels.Author;
using Entities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.AuthorService
{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAllAuthors();
        IEnumerable<AuthorListModel> GetAllWithPaging(out int totalItemCount);
        IEnumerable<Author> SearchAuthorByName(string authorName);
        IEnumerable<AuthorListModel> SearchAuthorByNameWithPaging(string searchText, int pageNumber, int pageSize, out int totalItemCount);
        Author GetAuthorById(int id);
        GenericResults<Author> SaveModel(Author model);
        bool DeleteAuthor(int id);
        IEnumerable<Author> SearchAuthorsAlphabetically(string letter);
    }
}
