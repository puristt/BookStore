using BookStoreWeb.Models;
using BusinessLayer.Services.AuthorService;
using BusinessLayer.Services.BookImageService;
using BusinessLayer.Services.BookService;
using BusinessLayer.Services.CategoryService;
using BusinessLayer.Services.PublisherService;
using BusinessLayer.Services.ReviewService;
using Entities.WebViewModels.Book;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BookStoreWeb.Controllers
{
    public class BookController : Controller
    {
        #region Ctor

        private readonly IBookService _bookService;
        private readonly IBookImageService _bookImageService;
        private readonly IReviewService _reviewService;
        private readonly ICategoryService _categoryService;
        private readonly IPublisherService _publisherService;
        private readonly IAuthorService _authorService;
        public BookController(IBookService bookService, IBookImageService bookImageService, IReviewService reviewService,
            ICategoryService categoryService, IPublisherService publisherService, IAuthorService authorService)
        {
            _bookService = bookService;
            _bookImageService = bookImageService;
            _reviewService = reviewService;
            _categoryService = categoryService;
            _publisherService = publisherService;
            _authorService = authorService;
        }
        #endregion
        public ActionResult Shop(int page = 1, string searchSortBy = null)
        {
            var pageSize = 10;


            var list = _bookService.GetBookListForShopPage(page, pageSize, searchSortBy, out var totalItemCount);

            var bookListAsIPagedList = new StaticPagedList<BookListModel>(list, page, pageSize, totalItemCount);

            ViewBag.SortingList = PrepareSorting();

            if(searchSortBy != "")
            {
                ViewBag.SelectedItem = searchSortBy;
            }

            ViewBag.Action = "Shop"; 

            return View(bookListAsIPagedList);
        }
        public ActionResult ShowQuickView(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = _bookService.GetQuickViewById(id.Value);

            return PartialView("_QuickViewPartial", model);
        }

        public ActionResult Category(int? id, int page = 1, string searchSortBy = null)
        {
            var pageSize = 10;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var list = _bookService.GetBookListForShopPageByCategoryId(id.Value, page, pageSize, searchSortBy, out int totalItemCount);


            ViewBag.Content = _categoryService.GetCategoryById(id.Value).Title;

            var bookListAsIPagedList = new StaticPagedList<BookListModel>(list, page, pageSize, totalItemCount);

            ViewBag.SortingList = PrepareSorting();

            if (searchSortBy != null)
            {
                ViewBag.SelectedItem = searchSortBy;
            }

            ViewBag.Action = "Category";
            return View("Shop", bookListAsIPagedList);
        }

        public ActionResult Publisher(int? id, int page = 1, string searchSortBy = null)
        {
            var pageSize = 10;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var list = _bookService.GetBookListForShopPageByPublisherId(id.Value, page, pageSize, searchSortBy, out int totalItemCount);

            ViewBag.Content = _publisherService.GetPublisherById(id.Value).Name + " Adlı Yayınevi için sonuçlar";

            var bookListAsIPagedList = new StaticPagedList<BookListModel>(list, page, pageSize, totalItemCount);

            ViewBag.SortingList = PrepareSorting();

            if (searchSortBy != null)
            {
                ViewBag.SelectedItem = searchSortBy;
            }

            ViewBag.Action = "Publisher";
            return View("Shop", bookListAsIPagedList);
        }

        public ActionResult Author(int? id, int page = 1, string searchSortBy = null)
        {
            var pageSize = 10;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var list = _bookService.GetBookListForShopPageByAuthorId(id.Value,page,pageSize, searchSortBy, out int totalItemCount);

            ViewBag.Content = _authorService.GetAuthorById(id.Value).Name + " Adlı Yazar için sonuçlar";

            var bookListAsIPagedList = new StaticPagedList<BookListModel>(list, page, pageSize, totalItemCount);

            ViewBag.SortingList = PrepareSorting();

            if (searchSortBy != null)
            {
                ViewBag.SelectedItem = searchSortBy;
            }

            ViewBag.Action = "Author";
            return View("Shop", bookListAsIPagedList);
        }
        public ActionResult Detail(int id)
        {

            var model = new BookDetailViewModel
            {
                Book = _bookService.GetBookDetail(id),
                BookImages = _bookImageService.GetImagesForBook(id),
                BookReviews = _reviewService.GetReviewsForBook(id),
                RelatedCategories = _categoryService.GetRelatedCategoriesByBookId(id)
            };

            return View(model);
        }

        public PartialViewResult RelatedProducts()
        {

            return PartialView();
        }


        public List<SelectListItem> PrepareSorting()
        {
            List<SelectListItem> items = new List<SelectListItem>
            {
                new SelectListItem {Text = "Yeni",Value="newness_desc", Selected = true},
                new SelectListItem {Text = "Eski", Value= "newness_asc"},
                new SelectListItem {Text = "Fiyata Göre Azalan",Value="price_desc"},
                new SelectListItem {Text = "Fiyata göre Artan", Value="price_asc"},
                new SelectListItem {Text = "A - Z" , Value="name_sort_asc"},
                new SelectListItem {Text = "Z - A" , Value ="name_sort_desc"},
            };


            return items;
        }
    }
}