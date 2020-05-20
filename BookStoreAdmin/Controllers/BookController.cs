using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreAdmin.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
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