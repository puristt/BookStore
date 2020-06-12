using BookStoreWeb.Models;
using BusinessLayer.Services.PublisherService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreWeb.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IPublisherService _publisherService;
        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }
        // GET: Publisher
        public ActionResult Index()
        {
            PublisherPageViewModel viewModel = new PublisherPageViewModel();
            viewModel.Publishers = _publisherService.GetAllPublishers();
            return View(viewModel);
        }

        public PartialViewResult GetAlphabeticResult(string letter)
        {
            if (letter.Length > 1)
            {
                var allPublishers = _publisherService.GetAllPublishers();
                return PartialView("_PublisherListPartial", allPublishers);

            }

            var result = _publisherService.SearchPublishersAlphabetically(letter);
            return PartialView("_PublisherListPartial", result);
        }

        public PartialViewResult GetSearchedResult(string searchText)
        {
            var result = _publisherService.SearchPublisherByName(searchText);

            return PartialView("_PublisherListPartial", result);
        }
    }
}