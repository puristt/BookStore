﻿using BusinessLayer.Services.PublisherService;
using Entities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using Entities.AdminViewModels.Publisher;
using BookStoreAdmin.Models.Pagination;

namespace BookStoreAdmin.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }
        // GET: Publisher
        public ActionResult Index(int page = 1)
        {
            PagedListModel<PublisherListModel> model = new PagedListModel<PublisherListModel>();

            model.CurrentList = _publisherService.GetAllWithPaging(out int totalItemCount);
            model.TotalItemCount = totalItemCount;
            model.CurrentPageNumber = page;
        
            return View(model);
        }
        [Route("Publisher/Detail")]
        [Route("Publisher/Detail/{id}")]
        [HttpGet]
        public ActionResult Detail(int? id)
        {
            if (id != null)
            {
                var model = _publisherService.GetPublisherById(id.Value);
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Detail(Publisher model)
        {
            if (ModelState.IsValid)
            {
                var result = _publisherService.SaveModel(model);
                if (result.Errors.Count > 0)
                {
                    result.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View();
                }
                if (model.Id == default)
                {
                    TempData["Success"] = "Yeni Yayınevi Başarıyla Eklendi! Yayınevi Listesine Yönlendiriliyorsunuz...";
                }
                else
                {
                    TempData["Success"] = "Yayınevi Başarıyla Güncellendi!  Yayınevi Listesine Yönlendiriliyorsunuz...";
                }

                ModelState.Clear();
                return View();
            }


            return View();
        }

        public ActionResult LoadPublisherList(string searchText, int page = 1)
        {
            PagedListModel<PublisherListModel> model = new PagedListModel<PublisherListModel>();
            model.CurrentList = _publisherService.SearchPublisherByNameWithPaging(searchText, page, model.PageSize, out int totalItemCount);
            model.TotalItemCount = totalItemCount;
            model.CurrentPageNumber = page;
            return PartialView("_PublisherListPartial",model);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            bool deleteResult = _publisherService.DeletePublisher(id.Value);

            return Json(new { result = deleteResult}, JsonRequestBehavior.AllowGet);
        }
    }
}