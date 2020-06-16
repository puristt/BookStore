using BusinessLayer.ErrorHelper;
using DataAccessLayer.DatabaseManager;
using DataAccessLayer.Repository.AuthorRepository;
using DataAccessLayer.Repository.BookRepository;
using Entities;
using Entities.AdminViewModels.Author;
using Entities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.AuthorService
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IDapperRepository<Author> _dapperRepository;
        public AuthorService(IAuthorRepository authorRepository, IBookRepository bookRepository, IDapperRepository<Author> dapperRepository)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
            _dapperRepository = dapperRepository;
        }
        public IEnumerable<Author> GetAllAuthors()
        {
            return _authorRepository.GetAll();
        }

        public Author GetAuthorById(int id)
        {
            return _authorRepository.GetById(id);
        }

        public GenericResults<Author> SaveModel(Author model)
        {
            var db_author = _authorRepository.CheckByName(model.Name);
            GenericResults<Author> updateModel = new GenericResults<Author>();

            if(db_author != null)
            {
                updateModel.AddError(ErrorMessageCode.AuthorAlreadyExists, "Bu yazar zaten sistemde Kayıtlı!");
                return updateModel;
            }

            updateModel.Model = this.PrepareEntity(model);
            int result = _authorRepository.Save(updateModel.Model);
            if(result == 0)
            {
                updateModel.AddError(ErrorMessageCode.SomethingWentWrong, "Bir hata oluştu. Lütfen Tekrar Deneyiniz!");
            }
            return updateModel;
        }

        public IEnumerable<Author> SearchAuthorByName(string authorName)
        {
            if (authorName == null)
                authorName = "";

            return _authorRepository.SearchByName(authorName);
        }

        public Author PrepareEntity(Author model)
        {
            var entity = _authorRepository.GetById(model.Id) ?? new Author();

            entity.Name = model.Name;
            entity.Description = model.Description;
            return entity;
        }

        public bool DeleteAuthor(int id)
        {
            int bookCount = _bookRepository.CountByAuthorId(id);

            if (bookCount > 0)
                return false;

            int result = _authorRepository.Delete(id);

            if (result == 0)
                return false;

            return true;
        }

        public IEnumerable<AuthorListModel> GetAllWithPaging(out int totalItemCount)
        {
            var result = _dapperRepository.LoadData<AuthorListModel>("spGetAllAuthorsPaging");
            totalItemCount = result.Any() ? result.First().TotalRows : 0;

            return result;
        }

        public IEnumerable<AuthorListModel> SearchAuthorByNameWithPaging(string searchText, int pageNumber, int pageSize, out int totalItemCount)
        {
            if (searchText == null)
            {
                searchText = "";
            }
            var parameters = new { Name = searchText, PageNumber = pageNumber, PageSize = pageSize };

            var result = _dapperRepository.LoadData<AuthorListModel>("spSearchAuthorByNameWithPaging", parameters);

            totalItemCount = result.Any() ? result.First().TotalRows : 0;

            return result;
        }

        public IEnumerable<Author> SearchAuthorsAlphabetically(string letter)
        {
            return _authorRepository.SearchAlphabetically(letter);
        }
    }
}
