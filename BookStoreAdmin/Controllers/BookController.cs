using BookStoreAdmin.Models;
using BookStoreAdmin.Models.Pagination;
using BusinessLayer.Services.AuthorService;
using BusinessLayer.Services.BookImageService;
using BusinessLayer.Services.BookService;
using BusinessLayer.Services.CategoryService;
using BusinessLayer.Services.PublisherService;
using Entities.AdminViewModels.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreAdmin.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        private readonly IPublisherService _publisherService;
        private readonly IAuthorService _authorService;
        private readonly IBookImageService _bookImageService;
        public BookController(IBookService bookService, ICategoryService categoryService, IPublisherService publisherService, IAuthorService authorService, IBookImageService bookImageService)
        {
            _bookService = bookService;
            _categoryService = categoryService;
            _publisherService = publisherService;
            _authorService = authorService;
            _bookImageService = bookImageService;
        }
        // GET: Book
        public ActionResult Index(InitiliazeBookResultViewModel model, int page = 1)
        {
            model.FilterValues = PrepareFilterModel(model.FilterValues);
            model.PagedList.CurrentList = _bookService.GetFilteredBookList(model.SearchModel, page, model.PagedList.PageSize, out var totalItemCount);
            model.PagedList.TotalItemCount = totalItemCount;
            model.PagedList.CurrentPageNumber = page;
            return View(model);
        }
        [Route("Book/Detail")]
        [Route("Book/Detail/{id}")]
        [HttpGet]
        public ActionResult Detail(int? id = null)
        {

            InsertBookViewModel model = new InsertBookViewModel();
            if (id != null)
            {
                model.Book = _bookService.GetBookById(id.Value);
                model.BookCategories = _categoryService.GetBookCategories(id.Value);
                model.Images = _bookImageService.GetImagesForBook(id.Value);
            }

            PrepareInsertModel(model);

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Detail(InsertBookViewModel model, IEnumerable<HttpPostedFileBase> files)
        {
            PrepareInsertModel(model);

            if (model.Book.CategoryIds == null)
            {
                ModelState.AddModelError("", "Lütfen Kategori Seçiniz!");
                return View(model);
            }
            

            if (ModelState.IsValid)
            {
                //TODO : Güncelleme işlemini yap
                var urlList = SaveImagesAndSetUrl(files, model.Book);
                var result = _bookService.SaveModel(model.Book, urlList);
                if(result.Errors.Count > 0)
                {
                    result.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(model);
                }

                if (model.Book.Id == default) TempData["Success"] = "Yeni Kitap Başarıyla Eklendi! Kitap Listesine Yönlendiriliyorsunuz...";
                else TempData["Success"] = "Kitap Başarıyla Güncellendi! Kitap Listesine Yönlendiriliyorsunuz...";
                ModelState.Clear();
                return View(model);
            }


            

            return View(model);
        }



        public PartialViewResult LoadFilteredResults(SearchModel filter, int page = 1)
        {
            PagedListModel<FilteredBookListModel> model = new PagedListModel<FilteredBookListModel>();

            model.CurrentList = _bookService.GetFilteredBookList(filter, page, model.PageSize, out var totalItemCount);
            model.TotalItemCount = totalItemCount;
            model.CurrentPageNumber = page;

            return PartialView("_BookListPartial", model);
        }

        private List<string> SaveImagesAndSetUrl(IEnumerable<HttpPostedFileBase> files, InsertBookModel model)
        {
            List<string> urlList = new List<string>();
            var rootUrl = System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            int imageNum = 0;
            foreach (var image in files)
            {
                if (image != null && (image.ContentType == "image/jpeg" || image.ContentType == "image/jpg" || image.ContentType == "image/png"))
                {
                    imageNum++;
                    string filename = $"{model.Title}_{imageNum}_{Guid.NewGuid()}.{image.ContentType.Split('/')[1]}";

                    image.SaveAs(Server.MapPath($"~/Images/{filename}"));

                    string url = $"{rootUrl}/Images/{filename}";

                    urlList.Add(url);
                }
            }

            return urlList;
        }

        #region PrepareDropdownListMethods
        public BookRelatedDropDownListModel PrepareFilterModel(BookRelatedDropDownListModel model)
        {
            model.Authors = new MultiSelectList(_authorService.GetAllAuthors(), "Id", "Name", null);
            model.Categories = new MultiSelectList(_categoryService.GetAllCategories(), "Id", "Title");
            model.Publishers = new MultiSelectList(_publisherService.GetAllPublishers(), "Id", "Name", null);

            return model;
        }

        public void PrepareInsertModel(InsertBookViewModel model)
        {
            model.AuthorList = new SelectList(_authorService.GetAllAuthors(), "Id", "Name", model.Book.AuthorId);
            model.PublisherList = new SelectList(_publisherService.GetAllPublishers(), "Id", "Name", model.Book.PublisherId);
            model.CategoryList = new MultiSelectList(_categoryService.GetAllCategories(), "Id", "Title", model.BookCategories.Select(x => x.Id).ToArray());
        }

        #endregion
    }
}