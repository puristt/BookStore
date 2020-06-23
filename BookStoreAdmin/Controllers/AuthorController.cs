using BookStoreAdmin.Models.Pagination;
using BusinessLayer.Services.AuthorService;
using Entities.AdminViewModels.Author;
using Entities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BookStoreAdmin.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        // GET: Author
        public ActionResult Index(int page = 1)
        {
            PagedListModel<AuthorListModel> model = new PagedListModel<AuthorListModel>();

            model.CurrentList = _authorService.GetAllWithPaging(out int totalItemCount);
            model.TotalItemCount = totalItemCount;
            model.CurrentPageNumber = page;
            return View(model);
        }
        [Route("Author/Detail")]
        [Route("Author/Detail/{id}")]
        [HttpGet]
        public ActionResult Detail(int? id)
        {
            if (id != null)
            {
                var model = _authorService.GetAuthorById(id.Value);
                return View(model);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Detail(Author model)
        {
            if (ModelState.IsValid)
            {
                var result = _authorService.SaveModel(model);
                if (result.Errors.Count > 0)
                {
                    result.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View();
                }
                if (model.Id == default)
                {
                    TempData["Success"] = "Yeni Yazar Başarıyla Eklendi! Yazar Listesine Yönlendiriliyorsunuz...";
                }
                else
                {
                    TempData["Success"] = "Yazar Başarıyla Güncellendi!  Yazar Listesine Yönlendiriliyorsunuz...";
                }

                ModelState.Clear();
                return View();
            }


            return View();
        }

        public PartialViewResult LoadAuthorList(string searchText, int page = 1)
        {
            PagedListModel<AuthorListModel> model = new PagedListModel<AuthorListModel>();
            model.CurrentList = _authorService.SearchAuthorByNameWithPaging(searchText, page, model.PageSize, out int totalItemCount);
            model.TotalItemCount = totalItemCount;
            model.CurrentPageNumber = page;
            return PartialView("_AuthorListPartial", model);
        }

        public JsonResult Delete(int id)
        {

            bool deleteResult = _authorService.DeleteAuthor(id);

            return Json(new { result = deleteResult }, JsonRequestBehavior.AllowGet);
        }
    }
}