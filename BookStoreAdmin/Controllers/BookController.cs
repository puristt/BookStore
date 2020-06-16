using BookStoreAdmin.Models;
using BookStoreAdmin.Models.Pagination;
using BusinessLayer.Services.AuthorService;
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
        public BookController(IBookService bookService, ICategoryService categoryService, IPublisherService publisherService, IAuthorService authorService)
        {
            _bookService = bookService;
            _categoryService = categoryService;
            _publisherService = publisherService;
            _authorService = authorService;
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

        [HttpGet]
        public ActionResult Detail(int? id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Detail()
        {
            return View();
        }

        public PartialViewResult LoadFilteredResults(SearchModel filter, int page = 1)
        {
            PagedListModel<FilteredBookListModel> model = new PagedListModel<FilteredBookListModel>();

            model.CurrentList = _bookService.GetFilteredBookList(filter, page, model.PageSize, out var totalItemCount);
            model.TotalItemCount = totalItemCount;
            model.CurrentPageNumber = page;

            return PartialView("_BookListPartial", model);
        }

        public BookFilterModel PrepareFilterModel(BookFilterModel model)
        {
            model.Authors = new MultiSelectList(_authorService.GetAllAuthors(), "Id", "Name", null);
            model.Categories = new MultiSelectList(_categoryService.GetAllCategories(), "Id", "Title");
            model.Publishers = new MultiSelectList(_publisherService.GetAllPublishers(), "Id", "Name", null);

            return model;
        }


    }
}