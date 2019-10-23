using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Service.Controllers
{
    public class AdminController : Controller
    {
        //
        Entities db = new Entities();
        // GET: /Admin/
        //[ValidateAntiForgeryToken]
        public ActionResult Index()
        {
            IEnumerable<MsgList> x = new List<MsgList>();
            var list = db.contacts.Select(p => new MsgList
            {
                Email=p.Email,
                mobilenumber=p.mobilenumber,
                Name=p.Name,
                message=p.message

            }).ToList();
            if (list!= null && list.Count > 0)
            {
                return View(list);
            }
            return View();
        }
        public ActionResult GetInboxMsg(string name, string email, int? mobilenumber, string mesassge)
        {
            contact cont = new contact();
            cont.Name = name;
            cont.Email = email;
            cont.mobilenumber = mobilenumber;
            cont.message = mesassge;
            cont.datecontacted = DateTime.UtcNow;
            db.contacts.Add(cont);
            db.SaveChanges();
            return Json("true", JsonRequestBehavior.AllowGet);
        }
    }
}