using BusinessLayer.Services.CategoryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreAdmin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            var categoryList = _categoryService.GetAllCategories();
            return View(categoryList);
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
    }
}