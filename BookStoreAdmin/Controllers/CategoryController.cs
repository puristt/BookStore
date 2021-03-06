﻿using BookStoreAdmin.Models.Pagination;
using BusinessLayer.Services.CategoryService;
using Entities.AdminViewModels.Category;
using Entities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
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

        public ActionResult Index(int page = 1)
        {
            PagedListModel<CategoryListPagingModel> model = new PagedListModel<CategoryListPagingModel>();

            model.CurrentList = _categoryService.GetAllWithPaging(out int totalItemCount);
            model.TotalItemCount = totalItemCount;
            model.CurrentPageNumber = page;
            return View(model);
        }

        [Route("Category/Detail")]
        [Route("Category/Detail/{id}")]
        [HttpGet]
        public ActionResult Detail(int? id)
        {
            if(id != null)
            {
                var model = _categoryService.GetCategoryById(id.Value);
                return View(model);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Detail(Category model)
        {
            if (ModelState.IsValid)
            {
                var result = _categoryService.SaveModel(model);
                if(result.Errors.Count > 0)
                {
                    result.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View();
                }
                if(model.Id == default)
                {
                    TempData["Success"] = "Yeni Kategori Başarıyla Eklendi! Kategori Listesine Yönlendiriliyorsunuz...";
                }
                else
                {
                    TempData["Success"] = "Kategori Başarıyla Güncellendi!  Kategori Listesine Yönlendiriliyorsunuz...";
                }

                ModelState.Clear();
                return View();
            }
                

            return View();
        }

        public PartialViewResult LoadCategoryList(string searchText, int page = 1)
        {
            PagedListModel<CategoryListPagingModel> model = new PagedListModel<CategoryListPagingModel>();
            model.CurrentList = _categoryService.SearchCategoryByTitleWithPaging(searchText, page, model.PageSize, out int totalItemCount);
            model.TotalItemCount = totalItemCount;
            model.CurrentPageNumber = page;
            return PartialView("_CategoryListPartial",model);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            bool deleteResult = _categoryService.DeleteCategory(id.Value);

            return Json(new { result = deleteResult }, JsonRequestBehavior.AllowGet);
        }
    }
}