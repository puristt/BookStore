using BookStoreWeb.Models;
using BusinessLayer.Services.BookService;
using BusinessLayer.Services.CategoryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IBookService _bookService;
        public CategoryController(ICategoryService categoryService, IBookService bookService)
        {
            _categoryService = categoryService;
            _bookService = bookService;
        }
        // GET: Category
        public PartialViewResult GetCategoriesWithBookCount()
        {
            var categoryList = _categoryService.GetCategoriesWithBookCount();

            return PartialView("_CategoriesPartial", categoryList);
        }

    }
}