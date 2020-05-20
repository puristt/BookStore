using BookStoreWeb.Models;
using BusinessLayer.Services.BookImageService;
using BusinessLayer.Services.BookService;
using BusinessLayer.Services.CategoryService;
using BusinessLayer.Services.ReviewService;
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
        public BookController(IBookService bookService,IBookImageService bookImageService,IReviewService reviewService,ICategoryService categoryService)
        {
            _bookService = bookService;
            _bookImageService = bookImageService;
            _reviewService = reviewService;
            _categoryService = categoryService;
        }
        #endregion
        public ActionResult Shop()
        {
            var list = _bookService.GetBookListForShopPage();
            return View(list);
        }
        public ActionResult ShowQuickView(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = _bookService.GetQuickViewById(id.Value);

            return PartialView("_QuickViewPartial", model);
        }

        public ActionResult Category(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var list = _bookService.GetBookListForShopPageByCategoryId(id.Value);

            return View("Shop", list);
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
    }
}