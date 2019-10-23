using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Service.Models;
using PagedList.Mvc;
using PagedList;

namespace Service.Controllers
{
    
    public class HomeController : Controller
    {
        Entities db = new Entities();
        public ActionResult Index()
        {

            ViewBag.Categeries = new SelectList(db.Categeries, "id", "Category");
            return View();
        }

        public ActionResult Loadproviderlist(int? page)
        {
            //IenumproviderListmodel sss = new IenumproviderListmodel();
            //var list = db.ProviderInfoes.Select(p => new ProivderListModel
            var list = db.ProviderInfoes.Select(p => new ProivderListModel
            {
                Name = p.UserName,
                Descripton = p.AboutMe,
                photo=p.Photo,
                ID=p.id,
                providerid=p.ProviderId.ToString()

            }).ToList().ToPagedList(page ?? 1, 3);


            return PartialView("_searchpartial", list);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Getprovider()
        {
            return PartialView("_searchpartial");
        }
    }
}