using BusinessLayer.Services.AuthorService;
using System;
using System.Collections.Generic;
using System.Linq;
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