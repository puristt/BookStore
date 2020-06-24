using BusinessLayer.ErrorHelper;
using DataAccessLayer.DatabaseManager;
using DataAccessLayer.Repository.BookImageRepository;
using DataAccessLayer.Repository.BookRepository;
using Entities;
using Entities.AdminViewModels.Book;
using Entities.DataModels;
using Entities.WebViewModels.Book;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IDapperRepository<Book> _dapperRepository;
        private readonly IBookImageRepository _bookImageRepository;

        public BookService(IBookRepository bookRepository, IDapperRepository<Book> dapperRepository, IBookImageRepository bookImageRepository)
        {
            _bookRepository = bookRepository;
            _dapperRepository = dapperRepository;
            _bookImageRepository = bookImageRepository;
        }

        public InsertBookModel GetBookById(int id)
        {
            return _bookRepository.GetById(id);
        }

        public BookListModel GetQuickViewById(int id)
        {

            return _bookRepository.GetQuickViewById(id);
        }

        public IEnumerable<BookListModel> GetBookListForShopPage(int page, int pageSize, string sortBy, out int totalItemCount)
        {
            var parameters = new { PageNumber = page, PageSize = pageSize, SortBy = sortBy };

            var result = _dapperRepository.LoadData<BookListModel>("spGetAllBooksForShopList", parameters);

            totalItemCount = result.Any() ? result.First().TotalRows : 0;
            return result;
        }

        public IEnumerable<BookListModel> GetBookListForShopPageByCategoryId(int id, int page, int pageSize, string sortBy, out int totalItemCount)
        {
            var parameters = new { CategoryId = id, PageNumber = page, PageSize = pageSize, SortBy = sortBy };

            var result = _dapperRepository.LoadData<BookListModel>("spGetAllBooksForShopListByCategoryId", parameters);

            totalItemCount = result.Any() ? result.First().TotalRows : 0;

            return result;
        }
        public IEnumerable<BookListModel> GetBookListForShopPageByPublisherId(int id, int page, int pageSize, string sortBy, out int totalItemCount)
        {
            var parameters = new { PublisherId = id, PageNumber = page, PageSize = pageSize, SortBy = sortBy };

            var result = _dapperRepository.LoadData<BookListModel>("spGetBookListForShopPageByPublisher", parameters);

            totalItemCount = result.Any() ? result.First().TotalRows : 0;

            return result;
        }
        public IEnumerable<BookListModel> GetBookListForShopPageByAuthorId(int id, int page, int pageSize, string sortBy, out int totalItemCount)
        {
            var parameters = new { AuthorId = id, PageNumber = page, PageSize = pageSize, SortBy = sortBy };

            var result = _dapperRepository.LoadData<BookListModel>("spGetBookListForShopPageByAuthor", parameters);

            totalItemCount = result.Any() ? result.First().TotalRows : 0;

            return result;
        }
        public BookDetailModel GetBookDetail(int id)
        {
            var parameters = new { Id = id };
            return _dapperRepository.LoadData<BookDetailModel>("spGetBookDetail", parameters).FirstOrDefault();
        }
        public IEnumerable<BookListModel> GetRelatedProductsByCategoryId(int categoryId)
        {
            return _bookRepository.GetRelatedProducts(categoryId);
        }

        public IEnumerable<FilteredBookListModel> GetFilteredBookList(SearchModel searchModel, int pageNumber, int pageSize, out int totalItemCount)
        {


            var parameters = GetDynamicSearchModel(searchModel);
            parameters.PageNumber = pageNumber;
            parameters.PageSize = pageSize;

            var bookList = _dapperRepository.LoadData<FilteredBookListModel>("spFilteredBookResults", (object)parameters);

            totalItemCount = bookList.Any() ? bookList.First().TotalRows : 0;

            return bookList;
        }

        public bool DeleteBook(int id)
        {
            int  result = _bookRepository.Delete(id);
            if (result == 0)
                return false;

            return true;
        }

        public GenericResults<InsertBookModel> SaveModel(InsertBookModel model, List<string> imageUrls)
        {
            var db_book = _bookRepository.GetByISBN13(model.ISBN13);
            GenericResults<InsertBookModel> genericModel = new GenericResults<InsertBookModel>();

            if (db_book != null)
            {
                genericModel.AddError(ErrorMessageCode.BookAlreadyExists, "ISBN13 Numarası zaten daha önce kayıt edilmiş!");
                return genericModel;
            }

            var IsbnCheck = IsDigitsOnly(model.ISBN13);
            if ((!IsbnCheck) || model.ISBN13.Length != 13)
            {
                genericModel.AddError(ErrorMessageCode.WrongFormat, "ISBN13 Barkod numarası sadece rakam içermesi gerekir ve 13 rakamdan oluşmalıdır");
                return genericModel;
            }

            Book entity = new Book
            {
                Title = model.Title,
                Description = model.Description,
                PublicationDate = model.PublicationDate,
                Price = model.Price,
                ISBN13 = model.ISBN13,
                Page = model.Page,
                PublisherId = model.PublisherId,
                AuthorId = model.AuthorId,
                Stock = model.Stock
            };
            var generatedBookId = _bookRepository.Save(entity);
            if (generatedBookId == 0)
            {
                genericModel.AddError(ErrorMessageCode.SomethingWentWrong, "Bir Hata oluştu. Lütfen tekrar deneyiniz!");
                return genericModel;
            }

            int imageResult = this.InsertBookImages(imageUrls, generatedBookId);


            var bookCategories = string.Join(",", model.CategoryIds);
            int categoryResult = _bookRepository.SaveBookCategories(bookCategories, generatedBookId);
            if (imageResult == 0 || categoryResult == 0)
            {
                genericModel.AddError(ErrorMessageCode.SomethingWentWrong, "Bir Hata oluştu. Lütfen tekrar deneyiniz!");
                return genericModel;
            }

            return genericModel;

        }


        public dynamic GetDynamicSearchModel(SearchModel model)
        {
            string categoryIds = "";
            string publisherIds = "";
            string authorIds = "";

            if (model.CategoryIds != null)
            {
                categoryIds = string.Join(",", model.CategoryIds);
            }
            if (model.PublisherIds != null)
            {
                publisherIds = string.Join(",", model.PublisherIds);
            }
            if (model.AuthorIds != null)
            {
                authorIds = string.Join(",", model.AuthorIds);
            }

            dynamic parameter = new ExpandoObject();

            parameter.StartDate = model.StartDate;
            parameter.EndDate = model.EndDate;
            parameter.PublisherIds = publisherIds;
            parameter.AuthorIds = authorIds;
            parameter.CategoryIds = categoryIds;
            parameter.BookName = model.BookName ?? "";

            return parameter;
        }

        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        int InsertBookImages(List<string> imageUrls, int bookId)
        {

            if (!imageUrls.Any())
                return -1;

            var urls = string.Join(",", imageUrls);

            return  _bookImageRepository.SaveImagesByBookId(urls, bookId);
        }

    }
}
