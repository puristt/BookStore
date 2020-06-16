using BookStoreWeb.Models;
using BusinessLayer.Services.AuthorService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreWeb.Controllers
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
            AuthorPageViewModel viewModel = new AuthorPageViewModel();
            viewModel.ItemList = _authorService.GetAllAuthors();
            return View(viewModel);
        }
        public PartialViewResult GetAlphabeticResult(string letter)
        {
            if (letter.Length > 1)
            {
                var allAuthors = _authorService.GetAllAuthors();
                return PartialView("_AuthorListPartial", allAuthors);

            }

            var result = _authorService.SearchAuthorsAlphabetically(letter);
            return PartialView("_AuthorListPartial", result);
        }
        public PartialViewResult GetSearchedResult(string searchText)
        {
            var result = _authorService.SearchAuthorByName(searchText);

            return PartialView("_AuthorListPartial", result);
        }

    }
}