using BusinessLayer.Services.AuthorService;
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
        public ActionResult Index()
        {
            var authorList = _authorService.GetAllAuthors();
            return View(authorList);
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

        public PartialViewResult LoadAuthorList(string searchText)
        {
            var model = _authorService.SearchAuthorByName(searchText);
            return PartialView("_AuthorListPartial", model);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            bool deleteResult = _authorService.DeleteAuthor(id.Value);

            return Json(new { result = deleteResult }, JsonRequestBehavior.AllowGet);
        }
    }
}