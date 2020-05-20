using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreAdmin.Controllers
{
    public class PublisherController : Controller
    {
        // GET: Publisher
        public ActionResult Index()
        {
            return View();
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